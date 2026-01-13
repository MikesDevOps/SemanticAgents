using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Products.API.Abstractions;
using Products.API.Domain.Models;
using Products.API.Utility;

namespace Products.API.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _products;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(IMongoSettings mongoSettings, ILogger<ProductRepository> logger)
        {
            var client = new MongoClient(mongoSettings.MongoLocalConnection);
            var database = client.GetDatabase(mongoSettings.Database);
            _products = database.GetCollection<Product>(mongoSettings.ProductsCollection);
            _logger = logger;
        }

        public async Task<bool> PurgeAndSeedDataAsync()
        {
            await _products.DeleteManyAsync(p => true);
            IEnumerable<Product> products = SeedData.Products;
            await _products.InsertManyAsync(products);
            return true;
        }

        public async Task<Product?> GetProductByIdAsync(string id)
        {
            Product? product = await _products.Find(p => p.Id == id).FirstOrDefaultAsync();
            return product; 
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(string? category = null)
        {
            IQueryable<Product> query = _products.AsQueryable();
            if (category is not null)
            {
                // CategoryEnum catEnum = (CategoryEnum) Enum.Parse(typeof(CategoryEnum), category);
                query = query.Where(p => p.Category.ToString() == category);
            }
            return await query.ToListAsync();
        }

        public async Task<string?> AddAsync(Product product)
        {
            await _products.InsertOneAsync(product);
            return product.Id;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            var updateResult = await _products.ReplaceOneAsync(p => p.Id == product.Id, product);
            return updateResult.ModifiedCount > 0;
        }

        public async Task<bool> UpdateStatusAsync(string id, string status)
        {
            Product product = await _products.Find(p => p.Id == id).FirstOrDefaultAsync();
            if (product is null) return false;
            product.UpdateStatus(status);
            var updateResult = await _products.ReplaceOneAsync(p => p.Id == product.Id, product);
            return updateResult.ModifiedCount > 0;
        }

        public async Task<bool> AddImageAsync(string id, string filename, string caption, string imageUrl, string thumbnailUrl)
        {
            Product? product = await _products.Find(p => p.Id == id).FirstOrDefaultAsync();
            if (product is null) return false;
            product.AddImage(filename, caption, imageUrl, thumbnailUrl);
            var updateResult = await _products.ReplaceOneAsync(p => p.Id == product.Id, product);
            return updateResult.ModifiedCount > 0;
        }

        public async Task<bool> AddDocumentAsync(string id, string filename, string title, string documentUrl)
        {
            Product? product = await _products.Find(p => p.Id == id).FirstOrDefaultAsync();
            if (product is null) return false;
            product.AddDocument(filename, title, documentUrl);
            var updateResult = await _products.ReplaceOneAsync(p => p.Id == product.Id, product);
            return updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteImageAsync(string id, string filename)
        {
            Product? product = await _products.Find(p => p.Id == id).FirstOrDefaultAsync();
            if (product is null) return false;
            product.DeleteImage(filename);
            var updateResult = await _products.ReplaceOneAsync(p => p.Id == product.Id, product);
            return updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteDocumentAsync(string id, string filename)
        {
            Product? product = await _products.Find(p => p.Id == id).FirstOrDefaultAsync();
            if (product is null) return false;
            product.DeleteDocument(filename);
            var updateResult = await _products.ReplaceOneAsync(p => p.Id == product.Id, product);
            return updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteProdcutAsync(string id)
        {
            var deleteResult = await _products.DeleteOneAsync(p => p.Id == id);
            return deleteResult.DeletedCount > 0;
        }
    }
}
