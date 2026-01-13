namespace SemanticAgents.SemanticKernelDTOs
{
    public class LMStudioModelDTO
    {
        public string? Id { get; set; }   // "id": "phi-4",
        public string? Object { get; set; }  // "object": "model",
        public string? Type { get; set; }     // "type": "llm",
        public string? Publisher { get; set; }    // "publisher": "lmstudio-community",
        public string? Arch { get; set; }     // "arch": "phi3",
        public string? CompatibilityType { get; set; }     //"compatibility_type": "gguf",
        public string? Quantization { get; set; }     // "quantization": "Q4_K_M",
        public string? State { get; set; }    // "state": "loaded",
        public float MaxContentLength { get; set; }     // "max_context_length": 16384,
        public float LoadedContextLength { get; set; }  // "loaded_context_length": 4096
    }
}
