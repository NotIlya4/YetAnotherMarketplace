namespace Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.Exceptions;

public class MappersDispatchingException : Exception
{
    public MappersDispatchingException(string msg) : base($"Exception caused during dispatching mappers: {msg}")
    {
        
    }
}