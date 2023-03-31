using Newtonsoft.Json.Linq;

namespace IntegrationTests.Clients;

public class BrandsClient
{
    public HttpClient Client { get; }
    
    public BrandsClient(HttpClient client)
    {
        Client = client;
    }
    
    public async Task<JObject> PostNewBrand(string brandName)
    {
        HttpResponseMessage response = await Client.PostAsync($"api/brands/{brandName}");
        response.EnsureSuccessStatusCode();
        
        return await response.ExtractJObject();
    }

    public async Task<JArray> GetBrands()
    {
        HttpResponseMessage response = await Client.GetAsync("api/brands");
        response.EnsureSuccessStatusCode();
        
        return await response.ExtractJArray();
    }
    
    public async Task DeleteBrand(string brandName)
    {
        HttpResponseMessage response = await Client.DeleteAsync($"api/brands/{brandName}");
        response.EnsureSuccessStatusCode();
    }
}