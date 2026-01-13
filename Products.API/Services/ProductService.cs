using Products.API.Abstractions;
using Products.API.Domain.Models;
using Products.API.DTOs;

namespace Products.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IProductsMapper _mapper;
        private readonly ILogger<ProductService> _logger;   

        public ProductService(IProductRepository repo, IProductsMapper mapper, ILogger<ProductService> logger)
        {
            _repo = repo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<(bool IsSuccess, string? ErrorMessage)> PurgeAndSeedDataAsync()
        {
            bool success = await _repo.PurgeAndSeedDataAsync();
            if (success) return (true, null);
            return (false, $"An error occurred seeding the database");
        }

        public async Task<(bool IsSuccess, ProductDTO? Product, string? ErrorMessage)> GetProductByIdAsync(string id)
        {
            Product? product = await _repo.GetProductByIdAsync(id);
            if (product is null) return (false, null, $"A product with Id {id} was not found.");
            ProductDTO productDTO = _mapper.MapProductToDTO(product);
            return (true, productDTO, null);
        }

        public async Task<(bool IsSuccess, IEnumerable<ProductDTO>? Products, string? ErrorMessage)> GetProductsAsync(string? category = null)
        {
            IEnumerable<Product>? products = await _repo.GetProductsAsync(category);
            if (products is null) return (false, null, $"A product collection was not found.");
            IEnumerable<ProductDTO> productDTOs = _mapper.MapProductCollectionToDTOs(products);
            return (true, productDTOs, null);
        }

        public async Task<(bool IsSuccess, string? ProductId, string? ErrorMessage)> AddAsync(AddProductDTO addProductDTO)
        {
            CategoryEnum catEnum = (CategoryEnum)Enum.Parse(typeof(CategoryEnum), addProductDTO.Category);
            Product product = new Product(addProductDTO.Name, catEnum, addProductDTO.Description, addProductDTO.Price,
                addProductDTO.Currency, addProductDTO.Status, addProductDTO.QuantityOnHand, addProductDTO.UOM, addProductDTO.LowStockThreshold);
            string? productId = await _repo.AddAsync(product);
            if (!string.IsNullOrEmpty(productId)) return (true, productId, null);
            return (false, null, $"A problem occurred trying to add the new product.");
        }

        public async Task<(bool IsSuccess, string? ErrorMessage)> UpdateAsync(UpdateProductDTO updateProductDTO)
        {
            Product? product = await _repo.GetProductByIdAsync(updateProductDTO.Id);
            if (product is null) return (false, $"A product with Id {updateProductDTO.Id} was not found.");
            product.Name = updateProductDTO.Name;
            if (!string.IsNullOrWhiteSpace(updateProductDTO.Category)) product.Category = (CategoryEnum)Enum.Parse(typeof(CategoryEnum), updateProductDTO.Category);
            product.Description = updateProductDTO.Description;
            product.Price = updateProductDTO.Price;
            product.Currency = updateProductDTO.Currency;
            product.Status = updateProductDTO.Status;
            product.QuantityOnHand = updateProductDTO.QuantityOnHand;
            product.UOM = updateProductDTO.UOM;
            product.QuantityAllocated = updateProductDTO.QuantityAllocated;
            product.LowStockThreshold = updateProductDTO.LowStockThreshold;
            bool success = await _repo.UpdateAsync(product);
            if (success) return (true, null);
            return (false, $"A problem occurred trying to update the product.");
        }

        public async Task<(bool IsSuccess, string? ErrorMessage)> UpdateStatusAsync(UpdateStatusDTO updateStatusDTO)
        {
            bool success = await _repo.UpdateStatusAsync(updateStatusDTO.Id, updateStatusDTO.Status);
            if (success) return (true, null);
            return (false, $"A problem occurred trying to update the product's status.");
        }

        public async Task<(bool IsSuccess, string? ErrorMessage)> AddImageAsync(AddImageDTO addImageDTO)
        {
            bool success = await _repo.AddImageAsync(addImageDTO.Id, addImageDTO.FileName, addImageDTO.Caption, addImageDTO.ImageUrl, addImageDTO.ThumbnailUrl);
            if (success) return (true, null);
            return (false, $"A problem occurred trying to add the product image.");
        }

        public async Task<(bool IsSuccess, string? ErrorMessage)> AddDocumentAsync(AddDocumentDTO addDocumentDTO)
        {
            bool success = await _repo.AddDocumentAsync(addDocumentDTO.Id, addDocumentDTO.FileName, addDocumentDTO.Title, addDocumentDTO.DocumentUrl);
            if (success) return (true, null);
            return (false, $"A problem occurred trying to add the product document.");
        }
        public async Task<(bool IsSuccess, string? ErrorMessage)> DeleteImageAsync(DeleteImageDTO deleteImageDTO)
        {
            bool success = await _repo.DeleteImageAsync(deleteImageDTO.Id, deleteImageDTO.FileName);
            if (success) return (true, null);
            return (false, $"A problem occurred trying to delete the product image.");
        }

        public async Task<(bool IsSuccess, string? ErrorMessage)> DeleteDocumentAsync(DeleteDocumentDTO deleteDocumentDTO)
        {
            bool success = await _repo.DeleteDocumentAsync(deleteDocumentDTO.Id, deleteDocumentDTO.FileName);
            if (success) return (true, null);
            return (false, $"A problem occurred trying to delete the product document.");
        }

        public async Task<(bool IsSuccess, string? ErrorMessage)> DeleteProdcutAsync(DeleteProductDTO deleteProductDTO)
        {
            bool success = await _repo.DeleteProdcutAsync(deleteProductDTO.Id);
            if (success) return (true, null);
            return (false, $"A problem occurred trying to delete the product.");
        }
    }
}
