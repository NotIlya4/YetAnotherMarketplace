using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.CreatingCustomMappers;

namespace Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.Dispatchers;

public interface IMappersDispatcher
{
    public BadResponse Map(Exception exception);
}