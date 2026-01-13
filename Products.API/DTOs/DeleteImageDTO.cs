namespace Products.API.DTOs
{
    public class DeleteImageDTO
    {
        public string Id { get; set; }
        public string FileName { get; set; }           // virtual directory plus filename

        public DeleteImageDTO(string id, string filename)
        {
            Id = id;
            FileName = filename;
        }
    }
}
