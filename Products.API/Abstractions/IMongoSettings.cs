namespace Products.API.Abstractions
{
    public interface IMongoSettings
    {
        string? MongoLocalConnection { get; }
        string? Database { get; }
        string? ProductsCollection { get; }
    }
}
