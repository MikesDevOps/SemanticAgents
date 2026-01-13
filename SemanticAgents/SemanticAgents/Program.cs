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
