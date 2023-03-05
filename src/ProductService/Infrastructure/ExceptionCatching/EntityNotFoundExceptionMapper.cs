using ExceptionCatcherMiddleware.Mappers.CreatingCustomMappers;
using Infrastructure.Repositories.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.ExceptionCatching;

public class EntityNotFoundExceptionMapper : IExceptionMapper<EntityNotFoundException>
{
    public BadResponse Map(EntityNotFoundException exception)
    {
        return new BadResponse()
        {
            StatusCode = StatusCodes.Status404NotFound,
            ResponseDto = new BadResponseDto()
            {
                Title = "Entity not found",
                Detail = exception.Message
            }
        };
    }
}