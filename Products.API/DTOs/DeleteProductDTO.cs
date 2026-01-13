using System.ComponentModel;

namespace Products.API.DTOs
{
    [Description("An object which provides the properties needed to delete a Product from the database.")]
    public class DeleteProductDTO
    {
        [Description("The Id property of the Product to delete.")]
        public string Id { get; set; }
        [Description("The Name property of the Product to delete.")]
        public string? Name { get; set; }

        public DeleteProductDTO(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
