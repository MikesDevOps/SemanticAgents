namespace SemanticAgents.Configuration
{
    public class SemanticKernelSettings
    {
        public const string SectionName = "SemanticKernelSettings";

        // KEY AND/OR PROVIDER PATH
        public string? OpenAI_ApiKey { get; set; }
        public string? OpenAI_ApiKey_Old { get; set; }  // verify access terminated
        public string? Grok_ApiKey { get; set; }

        //public string? Grok_Endpoint { get; set; }   // check correct endpoint is = "https://api.x.ai/v1";
        //public string? LMStudio_Endpoint { get; set; }  
        //public string? Ollama_Endpoint { get; set; }  

        // DEFAULT TEXT MODEL ID
        //public string? OpenAI_TextModelId { get; set; }  
        //public string? Grok_TextModelId { get; set; }  
        //public string? LMStudio_TextModelId { get; set; }  
        //public string? Ollama_TextModelId { get; set; }

        // DEFAULT IMAGE MODEL ID
        //public string? OpenAI_ImageModelId { get; set; }
        //public string? Grok_ImageModelId { get; set; }

        //public string? LMStudio_ImageModelId { get; set; }
        //public string? Ollama_ImageModelId { get; set; }

    }
}