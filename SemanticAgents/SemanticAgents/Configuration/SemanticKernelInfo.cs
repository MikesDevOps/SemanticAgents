namespace SemanticAgents.Configuration
{
    /// <summary>
    /// for lightweight cascading value in blazor apps
    /// </summary>
    public class SemanticKernelInfo
    {
        public string? ModelProvider { get; set; } = "Check Configuration";

        public string? LoadedModelId { get; set; } 
    }
}
