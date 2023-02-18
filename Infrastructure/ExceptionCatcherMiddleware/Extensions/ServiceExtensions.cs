using Infrastructure.ExceptionCatcherMiddleware.ExceptionSerializer;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.ExceptionCatcherMiddleware.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddExceptionCatcherMiddleware(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IExceptionSerializer, ExceptionSerializer.ExceptionSerializer>();
        serviceCollection.AddScoped<ExceptionCatcherMiddleware>();

        return serviceCollection;
    }
}