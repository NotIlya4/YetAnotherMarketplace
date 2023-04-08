using Newtonsoft.Json.Linq;

namespace IntegrationTests.Clients;

public class ProductTypesClient
{
    public HttpClient Client { get; }
    
    public ProductTypesClient(HttpClient client)
    {
        Client = client;
    }
    
    public async Task Add(string productTypeName)
    {
        HttpResponseMessage response = await Client.PostAsync($"api/product-types/{productTypeName}");
        response.EnsureSuccessStatusCode();
    }

    public async Task<JArray> GetProductTypes()
    {
        HttpResponseMessage response = await Client.GetAsync("api/product-types");
        response.EnsureSuccessStatusCode();
        
        return await response.ExtractJArray();
    }
    
    public async Task Delete(string productTypeName)
    {
        HttpResponseMessage response = await Client.DeleteAsync($"api/product-types/{productTypeName}");
        response.EnsureSuccessStatusCode();
    }
}