namespace ProductApp.Infrastructure.Repositories;

public class ProductRepository(IMongoDatabase database) : Repository<Product>(database, "Products"), IProductRepository
{
}
