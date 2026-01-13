namespace Products.API.DTOs
{
    public class ImageDataDTO
    {
        public string? FileName { get; private set; }           // virtual directory plus filename
        public string? Caption { get; private set; }
        public int SequenceNumber { get; private set; }
        public string? ImageUrl { get; private set; }
        public string? ThumbnailUrl { get; private set; }

        public ImageDataDTO(string filename, string caption, int sequenceNumber, string imageUrl, string? thumbnailUrl)
        {
            FileName = filename;
            Caption = caption;
            SequenceNumber = sequenceNumber;
            ImageUrl = imageUrl;
            ThumbnailUrl = thumbnailUrl;
        }
    }
}
