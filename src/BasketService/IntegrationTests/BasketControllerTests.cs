using Api.Controllers;
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
    public async Task InsertBasket()
    {
        JObject jObject = new()
        {
            ["id"] = "4d6cc033-55d2-4097-ac42-0f1ba8dd227b",
            ["items"] = new JArray()
        };

        HttpContent content = new StringContent(jObject.ToString(), System.Text.Encoding.UTF8, "application/json");
        HttpResponseMessage postResponse = await AppFixture.Client.PostAsync("api/baskets", content);

        HttpResponseMessage response = await AppFixture.Client.GetAsync($"api/baskets/id/4d6cc033-55d2-4097-ac42-0f1ba8dd227b");
        JObject basket = JObject.Parse(await response.Content.ReadAsStringAsync());
        
        Assert.Equal(jObject, basket);

        await AppFixture.FlushDb();
    }
}