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
        public const string LMStudio_LocalModelId_gpt_oss_20b = "gpt-oss-20b";
        public const string LMStudio_LocalModelId_ministral_3_14b_reasoning = "ministral-3-14b-reasoning";
        public const string LMStudio_LocalModelId_phi4 = "phi-4";
        public const string LMStudio_LocalModelId_llama3_2 = "llama-3.2-3b-instruct";
        public static List<string> LMStudio_TextModels = new List<string>
        {
            LMStudio_LocalModelId_gpt_oss_20b, LMStudio_LocalModelId_ministral_3_14b_reasoning, LMStudio_LocalModelId_phi4, LMStudio_LocalModelId_llama3_2
        };
        public const string LMStudio_Endpoint = "http://localhost:1234/v1";

        // OLLAMA
        public const string Ollama_LocalModelId_phi3_Mini = "phi3:mini";
        public static List<string> Ollama_TextModels = new List<string>
        {
            Ollama_LocalModelId_phi3_Mini
        };
        public const string Ollama_Endpoint = "http://localhost:11434/v1";
        public const string Ollama_LoadedModelsPath = "/api/ps";

        // GROK
        public const string Grok_TextModel_Grok_2 = "grok-2";
        public const string Grok_TextModel_Grok_Beta = "grok-beta";
        public const string Grok_TextModel_Grok_3_Mini = "grok-3-mini";
        public const string Grok_TextModel_Grok_3_Mini_Fast = "grok-3-mini-fast";
        public const string Grok_TextModel_Grok_2_Vision_1212us_East_1 = "grok-2-vision-1212us-east-1";
        public const string Grok_TextModel_Grok_2_Vision_1212us_West_1 = "grok-2-vision-1212us-west-1";
        public const string Grok_TextModel_Grok_3 = "grok-3";
        public const string Grok_TextModel_Grok_4_0709 = "grok-4-0709";
        public const string Grok_TextModel_Grok_3_FastUS_East_1 = "grok-3-fastus-east-1";
        public const string Grok_TextModel_Grok_3_FastEU_West_1 = "grok-3-fasteu-west-1";

        public static List<string> Grok_TextModels = new List<string>
        {
            Grok_TextModel_Grok_2, Grok_TextModel_Grok_Beta, Grok_TextModel_Grok_3_Mini, Grok_TextModel_Grok_3_Mini_Fast,
            Grok_TextModel_Grok_2_Vision_1212us_East_1, Grok_TextModel_Grok_2_Vision_1212us_West_1, Grok_TextModel_Grok_3,
            Grok_TextModel_Grok_4_0709, Grok_TextModel_Grok_3_FastUS_East_1, Grok_TextModel_Grok_3_FastEU_West_1
        };

        public const string Grok_ImageModel_Grok_2_Image_1212 = "grok-2-image-1212";
        public static List<string> Grok_ImageModels = new List<string>
        {
            Grok_ImageModel_Grok_2_Image_1212
        };
        // public const string Grok_Endpoint = "https://api.x.ai/v1";   // in user secrets

        // HTTP CLIENTS
        public const string LMStudioHttpClient_Name = "LMStudioHttpClient";
        public const string LMStudioHttpClient_BaseUrl = "http://localhost:1234";
        public const string LMStudioHttpClient_LoadedModelsPath = "/api/v0/models";

        public const string OllamaoHttpClient_Name = "OllamaHttpClient";
        public const string OllamaHttpClient_BaseUrl = "http://localhost:11434/v1";
        public const string OllamaHttpClient_LoadedModelsPath = "/api/ps";
    }
}
