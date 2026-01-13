using Products.API.Domain.Models;

namespace Products.API.Abstractions
{
    public interface IProductRepository
    {
        Task<bool> PurgeAndSeedDataAsync();
        Task<Product?> GetProductByIdAsync(string id);
        Task<IEnumerable<Product>> GetProductsAsync(string? category = null);
        Task<string?> AddAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> UpdateStatusAsync(string id, string status);
        Task<bool> AddImageAsync(string id, string filename, string caption, string imageUrl, string thumbnailUrl);
        Task<bool> AddDocumentAsync(string id, string filename, string title, string documentUrl);
        Task<bool> DeleteImageAsync(string id, string filename);
        Task<bool> DeleteDocumentAsync(string id, string filename);
        Task<bool> DeleteProdcutAsync(string id);
    }
}
