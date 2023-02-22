using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers;
using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.CreatingCustomMappers;
using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.Dispatchers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Middleware;

internal class ExceptionCatcherMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionCatcherMiddleware> _logger;
    private readonly StrictMappersDispatcher _strictMappersDispatcher;
    private readonly JsonSerializer _jsonSerializer;

    public ExceptionCatcherMiddleware(ILogger<ExceptionCatcherMiddleware> logger,
        StrictMappersDispatcher strictMappersDispatcher,
        JsonSerializer jsonSerializer)
    {
        _logger = logger;
        _strictMappersDispatcher = strictMappersDispatcher;
        _jsonSerializer = jsonSerializer;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Exception caught by {catcher}", nameof(ExceptionCatcherMiddleware));
            
            BadResponse badResponse = _strictMappersDispatcher.Map(e);
            string body = _jsonSerializer.Serialize(badResponse.ExceptionDto);
            
            context.Response.StatusCode = badResponse.StatusCode;
            context.Response.ContentType = "application/json+problem";
            await context.Response.WriteAsync(body);
        }
    }
}