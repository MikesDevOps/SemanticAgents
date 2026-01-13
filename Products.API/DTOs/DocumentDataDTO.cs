namespace Products.API.DTOs
{
    public class DocumentDataDTO
    {
        public string? FileName { get; private set; }           // for Azure blob storage, virtual directory plus filename
        public string? Title { get; private set; }
        public int SequenceNumber { get; private set; }
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
