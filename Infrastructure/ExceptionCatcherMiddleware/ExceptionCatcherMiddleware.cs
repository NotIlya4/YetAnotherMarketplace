using System.Net;
using Infrastructure.ExceptionCatcherMiddleware.ExceptionSerializer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Infrastructure.ExceptionCatcherMiddleware;

internal class ExceptionCatcherMiddleware : IMiddleware
{
    private readonly IExceptionSerializer _exceptionSerializer;
    private readonly ILogger<ExceptionCatcherMiddleware> _logger;

    public ExceptionCatcherMiddleware(ILogger<ExceptionCatcherMiddleware> logger,
        IExceptionSerializer exceptionSerializer)
    {
        _logger = logger;
        _exceptionSerializer = exceptionSerializer;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Exception caught by {nameof(ExceptionCatcherMiddleware)}");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = _exceptionSerializer.SerializeException(e);

            await context.Response.WriteAsync(response);
        }
    }
}