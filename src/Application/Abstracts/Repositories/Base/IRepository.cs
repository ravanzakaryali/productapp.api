namespace ProductApp.Abstracts.Repositories;
public interface IRepository<T> where T : class
{
    Task InsertAsync(T entity);
    Task<T?> GetByIdAsync(string id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task UpdateAsync(string id, T entity);
    Task DeleteAsync(string id);
}
