namespace ProductApp.Application;

public static class ConfigureService
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddMediatR(opt => opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        return services;
    }
}