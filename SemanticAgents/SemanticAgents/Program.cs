using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Azure;
using MusicAgent.Blazor.Client.Services;
using SemanticAgents;
using SemanticAgents.Client.Abstractions;
using SemanticAgents.Client.Pages;
using SemanticAgents.Components;
using SemanticAgents.Configuration;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Azure Key Vault Configuration
//var keyVaultEndpoint = Environment.GetEnvironmentVariable("KEYVAULT_ENDPOINT");
//if (!string.IsNullOrEmpty(keyVaultEndpoint))
//{
//    builder.Configuration.AddAzureKeyVault(new Uri(keyVaultEndpoint), new DefaultAzureCredential());
//}
//// Add Azure Key Vault to configuration
//var keyVaultEndpoint = Environment.GetEnvironmentVariable("KEYVAULT_ENDPOINT");
//var keyVaultName = Environment.GetEnvironmentVariable("KEYVAULT_NAME");
//// var keyVaultName = builder.Configuration["KeyVaultName"];
//var keyVaultUri = new Uri($"https://{keyVaultName}.vault.azure.net/");
//if (!string.IsNullOrWhiteSpace(keyVaultEndpoint))
//{
//    builder.Configuration.AddAzureKeyVault(new Uri(keyVaultEndpoint), new DefaultAzureCredential());
//    //builder.Configuration.AddAzureKeyVault(keyVaultUri, new DefaultAzureCredential());
//}
//string? keyVaultName = Environment.GetEnvironmentVariable("KEYVAULT_NAME");
string? keyVaultEndpoint = Environment.GetEnvironmentVariable("KEYVAULT_ENDPOINT");
// var kvUri = "https://" + keyVaultName + ".vault.azure.net";
// var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
if (!string.IsNullOrEmpty(keyVaultEndpoint))
{
    var secretClient = new SecretClient(new Uri(keyVaultEndpoint!), new DefaultAzureCredential());
    string? testSecret = secretClient.GetSecret("TestSecret").Value.Value;
    var keyClient = new KeyClient(new Uri(keyVaultEndpoint!), new DefaultAzureCredential());
    string? testKeyVaultUri = keyClient.GetKey("TestKey").Value.Properties.VaultUri.ToString();
    Console.WriteLine($"Test Secret from Azure Key Vault: {testSecret}");
    Console.WriteLine($"Test Key from Azure Key Vault Uri: {testKeyVaultUri}");
}
else Console.WriteLine($"The Azure Key Endpoint was null.");

builder.Services.AddOptions<SemanticKernelSettings>().Configure<IConfiguration>((options, config) =>
    {
        config.GetRequiredSection(SemanticKernelSettings.SectionName).Bind(options);
    });

// REGISTER SEMANTIC KERNEL SERVICES BY CHOOSING A MODEL PROVIDER OPTION
// THIS WILL ADD AND CONFIGURE THE KERNEL FOR THE CHOSEN MODEL PROVIDER, AND
// ALSO REGISTER A NAMED HTTP CLIENT FOR LOCAL MODEL PROVIDERS FOR OBTAINING STATUS AND MODEL INFO
builder.Services.RegisterSemanticKernelServices(builder.Configuration, options =>
{
    options.ModelProvider = LanguageModelProviderOptions.LMStudio_Model_Provider;
    // options.ModelProvider = LanguageModelProviderOptions.Ollama_Model_Provider;
    // options.ModelProvider = LanguageModelProviderOptions.Grok_Model_Provider;
    // options.ModelProvider = LanguageModelProviderOptions.OpenAI_Model_Provider;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(SemanticAgents.Client._Imports).Assembly);

app.Run();
