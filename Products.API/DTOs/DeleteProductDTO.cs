namespace Products.API.DTOs
{
    public class DeleteProductDTO
    {
        public string Id { get; set; }
        public string? Name { get; set; }

        public DeleteProductDTO(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
