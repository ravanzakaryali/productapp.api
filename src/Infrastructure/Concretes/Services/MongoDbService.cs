namespace ProductApp.Infrastructure.Services;

public class MongoDbService<TCollection>(IMongoDatabase database) : IMongoDbService<TCollection> where TCollection : class
{
    private readonly IMongoDatabase _database = database;

    public IMongoCollection<TCollection> GetCollection(string name)
    {
        return _database.GetCollection<TCollection>(name);
    }
}