namespace Infrastructure.ExceptionCatcherMiddleware.ExceptionSerializer;

internal interface IExceptionSerializer
{
    public string SerializeException<T>(T obj) where T : Exception;
}