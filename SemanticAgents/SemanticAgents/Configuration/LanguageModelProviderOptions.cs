
namespace SemanticAgents.Configuration
{
    /// <summary>
    /// Used for strongly typed options in configuring Semantic Kernel in Program.cs (see ComponentRoot.cs)
    /// </summary>
    public class LanguageModelProviderOptions
    {
        // these are possible string value constants for the model provider
        public const string OpenAI_Model_Provider = "OpenAI";
        public const string Grok_Model_Provider = "Grok";
        public const string LMStudio_Model_Provider = "LMStudio";
        public const string Ollama_Model_Provider = "Ollama";

        // this is the assignable model provider property
        public string ModelProvider { get; set; } = OpenAI_Model_Provider;
    }
}


