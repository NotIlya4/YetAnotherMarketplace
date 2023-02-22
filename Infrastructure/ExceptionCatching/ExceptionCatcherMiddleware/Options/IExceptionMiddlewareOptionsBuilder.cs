using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers;
using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.CreatingCustomMappers;

namespace Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Options;

public interface IExceptionMiddlewareOptionsBuilder
{
    public MapperMethodsCompilePolicy CompilePolicy { get; set; }

    public void RegisterExceptionMapper<TException, TMapper>()
        where TMapper : class, IExceptionMapper<TException>
        where TException : Exception;
}