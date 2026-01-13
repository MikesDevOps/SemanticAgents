using System.ComponentModel;

namespace Products.API.DTOs
{
    [Description("An object which contains the properties of a DocumentData object.")]
    public class DocumentDataDTO
    {
        [Description("The FileName property of the DocumentDataDTO.")]
        public string? FileName { get; private set; }
        [Description("The Title property of the DocumentDataDTO.")]
        public string? Title { get; private set; }
        [Description("The SequenceNumber property of the DocumentDataDTO.")]
        public int SequenceNumber { get; private set; }
        [Description("The DocumentUrl property of the DocumentDataDTO.")]
        public string? DocumentUrl { get; private set; }

        public DocumentDataDTO(string filename, string title, int sequenceNumber, string documentUrl)
        {
            FileName = filename;
            Title = title;
            SequenceNumber = sequenceNumber;
            DocumentUrl = documentUrl;
        }
    }
}
