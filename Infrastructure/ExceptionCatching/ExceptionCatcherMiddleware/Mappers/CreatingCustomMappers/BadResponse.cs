namespace Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.CreatingCustomMappers;

public class BadResponse
{
    public required int StatusCode { get; set; }
    public required object ExceptionDto { get; set; }
}