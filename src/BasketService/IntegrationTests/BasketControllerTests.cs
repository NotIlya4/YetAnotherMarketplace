using System.Net;
using IntegrationTests.Fixture;
using Newtonsoft.Json.Linq;

namespace IntegrationTests;

[Collection(nameof(AppFixture))]
public class BasketControllerTests
{
    public AppFixture AppFixture { get; }

    public BasketControllerTests(AppFixture appFixture)
    {
        AppFixture = appFixture;
    }
    
    [Fact]
    public async Task PostAndDeleteBasket_FirstlyPersistAndThenDelete()
    {
        JObject basket = new()
        {
            ["id"] = "4d6cc033-55d2-4097-ac42-0f1ba8dd227b",
            ["items"] = new JArray()
            {
                new JObject(){["productId"] = "4d6cc033-55d2-4097-ac42-0f1ba8dd227b", ["quantity"] = 10},
                new JObject(){["productId"] = "4d6cc033-55d2-4097-ac42-0f1ba8dd227b", ["quantity"] = 20}
            }
        };

        await AssertCreateBasket(basket);
        await AssertDeleteBasket(basket);
    }

    public async Task AssertCreateBasket(JObject basket)
    {
        HttpContent content = new StringContent(basket.ToString(), System.Text.Encoding.UTF8, "application/json");
        HttpResponseMessage postResponse = await AppFixture.Client.PostAsync("api/baskets", content);
        postResponse.EnsureSuccessStatusCode();

        HttpResponseMessage getResponse = await AppFixture.Client.GetAsync($"api/baskets/id/{basket["id"]}");
        getResponse.EnsureSuccessStatusCode();
        JObject responseBasket = JObject.Parse(await getResponse.Content.ReadAsStringAsync());
        
        Assert.Equal(basket, responseBasket);
    }

    public async Task AssertDeleteBasket(JObject basket)
    {
        HttpResponseMessage deleteResponse = await AppFixture.Client.DeleteAsync($"api/baskets/id/{basket["id"]}");
        deleteResponse.EnsureSuccessStatusCode();

        HttpResponseMessage getResponse = await AppFixture.Client.GetAsync($"api/baskets/id/{basket["id"]}");
        Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
    }
}