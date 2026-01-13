using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Products.API.DTOs;

namespace Products.API.Domain.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public CategoryEnum? Category { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Currency { get; set; }
        public string? Status { get; set; }
        public List<ImageData>? Images { get; set; }
        public List<DocumentData>? Documents { get; set; }
        // inventory awareness
        public int QuantityOnHand { get; set; }
        public int QuantityAllocated { get; set; }
        public string? UOM { get; set; }
        public int LowStockThreshold { get; set; }
        public int Version { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public Product(string name, CategoryEnum category, string description, decimal price, string currency, string status,
            int quantityOnHand, string uom, int lowStockThreshold)
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
            Version = 0;
            DateCreated = DateTime.Now;
        }

        public void UpdateStatus(string status)
        {
            Status = status;
            Version = Version + 1;
            DateUpdated = DateTime.Now;
        }

        public void AddImage(string filename, string caption, string imageUrl, string thumbnailUrl)
        {
            ImageData? existing = Images?.FirstOrDefault(i => i.Name == filename);
            if (existing is not null) return;
            int maxSequenceNumber = MaxImageSequenceNumber;
            // CONSIDER REINDEXING SEQUENCE NUMBERS IN CASE DELETION LEFT GAPS
            ImageData image = new ImageData(filename, caption!, maxSequenceNumber + 1, imageUrl!, thumbnailUrl!);
            if (Images is null) Images = new List<ImageData>();
            Images.Add(image);
            Version = Version + 1;
            DateUpdated = DateTime.Now;
        }

        public void AddDocument(string filename, string title, string documentUrl)
        {
            DocumentData? existing = Documents?.FirstOrDefault(d => d.Name == filename);
            if (existing is not null) return;
            int maxSequenceNumber = MaxDocumentSequenceNumber;
            // CONSIDER REINDEXING SEQUENCE NUMBERS IN CASE DELETION LEFT GAPS
            DocumentData doc = new DocumentData(filename, title!, maxSequenceNumber + 1, documentUrl!);
            if (Documents is null) Documents = new List<DocumentData>();
            Documents.Add(doc);
            Version = Version + 1;
            DateUpdated = DateTime.Now;
        }

        public void DeleteImage(string filename)
        {
            if (Images is null) return;
            ImageData? image = Images.FirstOrDefault(d => d.Name == filename);
            if (image is not null) Images.Remove(image);
            Version = Version + 1;
            DateUpdated = DateTime.Now;
        }

        public void DeleteDocument(string filename)
        {
            if (Documents is null) return;
            DocumentData? doc = Documents.FirstOrDefault(d => d.Name == filename);
            if (doc is not null) Documents.Remove(doc);
            Version = Version + 1;
            DateUpdated = DateTime.Now;
        }

        private int MaxImageSequenceNumber
        {
            get
            {
                if (Images is not null && Images.Any()) return Images.Max(i => i.SequenceNumber);
                return 0;
            }
        }

        private int MaxDocumentSequenceNumber
        {
            get
            {
                if (Documents is not null && Documents.Any()) return Documents.Max(i => i.SequenceNumber);
                return 0;
            }
        }

        public bool ImageFileNameExists(string filename) => Images is null ? false : Images.Where(d => d.Name == filename).Count() > 0;
        public bool DocumentFileNameExists(string filename) => Documents is null ? false : Documents.Where(d => d.Name == filename).Count() > 0;

        public ProductDTO ToDTO()
        {
            List<ImageDataDTO> imageDTOs = new List<ImageDataDTO>();
            Images?.ForEach(i => imageDTOs.Add(i.ToDTO()));
            List<DocumentDataDTO> documentDTOs = new List<DocumentDataDTO>();
            Documents?.ForEach(d => documentDTOs.Add(d.ToDTO()));

            return new ProductDTO()
            {
                Id = Id,
                Name = Name,
                Category = Category.ToString(),
                Description = Description,
                Price = Price,
                Currency = Currency,
                Status = Status,
                Images = imageDTOs,
                Documents = documentDTOs,
                QuantityOnHand = QuantityOnHand,
                QuantityAllocated = QuantityAllocated,
                UOM = UOM,
                LowStockThreshold = LowStockThreshold,
                Version = Version,
                DateCreated = DateCreated,
                DateUpdated = DateUpdated,
            };
        }
    }
}
