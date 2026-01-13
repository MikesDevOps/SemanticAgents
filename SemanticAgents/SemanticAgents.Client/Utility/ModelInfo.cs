namespace SemanticAgents.Client.Utility
{
    public class ModelInfo
    {
        public string Name { get; set; }
        public int ContextLengthK { get; set; }
        public string Quantization { get; set; }
        public int ParamsB { get; set; }
        public decimal DiskSpace { get; set; }
        public string Description { get; set; }
        public bool ToolUse { get; set; }
        public bool Reasoning { get; set; }
        public bool ImageInput { get; set; }

        public ModelInfo(string name, string quantization, int contextLengthK, int paramsB, decimal diskSpace, string description, bool toolUse, bool reasoning, bool imageInput)
        {
            Name = name;
            Quantization = quantization;
            ContextLengthK = contextLengthK;
            ParamsB = paramsB;
            DiskSpace = diskSpace;
            Description = description;
            ToolUse = toolUse;
            Reasoning = reasoning;
            ImageInput = imageInput;
        }
    }
}
