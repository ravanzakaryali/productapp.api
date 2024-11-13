namespace ProductApp.Application.Services;
public interface IMongoDbService<TCollection> where TCollection : class
{
    IMongoCollection<TCollection> GetCollection(string name);
}