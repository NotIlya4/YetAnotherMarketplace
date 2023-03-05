using Domain.Exceptions;
using ExceptionCatcherMiddleware.Mappers.CreatingCustomMappers;

namespace Infrastructure.ExceptionCatching;

public class ValidationExceptionMapper : IExceptionMapper<ValidationException>
{
    public BadResponse Map(ValidationException exception)
    {
        return new BadResponse()
        {
            StatusCode = 400,
            ResponseDto = new BadResponseDto()
            {
                Title = "Validation exception",
                Detail = exception.Message
            }
        };
    }
}