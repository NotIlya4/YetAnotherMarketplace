using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.CreatingCustomMappers;
using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.Dispatchers.DispatcherDependencies;
using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.Dispatchers.MappersReflection;
using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.Exceptions;

namespace Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.Dispatchers;

internal class MappersDispatcher
{
    private readonly IMapperInstanceProvider _mapperInstanceProvider;
    private readonly IReflectionBundlesProvider _reflectionBundlesProvider;

    public MappersDispatcher(IMapperInstanceProvider mapperInstanceProvider,
        IReflectionBundlesProvider reflectionBundlesProvider)
    {
        _mapperInstanceProvider = mapperInstanceProvider;
        _reflectionBundlesProvider = reflectionBundlesProvider;
    }
    
    public BadResponse Map(Exception exception)
    {
        Type? exceptionType = exception.GetType();
        ReflectionBundle? reflectionBundle = null;
        
        while (exceptionType is not null)
        {
            reflectionBundle = _reflectionBundlesProvider.Get(exceptionType);
            if (reflectionBundle is not null)
            {
                break;
            }
            exceptionType = exceptionType.BaseType;
        }

        if (reflectionBundle is null)
        {
            throw new MappersDispatchingException(
                $"Not found reflection bundle for all parents of exception: {exception.GetType().FullName}");
        }
        
        object mapperInstance = _mapperInstanceProvider.GetMapperInstanceByType(reflectionBundle.MapperType);
        return reflectionBundle.CompiledMapperMethod(mapperInstance, exception);
    }
}