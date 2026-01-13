namespace SemanticAgents.Client.Configuration
{
    public class ClientConfigurationSettings
    {
        public const string SectionName = "ClientConfigurationSettings";
        public string? TestValue { get; set; }
        public string? LocalAPIBaseAddress { get; set; }
    }
}
