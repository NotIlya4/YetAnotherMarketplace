using System.Text.Json;

namespace Infrastructure.ExceptionCatcherMiddleware.ExceptionSerializer;

internal class ExceptionSerializer : IExceptionSerializer
{
    public string SerializeException<T>(T obj) where T : Exception
    {
        var options = new JsonSerializerOptions();
        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        return JsonSerializer.Serialize(new { obj.Message }, options);
    }
}