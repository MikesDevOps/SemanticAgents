using Products.API.Domain.Models;

namespace Products.API.Utility
{
    public class SeedData
    {
        public static List<Product> Products { get; set; } = new List<Product>()
        {
            new Product("Takahashi FX4", CategoryEnum.Astronomy, "4-inch Quadruplet Imager", 2499.95m, "USD", "Active", 3, "Each", 1),
            new Product("Blue Stratocaster", CategoryEnum.Music, "Blues Guitar", 1899.99m, "USD", "Active", 1, "Each", 0),
            new Product("14 inch Laptop", CategoryEnum.Computers, "Dell Business Computer", 1445.99m, "USD", "Active", 4, "Each", 1),
            new Product("A Guide for the Past", CategoryEnum.Books, "A book full of questionable advice", 249.99m, "USD", "Active", 3, "Each", 1),
            new Product("Canon R3", CategoryEnum.Photography, "Studio Digital SLR", 3495.00m, "USD", "Active", 1, "Each", 0)
        };
    }
}
