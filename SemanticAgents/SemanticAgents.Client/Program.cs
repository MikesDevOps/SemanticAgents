using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MusicAgent.Blazor.Client.Services;
using SemanticAgents.Client.Abstractions;
using SemanticAgents.Client.Configuration;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddScoped<IToastrService, ToastrService>();

builder.Services.AddKeyedScoped<HttpClient>("LocalAPIClientFromWASM",
    (sp, key) =>
       new HttpClient
       {
           BaseAddress = new Uri(builder.Configuration["LocalAPIBaseAddress"] ??
                throw new Exception("LocalAPIBaseAddress is missing."))
       });

builder.Services.AddOptions<ClientConfigurationSettings>().Configure<IConfiguration>((options, config) =>
{
    config.GetRequiredSection(ClientConfigurationSettings.SectionName).Bind(options);
});

await builder.Build().RunAsync();
