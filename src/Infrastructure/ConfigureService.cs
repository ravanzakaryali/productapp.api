namespace ProductApp.Infrastructure;

public static class ConfigureService
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddSingleton(
                            new MongoClient(configuration["MongoDB:ConnectionString"])
                            .GetDatabase(configuration["MongoDB:Database"]));

        services.AddScoped(typeof(IMongoDbService<>), typeof(MongoDbService<>));
        services.AddScoped<IProductRepository, ProductRepository>();
        
        return services;
    }
}