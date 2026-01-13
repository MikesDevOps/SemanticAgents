namespace Products.API.DTOs
{
    public class DeleteDocumentDTO
    {
        public string Id { get; set; }
        public string FileName { get; set; }           // virtual directory plus filename
        
        public DeleteDocumentDTO(string id, string filename)
        {
            Id = id;
            FileName = filename;
        }
    }
}
