namespace Products.API.DTOs
{
    public class UpdateProductDTO
    {
        public string Id { get; init; }
        public string? Name { get; init; }
        public string? Category { get; init; }
        public string? Description { get; init; }
        public decimal Price { get; init; }
        public string? Currency { get; init; }
        public string? Status { get; init; }
        public int QuantityOnHand { get; init; }
        public int QuantityAllocated { get; init; }
        public string? UOM { get; init; }
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
