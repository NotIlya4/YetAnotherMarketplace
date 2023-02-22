using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.CreatingCustomMappers;
using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.Dispatchers.DispatcherDependencies;
using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.Dispatchers.MappersReflection;

namespace Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.Dispatchers;

internal class StrictMappersDispatcher
{
    private readonly IMapperInstanceProvider _mapperInstanceProvider;
    private readonly IReflectionBundlesProvider _reflectionBundlesProvider;
    private readonly ReflectionBundle _defaultReflectionBundle;

    public StrictMappersDispatcher(IMapperInstanceProvider mapperInstanceProvider,
        IReflectionBundlesProvider reflectionBundlesProvider)
    {
        _mapperInstanceProvider = mapperInstanceProvider;
        _reflectionBundlesProvider = reflectionBundlesProvider;
        _defaultReflectionBundle = reflectionBundlesProvider.GetDefault();
    }
    
    public BadResponse Map(Exception exception)
    {
        ReflectionBundle? reflectionBundle = _reflectionBundlesProvider.Get(exception.GetType());

        if (reflectionBundle is null)
        {
            reflectionBundle = _defaultReflectionBundle;
        }
        
        object mapperInstance = _mapperInstanceProvider.GetMapperInstanceByType(reflectionBundle.MapperType);
        return reflectionBundle.CompiledMapperMethod(mapperInstance, exception);
    }
}