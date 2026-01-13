using SemanticAgents.SemanticKernelDTOs;

namespace SemanticAgents.Abstractions
{
    public interface IOllamaHttpProvider
    {
        Task<(bool IsSuccess, IEnumerable<OllamaModelDTO>? LoadedModels, string? ErrorMessage)> GetOllamaLoadedModelsAsync();
    }
}
