using System.Text.Json;

namespace Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Middleware;

internal class JsonSerializer
{
    private JsonSerializerOptions Options { get; set; }

    public JsonSerializer()
    {
        Options = new JsonSerializerOptions();
        Options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    }
    
    public string Serialize(object o)
    {
        return System.Text.Json.JsonSerializer.Serialize(o, Options);
    }
}