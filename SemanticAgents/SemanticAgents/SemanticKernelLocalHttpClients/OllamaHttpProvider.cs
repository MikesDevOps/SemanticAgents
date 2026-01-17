using SemanticAgents.Abstractions;
using SemanticAgents.Client.Utility;
using SemanticAgents.SemanticKernelDTOs;
using System.Text.Json;

namespace SemanticAgents.SemanticKernelLocalHttpClients
{
    public class OllamaHttpProvider : IOllamaHttpProvider
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OllamaHttpProvider(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<(bool IsSuccess, IEnumerable<OllamaModelDTO>? LoadedModels, string? ErrorMessage)> GetOllamaLoadedModelsAsync()
        {
            Console.WriteLine($"OllamaHttpProvider getting Ollama's loaded models...");
            try
            {
                string uri = $"{StaticData.OllamaHttpClient_LoadedModelsPath}";
                var client = _httpClientFactory.CreateClient(StaticData.OllamaoHttpClient_Name);
                using (var response = await client.GetAsync(uri))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var modelList = await response.Content.ReadFromJsonAsync<OllamaModelListDTO>();

                        string jsonModelList = JsonSerializer.Serialize(modelList);
                        Console.WriteLine($"HttpClient Ollama Loaded Models:  {jsonModelList}");

                        if (modelList?.Models is not null && modelList.Models.Any())
                        {
                            foreach (var model in modelList.Models)
                            {
                                Console.WriteLine($"MODEL NAME: {model.Model}");
                            }
                        }

                        return (true, modelList?.Models, null);
                    }
                    else
                    {
                        string errorContent = await response.Content.ReadAsStringAsync();
                        return (false, null, errorContent);     // $"Failed to get loaded models from Ollama.");
                    }
                }
            }
            catch (HttpRequestException httpReqEx)
            {
                Console.WriteLine($"ERROR: The targeted model could not be reached. Please ensure an Ollama Model is loaded and running, and also ensure the Ollama app is running with models exposed to the local network!\nMessage: {httpReqEx.Message}");
                return (false, null, $"The model could not be reached. Please ensure an Ollama Model is loaded and running, and also ensure the Ollama app is running with models exposed to the local network!");
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
        }
    }
}
