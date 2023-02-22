using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers;
using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.Dispatchers;
using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.Dispatchers.DispatcherDependencies;
using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.Dispatchers.MappersReflection;
using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Middleware;
using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Options;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Extensions;

public static class DiExtensions
{
    public static void AddExceptionCatcherMiddlewareServices(this IServiceCollection serviceCollection,
        Action<IExceptionMiddlewareOptionsBuilder> action)
    {
        ExceptionMiddlewareOptions options = new();
        action(options);
        ReflectionBundlesManager reflectionBundlesManager = options.ReflectionBundlesManager;
        if (options.CompilePolicy == MapperMethodsCompilePolicy.CompileAllAtStart)
        {
            reflectionBundlesManager.CompileAllMappersMethods();
        }

        serviceCollection.AddMappersDispatcher(reflectionBundlesManager);
        serviceCollection.AddAllUsersMappersToServiceCollection(reflectionBundlesManager.GetAllMapperTypes());
        serviceCollection.AddMiddleware();
    }

    private static void AddMiddleware(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<JsonSerializer>();
        serviceCollection.AddScoped<Middleware.ExceptionCatcherMiddleware>();
    }

    private static void AddAllUsersMappersToServiceCollection(this IServiceCollection serviceCollection,
        ICollection<ReflectionBundle> mapperTypes)
    {
        foreach (var mapperType in mapperTypes)
        {
            serviceCollection.AddScoped(mapperType.MapperType);
        }
    }

    private static void AddMappersDispatcher(this IServiceCollection serviceCollection,
        IReflectionBundlesProvider reflectionBundlesManager)
    {
        serviceCollection.AddScoped<IMapperInstanceProvider, ServiceProviderWrapper>();
        serviceCollection.AddSingleton<IReflectionBundlesProvider>(reflectionBundlesManager);
        serviceCollection.AddScoped<StrictMappersDispatcher>();
    }
}