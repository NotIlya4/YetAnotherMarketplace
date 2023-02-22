using Infrastructure.Data.Repositories.QueryableExtensions;
using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.CreatingCustomMappers;
using Infrastructure.ExceptionCatching.ExceptionMappers.BadResponseDtos;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.ExceptionCatching.ExceptionMappers;

public class NoSuchEntityInRepositoryExceptionMapper : IExceptionMapper<NoSuchEntityInRepositoryException>
{
    public BadResponse Map(NoSuchEntityInRepositoryException exception)
    {
        return new BadResponse()
        {
            StatusCode = StatusCodes.Status404NotFound,
            ExceptionDto = new BadResponseDto()
            {
                Title = "Entity not found",
                Detail = exception.Message
            }
        };
    }
}