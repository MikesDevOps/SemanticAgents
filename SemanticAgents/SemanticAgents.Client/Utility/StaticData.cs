namespace SemanticAgents.Client.Utility
{
    public class StaticData
    {
        // OPEN AI
        public const string OpenAI_TextModel_gpt3_5_Turbo = "gpt-3.5-turbo";
        public const string OpenAI_TextModel_gpt_4o = "gpt-4o";
        public const string OpenAI_TextModel_gpt_5 = "gpt-5";
        public const string OpenAI_ImageModel_dall_e_3 = "dall-e-3";
        public const string OpenAI_ImageModel_gpt_image_1 = "gpt-image-1";
        public const string OpenAI_ImageModel_gpt_4o = "gpt-4o";

        public const string OpenAI_EmbeddingModel_ada_002 = "text-embedding-ada-002";
        public static List<string> OpenAI_TextModels = new List<string>
        {
            OpenAI_TextModel_gpt3_5_Turbo, OpenAI_TextModel_gpt_4o, OpenAI_TextModel_gpt_5
        };
        public static List<string> OpenAI_ImageModels = new List<string>
        {
            OpenAI_ImageModel_dall_e_3, OpenAI_ImageModel_gpt_image_1, OpenAI_ImageModel_gpt_4o
        };

        // LM STUDIO
        public const string LMStudio_LocalModelId_gpt_oss_20b = "openai/gpt-oss-20b";
        public const string LMStudio_LocalModelId_ministral_3_14b_reasoning = "mistralai/ministral-3-14b-reasoning";
        public const string LMStudio_LocalModelId_phi4 = "phi-4";
        public const string LMStudio_LocalModelId_llama3_2 = "llama-3.2-3b-instruct";
        public static List<string> LMStudio_TextModels = new List<string>
        {
            LMStudio_LocalModelId_gpt_oss_20b, LMStudio_LocalModelId_ministral_3_14b_reasoning, LMStudio_LocalModelId_phi4, LMStudio_LocalModelId_llama3_2
        };
        public const string LMStudio_Endpoint = "http://localhost:1234/v1";

        // OLLAMA
        public const string Ollama_LocalModelId_phi3_Mini = "phi3:mini";
        public const string Ollama_LocalModelId_deepseek_r1_14b = "deepseek-r1:14b";
        public const string Ollama_LocalModelId_gpt_oss_20b = "gpt-oss:20b";
        public const string Ollama_LocalModelId_gemma3_27b = "gemma3:27b";
        public const string Ollama_CodingModelId_devstral_small_2_24b = "devstral-small-2:24b";
        public const string Ollama_CodingModelId_qwen3_coder_30b = "qwen3-coder:30b";

        public static List<string> Ollama_TextModels = new List<string>
        {
            Ollama_LocalModelId_phi3_Mini, Ollama_LocalModelId_deepseek_r1_14b, Ollama_LocalModelId_gpt_oss_20b, Ollama_LocalModelId_gemma3_27b, 
            Ollama_CodingModelId_devstral_small_2_24b, Ollama_CodingModelId_qwen3_coder_30b
        };
        public const string Ollama_Endpoint = "http://localhost:11434/v1";

        // GROK
        // public const string Grok_TextModel_Grok_2 = "grok-2";
        // public const string Grok_TextModel_Grok_Beta = "grok-beta";
        public const string Grok_TextModel_Grok_3_Mini = "grok-3-mini";
        public const string Grok_TextModel_Grok_3 = "grok-3";
        public const string Grok_TextModel_Grok_2_Vision_1212 = "grok-2-vision-1212";
        public const string Grok_TextModel_Grok_4_0709 = "grok-4-0709";
        public const string Grok_TextModel_Grok_4_Fast_Reasoning = "grok-4-fast-reasoning";
        public const string Grok_TextModel_Grok_4_1_Fast_Reasoning = "grok-4-1-fast-reasoning";
        public const string Grok_TextModel_Code_Fast_1 = "grok-code-fast-1";

        public static List<string> Grok_TextModels = new List<string>
        {
            Grok_TextModel_Grok_3_Mini, Grok_TextModel_Grok_3, Grok_TextModel_Grok_2_Vision_1212, Grok_TextModel_Grok_4_0709, 
            Grok_TextModel_Grok_4_Fast_Reasoning, Grok_TextModel_Grok_4_1_Fast_Reasoning, Grok_TextModel_Code_Fast_1, 
        };

        public const string Grok_ImageModel_Grok_2_Image_1212 = "grok-2-image-1212";
        public static List<string> Grok_ImageModels = new List<string>
        {
            Grok_ImageModel_Grok_2_Image_1212
        };
        public const string Grok_Endpoint = "https://api.x.ai/v1";   

        // HTTP CLIENTS
        public const string LMStudioHttpClient_Name = "LMStudioHttpClient";
        public const string LMStudioHttpClient_BaseUrl = "http://localhost:1234";
        public const string LMStudioHttpClient_LoadedModelsPath = "/api/v0/models";
        public const string LMStudioHttpClient_EnhancedLoadedModelsPath = "/api/v1/models";

        public const string OllamaoHttpClient_Name = "OllamaHttpClient";
        public const string OllamaHttpClient_BaseUrl = "http://localhost:11434/v1";
        public const string OllamaHttpClient_LoadedModelsPath = "/api/ps";
    }
}
