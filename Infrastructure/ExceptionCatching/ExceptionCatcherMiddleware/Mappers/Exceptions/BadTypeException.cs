namespace Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.Exceptions;

internal class BadTypeException : ArgumentException
{
    public BadTypeException(string msg) : base($"Type validation failed due to: {msg}")
    {
        
    }
}