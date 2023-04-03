using ExceptionCatcherMiddleware.Mappers.CreatingCustomMappers;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.ExceptionMapping;

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