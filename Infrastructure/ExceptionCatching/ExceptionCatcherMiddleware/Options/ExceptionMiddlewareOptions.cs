using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers;
using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.CreatingCustomMappers;
using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.Dispatchers.MappersReflection;

namespace Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Options;

internal class ExceptionMiddlewareOptions : IExceptionMiddlewareOptionsBuilder
{
    public MapperMethodsCompilePolicy CompilePolicy { get; set; } = MapperMethodsCompilePolicy.LazyCompile;
    public ReflectionBundlesManager ReflectionBundlesManager { get; }

    public ExceptionMiddlewareOptions()
    {
        ReflectionBundlesManager = new(new ReflectionBundle(typeof(DefaultExceptionMapper)));
    }

    public void RegisterExceptionMapper<TException, TMapper>() 
        where TMapper : class, IExceptionMapper<TException>
        where TException : Exception
    {
        ReflectionBundlesManager.Set(new ReflectionBundle(typeof(TMapper)));
    }
}