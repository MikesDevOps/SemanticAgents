using Microsoft.AspNetCore.Components;
using Microsoft.SemanticKernel;
using MusicAgent.Blazor.Client.Services;
using SemanticAgents.Abstractions;
using SemanticAgents.Client.Abstractions;
using SemanticAgents.Client.Utility;
using SemanticAgents.Configuration;
using SemanticAgents.SemanticKernelLocalHttpClients;

namespace SemanticAgents
{
    public static class ComponentRoot
    {
        public static IServiceCollection RegisterSemanticKernelServices(this IServiceCollection services, IConfiguration config, Action<LanguageModelProviderOptions> optionsModifier)
        {
            // Configure Semantic Kernel based on LanguageModelProviderOptions.ModelProvider value
            var kernelOptions = new LanguageModelProviderOptions();
            optionsModifier(kernelOptions);

            if (kernelOptions.ModelProvider == LanguageModelProviderOptions.OpenAI_Model_Provider)
            {
                services.AddKernel()
                    .AddOpenAIChatCompletion(
                        modelId: StaticData.OpenAI_TextModel_gpt3_5_Turbo, // config.GetSection("SemanticKernelSettings").GetValue<string>("OpenAI_TextModelId")!,
                        apiKey: config.GetSection("SemanticKernelSettings").GetValue<string>("OpenAI_ApiKey")!)
                    .AddOpenAITextToImage(
                        apiKey: config.GetSection("SemanticKernelSettings").GetValue<string>("OpenAI_ApiKey")!,
                        modelId: StaticData.OpenAI_ImageModel_dall_e_3); //  config.GetSection("SemanticKernelSettings").GetValue<string>("OpenAI_ImageModelId")!);
            }
            else if (kernelOptions.ModelProvider == LanguageModelProviderOptions.Grok_Model_Provider)
            {
                // !!! VERIFY ENDPOINT SHOULD BE CONFIGURED AND THE CORRECT ENDPOINT IS WHAT IS PULLED FROM USER-SECRETS !!!
                services.AddKernel()
                    .AddOpenAIChatCompletion(
                        modelId: StaticData.Grok_TextModel_Grok_2, // config.GetSection("SemanticKernelSettings").GetValue<string>("Grok_TextModelId")!,
                        apiKey: config.GetSection("SemanticKernelSettings").GetValue<string>("Grok_ApiKey")!,
                        endpoint: new Uri(StaticData.Grok_Endpoint)); // new Uri(config.GetSection("SemanticKernelSettings").GetValue<string>("Grok_Endpoint")!));
            }
            else if (kernelOptions.ModelProvider == LanguageModelProviderOptions.LMStudio_Model_Provider)
            {
                services.AddKernel()
                    .AddOpenAIChatCompletion(
                        modelId: StaticData.LMStudio_LocalModelId_gpt_oss_20b, // config.GetSection("SemanticKernelSettings").GetValue<string>("LMStudio_TextModelId")!,
                        apiKey: null,
                        endpoint: new Uri(StaticData.LMStudio_Endpoint)); // new Uri(config.GetSection("SemanticKernelSettings").GetValue<string>("LMStudio_Endpoint")!));
            }
            else if (kernelOptions.ModelProvider == LanguageModelProviderOptions.Ollama_Model_Provider)
            {
                services.AddKernel()
                    .AddOpenAIChatCompletion(
                        modelId: StaticData.Ollama_LocalModelId_phi3_Mini, // config.GetSection("SemanticKernelSettings").GetValue<string>("Ollama_TextModelId")!,
                        apiKey: null,
                        endpoint: new Uri(StaticData.Ollama_Endpoint)); // new Uri(config.GetSection("SemanticKernelSettings").GetValue<string>("Ollama_Endpoint")!));
            }
            else throw new InvalidDataException("Invalid ModelProvider configured");

            // Register named HttpClient for Local Model Providers LMStudio and Ollama (query status/models)
            /// HTTP CLIENT FOR LMSTUDIO STATUS QUERIES
            services.AddHttpClient(name: StaticData.LMStudioHttpClient_Name, cfg =>
            {
                cfg.DefaultRequestHeaders.Clear();
                cfg.BaseAddress = new Uri(StaticData.LMStudioHttpClient_BaseUrl);
            });
            services.AddSingleton<ILMStudioHttpProvider, LMStudioHttpProvider>();
            // HTTP CLIENT FOR OLLAMA STATUS QUERIES
            services.AddHttpClient(name: StaticData.OllamaoHttpClient_Name, cfg =>
            {
                cfg.DefaultRequestHeaders.Clear();
                cfg.BaseAddress = new Uri(StaticData.OllamaHttpClient_BaseUrl);
            });
            services.AddSingleton<IOllamaHttpProvider, OllamaHttpProvider>();

            // Register the cascading value source to inject in the component for access to underlying source's NotifyChangedAsync() method
            services.AddScoped(sp =>
            {
                var kernelInfo = new SemanticKernelInfo() { ModelProvider = kernelOptions.ModelProvider };
                return new CascadingValueSource<SemanticKernelInfo>(name: "SemanticKernelInfo", kernelInfo, isFixed: false);
            });

            // Register the cascading value that will be the cascading parameter property on component pages by deriving from the source
            services.AddCascadingValue(sp => sp.GetRequiredService<CascadingValueSource<SemanticKernelInfo>>());

            // Register Toastr Service
            services.AddScoped<IToastrService, ToastrService>();

            return services;
        }


    }
}
