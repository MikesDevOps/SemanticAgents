using System.ComponentModel;

namespace Products.API.DTOs
{
    [Description("An object which provides the properties to be used to create a new Product instance.")]
    public class AddProductDTO
    {
        [Description($"The Name of the new Product.")]
        public string Name { get; init; }
        [Description($"The Category of the new Product.")]
        public string Category { get; init; }
        [Description($"A Description of the new Product.")]
        public string Description { get; init; }
        [Description($"The Price of the new Product.")]
        public decimal Price { get; init; }
        [Description($"The Currency in which the new Product's Price is given.")]
        public string Currency { get; init; }
        [Description($"The Status of the new Product.")]
        public string Status { get; init; }
        [Description($"The Quantity of the new Product that is On Hand at this time.")]
        public int QuantityOnHand { get; init; }
        [Description($"The Unit Of Measure of the new Product in which QuantityOnHand is given.")]
        public string UOM { get; init; }
        [Description($"The value of the Product's QuantityOnHand property at which more of the Product should be ordered or manufactured.")]
        public int LowStockThreshold { get; init; }

        public AddProductDTO(string name, string category, string description,
            decimal price, string currency, string status, int quantityOnHand,
            string uom, int lowStockThreshold)
        {
            Name = name;
            Category = category;
            Description = description;
            Price = price;
            Currency = currency;
            Status = status;
            QuantityOnHand = quantityOnHand;
            UOM = uom;
            LowStockThreshold = lowStockThreshold;
        }
    }
}
