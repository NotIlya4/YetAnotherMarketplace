using ExceptionCatcherMiddleware.Extensions;
using Infrastructure.ExceptionMapping;
using Infrastructure.Repositories;
using StackExchange.Redis;

namespace Api.Extensions;

public static class DiExtensions
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBasketRepository, BasketRepository>();
    }

    public static void AddRedis(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton(c =>
        {
            var config = ConfigurationOptions.Parse(connectionString, true);
            return ConnectionMultiplexer.Connect(config);
        });
    }

    public static void AddExceptionMappers(this IServiceCollection services)
    {
        services.AddScoped<EntityNotFoundExceptionMapper>();
        services.AddExceptionCatcherMiddlewareServices(builder =>
        {
            builder.RegisterExceptionMapper<EntityNotFoundException, EntityNotFoundExceptionMapper>();
        });
    }
}