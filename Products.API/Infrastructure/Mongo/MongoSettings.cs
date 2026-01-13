using Products.API.Abstractions;

namespace Products.API.Infrastructure.Mongo
{
    public class MongoSettings : IMongoSettings
    {
        public string? MongoLocalConnection { get; set; }
        public string? Database { get; set; }
        public string? ProductsCollection { get; set; }
    }
}
