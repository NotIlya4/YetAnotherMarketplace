using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;

namespace IntegrationTests;

public static class ServiceCollectionExtensions
{
    public static ServiceDescriptor GetServiceByType(this IServiceCollection services, Type type)
    {
        return services.Single(s => s.ServiceType == type);
    }

    public static void RemoveServiceByType(this IServiceCollection services, Type type)
    {
        var dbOptionsDescriptor = services.GetServiceByType(typeof(DbContextOptions<ApplicationDbContext>));
        services.Remove(dbOptionsDescriptor);
    }
}

public static class HttpClientExtensions
{
    public static Task<HttpResponseMessage> PostAsync(this HttpClient client, string url)
    {
        return client.PostAsync(url, null);
    }

    public static async Task<JObject> ExtractJObject(this Task<HttpResponseMessage> responseMessage)
    {
        HttpResponseMessage response = await responseMessage;
        return await response.ExtractJObject();
    }
    
    public static async Task<JArray> ExtractJArray(this Task<HttpResponseMessage> responseMessage)
    {
        HttpResponseMessage response = await responseMessage;
        return await response.ExtractJArray();
    }

    public static async Task<JObject> ExtractJObject(this HttpResponseMessage response)
    {
        string body = await response.Content.ReadAsStringAsync();
        return JObject.Parse(body);
    }
    
    public static async Task<JArray> ExtractJArray(this HttpResponseMessage response)
    {
        string body = await response.Content.ReadAsStringAsync();
        return JArray.Parse(body);
    }
}

public static class JTokenExtensions
{
    public static string String(this JToken jToken, string key)
    {
        return jToken[key]!.Value<string>()!;
    }
    
    public static int Int(this JToken jToken, string key)
    {
        return jToken[key]!.Value<int>()!;
    }
}