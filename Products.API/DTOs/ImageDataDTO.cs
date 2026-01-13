using System.ComponentModel;

namespace Products.API.DTOs
{
    [Description("An object which contains the properties of a ImageData object.")]
    public class ImageDataDTO
    {
        [Description("The FileName property of the ImageDataDTO.")]
        public string? FileName { get; private set; }
        [Description("The Caption property of the ImageDataDTO.")]
        public string? Caption { get; private set; }
        [Description("The SequenceNumber property of the ImageDataDTO.")]
        public int SequenceNumber { get; private set; }
        [Description("The ImageUrl property of the ImageDataDTO.")]
        public string? ImageUrl { get; private set; }
        [Description("The ThumbnailUrl property of the ImageDataDTO.")]
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
