using Products.API.Domain.Models;
using Products.API.DTOs;

namespace Products.API.Abstractions
{
    public interface IProductsMapper
    {
        ImageDataDTO MapImageDataToDTO(ImageData imageData);
        DocumentDataDTO MapDocumentDataToDTO(DocumentData documentData);
        ProductDTO MapProductToDTO(Product product);
        IEnumerable<ProductDTO> MapProductCollectionToDTOs(IEnumerable<Product> products);
    }
}
