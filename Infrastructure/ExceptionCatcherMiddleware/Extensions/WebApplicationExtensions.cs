using Microsoft.AspNetCore.Builder;

namespace Infrastructure.ExceptionCatcherMiddleware.Extensions;

public static class WebApplicationExtensions
{
    public static IApplicationBuilder UseExceptionCatcherMiddleware(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseMiddleware<ExceptionCatcherMiddleware>();

        return applicationBuilder;
    }
}