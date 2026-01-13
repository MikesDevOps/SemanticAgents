using Products.API.DTOs;

namespace Products.API.Domain.Models
{
    public class ImageData
    {
        public string Name { get; private set; }           // virtual directory plus filename
        public string Caption { get; private set; }
        public int SequenceNumber { get; private set; }
        public string ImageUrl { get; private set; }
        public string ThumbnailUrl { get; private set; }


        public ImageData(string name, string caption, int sequenceNumber, string imageUrl, string thumbnailUrl)
        {
            Name = name;
            Caption = caption;
            SequenceNumber = sequenceNumber;
            ImageUrl = imageUrl;
            ThumbnailUrl = thumbnailUrl;
        }

        public ImageDataDTO ToDTO()
        {
            return new ImageDataDTO(Name, Caption, SequenceNumber, ImageUrl, ThumbnailUrl);
        }
    }
}
