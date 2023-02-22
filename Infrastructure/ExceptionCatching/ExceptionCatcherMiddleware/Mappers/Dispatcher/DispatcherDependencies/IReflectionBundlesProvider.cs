using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.Dispatcher.MappersReflection;

namespace Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.Dispatcher.DispatcherDependencies;

internal interface IReflectionBundlesProvider
{
    public ReflectionBundle? Get(Type exceptionType);

    public ReflectionBundle GetDefault();
}