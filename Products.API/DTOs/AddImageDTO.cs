namespace Products.API.DTOs
{
    public class AddImageDTO
    {
        public string Id { get; set; }
        public string FileName { get; set; }           // virtual directory plus filename
        public string Caption { get; set; }
        public string ImageUrl { get; set; }
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
