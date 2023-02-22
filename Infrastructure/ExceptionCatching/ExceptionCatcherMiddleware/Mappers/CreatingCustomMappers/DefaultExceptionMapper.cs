using Infrastructure.ExceptionCatching.ExceptionMappers.BadResponseDtos;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.CreatingCustomMappers;

internal class DefaultExceptionMapper : IExceptionMapper<Exception>
{
    public BadResponse Map(Exception exception)
    {
        return new BadResponse()
        {
            StatusCode = StatusCodes.Status500InternalServerError,
            ExceptionDto = new BadResponseDto()
            {
                Title = "Internal exception",
                Detail = exception.Message
            }
        };
    }
}