using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers;
using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.CreatingCustomMappers;
using Infrastructure.ExceptionCatching.ExceptionMappers.BadResponseDtos;

namespace Infrastructure.ExceptionCatching.ExceptionMappers;

public class NewDefaultExceptionExceptionMapper : IExceptionMapper<Exception>
{
    public BadResponse Map(Exception exception)
    {
        return new BadResponse()
        {
            StatusCode = 500,
            ExceptionDto = new BadResponseDto()
            {
                Title = "Internal exception",
                Detail = "Something went wrong during execution"
            }
        };
    }
}