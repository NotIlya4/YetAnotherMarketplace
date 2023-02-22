using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.Dispatchers.MappersReflection;

namespace Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.Dispatchers.DispatcherDependencies;

internal interface IReflectionBundlesProvider
{
    public ReflectionBundle? Get(Type exceptionType);

    public ReflectionBundle GetDefault();
}