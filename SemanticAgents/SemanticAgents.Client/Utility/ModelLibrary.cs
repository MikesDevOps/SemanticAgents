
namespace SemanticAgents.Client.Utility
{
    public class ModelLibrary
    {
        public static List<ModelInfo> Models = new List<ModelInfo>()
        { 
            new ModelInfo("openai/gpt-oss-20b", "MXFP4", 256, 20, 12.11m, "Designed for lower latency and local deployment,has 21B total parameters with only 3.6B active at a time. Capable of operating within 16GB of memory.", true, true, false),
            new ModelInfo("mistralai/ministral-3-14b-reasoning", "3", 256, 14, 9.12m, "Excels at complex, multi-step reasoning and dynamic problem-solving, making it ideal for math, coding, and STEM-related use cases.", true, true, true )

        };
    }
}
