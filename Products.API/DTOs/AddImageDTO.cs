using System.ComponentModel;

namespace Products.API.DTOs
{
    [Description("An object which provides the properties for adding a new Image to a Product's Images property, which is " +
        $"a collection of ImageData objects.")]
    public class AddImageDTO
    {
        [Description("The Id property of the Product to which the new Image will be added. It is used to identify the specific Product " +
            "to which the Image will be added.")]
        public string Id { get; set; }
        [Description($"The File Name of the new Image.")]
        public string FileName { get; set; }
        [Description($"The Caption of the new Image.")]
        public string Caption { get; set; }
        [Description($"The URL of the new Image.")]
        public string ImageUrl { get; set; }
        [Description($"The URL of the a smaller version of the image.")]
        public string ThumbnailUrl { get; set; }

        public AddImageDTO(string id, string filename, string caption, string imageUrl, string thumbnailUrl)
        {
            Id = id;
            FileName = filename;
            Caption = caption;
            ImageUrl = imageUrl;
            ThumbnailUrl = thumbnailUrl;
        }
    }
}
