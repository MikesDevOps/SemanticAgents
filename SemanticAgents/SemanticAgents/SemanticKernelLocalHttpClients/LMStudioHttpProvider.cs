using SemanticAgents.Abstractions;
using SemanticAgents.Client.Utility;
using SemanticAgents.SemanticKernelDTOs;
using System.Text.Json;

namespace SemanticAgents.SemanticKernelLocalHttpClients
{
    public class LMStudioHttpProvider : ILMStudioHttpProvider
    {
        private readonly IHttpClientFactory _httpClientFactory;
        
        public LMStudioHttpProvider(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<(bool IsSuccess, IEnumerable<LMStudioModelDTO>? LoadedModels, string? ErrorMessage)> GetLMStudioLoadedModelsAsync()
        {
            try
            {
                string uri = $"{StaticData.LMStudioHttpClient_LoadedModelsPath}";
                var client = _httpClientFactory.CreateClient(StaticData.LMStudioHttpClient_Name);
                using (var response = await client.GetAsync(uri))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var modelList = await response.Content.ReadFromJsonAsync<LMStudioModelListDTO>();
                        return (true, modelList?.Data, null);
                    }
                    else
                    {
                        return (false, null, $"Failed to get loaded models from LM Studio.");
                    }
                }
            }
            catch (HttpRequestException httpReqEx)
            {
                Console.WriteLine($"ERROR: The targeted model could not be reached. Please ensure an LM Studio Model is loaded and running.\nMessage: {httpReqEx.Message}");
                return (false, null, $"The model could not be reached. Please ensure an LM Studio Model is loaded and running.");
            }
        }
    }
}

