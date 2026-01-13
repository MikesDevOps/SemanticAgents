using Products.API.Domain.Models;
using Products.API.DTOs;

namespace Products.API.Abstractions
{
    public interface IProductService
    {
        Task<(bool IsSuccess, string? ErrorMessage)> PurgeAndSeedDataAsync();
        Task<(bool IsSuccess, ProductDTO? Product, string? ErrorMessage)> GetProductByIdAsync(string id);
        Task<(bool IsSuccess, IEnumerable<ProductDTO>? Products, string? ErrorMessage)> GetProductsAsync(string? category = null);
        Task<(bool IsSuccess, string? ProductId, string? ErrorMessage)> AddAsync(AddProductDTO addProductDTO);
        Task<(bool IsSuccess, string? ErrorMessage)> UpdateAsync(UpdateProductDTO updateProductDTO);
        Task<(bool IsSuccess, string? ErrorMessage)> UpdateStatusAsync(UpdateStatusDTO updateStatusDTO);
        Task<(bool IsSuccess, string? ErrorMessage)> AddImageAsync(AddImageDTO addImageDTO);
        Task<(bool IsSuccess, string? ErrorMessage)> AddDocumentAsync(AddDocumentDTO addDocumentDTO);
        Task<(bool IsSuccess, string? ErrorMessage)> DeleteImageAsync(DeleteImageDTO deleteImageDTO);
        Task<(bool IsSuccess, string? ErrorMessage)> DeleteDocumentAsync(DeleteDocumentDTO deleteDocumentDTO);
        Task<(bool IsSuccess, string? ErrorMessage)> DeleteProdcutAsync(DeleteProductDTO deleteProductDTO);
    }
}
