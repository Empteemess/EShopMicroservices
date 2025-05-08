namespace Catalog.Api.Configurations;

public static class MediatRConfig
{
    public static IServiceCollection AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssembly(typeof(MediatRConfig).Assembly);
        });
        
        return services;
    }
}