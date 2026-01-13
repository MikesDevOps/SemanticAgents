using System.ComponentModel;

namespace Products.API.DTOs
{
    [Description("An object which contains the properties used to update the properties of a Product in the database.")]
    public class UpdateProductDTO
    {
        [Description("The Id property of the Product to be updated.")]
        public string Id { get; init; }
        [Description("The Name property to use for the Product to be updated.")]
        public string? Name { get; init; } 
        [Description("The Category property to use for the Product to be updated converted from an enum to a string.")]
        public string? Category { get; init; }
        [Description("The Description property to use for the Product to be updated.")]
        public string? Description { get; init; }
        [Description("The Price property to use for the Product to be updated.")]
        public decimal Price { get; init; }
        [Description("The Currency property to use for the Product to be updated.")]
        public string? Currency { get; init; }
        [Description("The Status property to use for the Product to be updated.")]
        public string? Status { get; init; }
        [Description("The QuantityOnHand property to use for the Product to be updated.")]
        public int QuantityOnHand { get; init; }
        [Description("The QuantityAllocated property to use for the Product to be updated.")]
        public int QuantityAllocated { get; init; }
        [Description("The UOM property to use for the Product to be updated.")]
        public string? UOM { get; init; }
        [Description("The LowStockThreshold property to use for the Product to be updated.")]
        public int LowStockThreshold { get; init; }

        public UpdateProductDTO(string id, string? name, string? category, string? description, decimal price, string? currency, string? status, int quantityOnHand, int quantityAllocated, string? uOM, int lowStockThreshold)
        {
            Id = id;
            Name = name;
            Category = category;
            Description = description;
            Price = price;
            Currency = currency;
            Status = status;
            QuantityOnHand = quantityOnHand;
            QuantityAllocated = quantityAllocated;
            UOM = uOM;
            LowStockThreshold = lowStockThreshold;
        }
    }
}
