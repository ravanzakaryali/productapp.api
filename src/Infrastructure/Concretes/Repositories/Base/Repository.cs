namespace ProductApp.Infrastructure.Repositories;

public class Repository<T>(IMongoDatabase database, string collectionName) : IRepository<T> where T : class
{
    private readonly IMongoCollection<T> _collection = database.GetCollection<T>(collectionName);

    public async Task InsertAsync(T entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public async Task<T?> GetByIdAsync(string id)
    {
        FilterDefinition<T> filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _collection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _collection.Find(predicate).ToListAsync();
    }

    public async Task UpdateAsync(string id, T entity)
    {
        FilterDefinition<T> filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
        
        await _collection.ReplaceOneAsync(filter, entity);
    }

    public async Task DeleteAsync(string id)
    {
        FilterDefinition<T> filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
        await _collection.DeleteOneAsync(filter);
    }
}
