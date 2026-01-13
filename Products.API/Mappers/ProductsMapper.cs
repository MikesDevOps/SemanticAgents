using Products.API.Abstractions;
using Products.API.Domain.Models;
using Products.API.DTOs;
using System;

namespace Products.API.Mappers
{
    public class ProductsMapper : IProductsMapper
    {
        public ImageDataDTO MapImageDataToDTO(ImageData imageData)
        {
            return new ImageDataDTO(imageData.Name, imageData.Caption, imageData.SequenceNumber, imageData.ImageUrl, imageData.ThumbnailUrl);
        }

        public DocumentDataDTO MapDocumentDataToDTO(DocumentData documentData)
        {
            return new DocumentDataDTO(documentData.Name, documentData.Title, documentData.SequenceNumber, documentData.DocumentUrl);
        }

        public ProductDTO MapProductToDTO(Product product)
        {
            List<ImageDataDTO> imageDTOs = new List<ImageDataDTO>();
            product.Images?.ForEach(i => imageDTOs.Add(MapImageDataToDTO(i)));
            List<DocumentDataDTO> documentDTOs = new List<DocumentDataDTO>();
            product.Documents?.ForEach(d => documentDTOs.Add(MapDocumentDataToDTO(d)));

            return new ProductDTO()
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category.ToString(),
                Description = product.Description,
                Price = product.Price,
                Currency = product.Currency,
                Status = product.Status,
                Images = imageDTOs,
                Documents = documentDTOs,
                QuantityOnHand = product.QuantityOnHand,
                QuantityAllocated = product.QuantityAllocated,
                UOM = product.UOM,
                LowStockThreshold = product.LowStockThreshold,
                Version = product.Version,
                DateCreated = product.DateCreated,
                DateUpdated = product.DateUpdated
            };
        }

        public IEnumerable<ProductDTO> MapProductCollectionToDTOs(IEnumerable<Product> products)
        {
            List<ProductDTO> productsDTOs = new List<ProductDTO>();
            foreach (Product product in products)
            {
                ProductDTO productDTO = MapProductToDTO(product);
                productsDTOs.Add(productDTO);
            }

            return productsDTOs;
        }
    }
}
