using System.ComponentModel;

namespace Products.API.DTOs
{
    [Description("An object which contains the properties of a Product object.")]
    public class ProductDTO
    {
        [Description("The Id property of the ProductDTO.")]
        public string? Id { get; init; }
        [Description("The Name property of the ProductDTO.")]
        public string? Name { get; init; }
        [Description("The Category property of the ProductDTO.")]
        public string? Category { get; init; }
        [Description("The Description property of the ProductDTO.")]
        public string? Description { get; init; }
        [Description("The Price property of the ProductDTO.")]
        public decimal Price { get; init; }
        [Description("The Currency property of the ProductDTO.")]
        public string? Currency { get; init; }
        [Description("The Status property of the ProductDTO.")]
        public string? Status { get; init; }
        [Description("The QuantityOnHand property of the ProductDTO.")]
        public int QuantityOnHand { get; init; }
        [Description("The QuantityAllocated property of the ProductDTO.")]
        public int QuantityAllocated { get; init; }
        [Description("The UOM property of the ProductDTO.")]
        public string? UOM { get; init; }
        [Description("The LowStockThreshold property of the ProductDTO.")]
        public int LowStockThreshold { get; init; }
        [Description("The Version property of the ProductDTO.")]
        public int Version { get; init; }
        [Description("The DateCreated property of the ProductDTO.")]
        public DateTime DateCreated { get; init; }
        [Description("The DateUpdated property of the ProductDTO.")]
        public DateTime DateUpdated { get; init; }
        [Description("The Images property of the ProductDTO that contains a collection of ImageDataDTO objects.")]
        public List<ImageDataDTO>? Images { get; init; }
        [Description("The Documents property of the ProductDTO that contains a collection of DocumentDataDTO objects.")]
        public List<DocumentDataDTO>? Documents { get; init; }

    }
}
