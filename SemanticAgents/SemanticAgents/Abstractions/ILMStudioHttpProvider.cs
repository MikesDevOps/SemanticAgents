using SemanticAgents.SemanticKernelDTOs;

namespace SemanticAgents.Abstractions
{
    public interface ILMStudioHttpProvider
    {
        Task<(bool IsSuccess, IEnumerable<LMStudioModelDTO>? LoadedModels, string? ErrorMessage)> GetLMStudioLoadedModelsAsync();
    }
}
