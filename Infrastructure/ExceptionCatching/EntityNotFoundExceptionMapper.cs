using ExceptionCatcherMiddleware.Mappers.CreatingCustomMappers;
using Infrastructure.Data.Repositories.QueryableExtensions;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.ExceptionCatching;

public class EntityNotFoundExceptionMapper : IExceptionMapper<EntityNotFoundException>
{
    public BadResponse Map(EntityNotFoundException exception)
    {
        return new BadResponse()
        {
            StatusCode = StatusCodes.Status404NotFound,
            ResponseDto = new
            {
                Title = "Entity not found",
                Detail = exception.Message
            }
        };
    }
}