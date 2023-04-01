﻿using IntegrationTests.Clients;
using IntegrationTests.Fixtures;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Tests;

[Collection(nameof(AppFixture))]
public class ProductTypesControllerTests
{
    public JArray InitialDb { get; }
    public ProductTypesClient Client { get; }

    public ProductTypesControllerTests(AppFixture appFixture)
    {
        Client = new ProductTypesClient(appFixture.Client);

        InitialDb = appFixture.ProductTypesList.ProductTypesJArray;
    }
    
    [Fact]
    public async Task GetProductTypes_ReturnProductTypes()
    {
        JArray result = await Client.GetProductTypes();

        Assert.Equal(InitialDb, result);

        await AssertProductTypesDefault();
    }
    
    [Fact]
    public async Task AddProductType_ReturnPersistedProductType()
    {
        string newProductType = "Door";

        JObject postProductTypeResponse = await Client.PostNewProductType(newProductType);
        Assert.Equal(newProductType, postProductTypeResponse.String("name"));

        List<JToken> expectProductTypesInDb = new JArray(InitialDb).ToList();
        expectProductTypesInDb.Insert(1, postProductTypeResponse);
        
        List<JToken> productTypesInDb = (await Client.GetProductTypes()).ToList();
        Assert.Equal(expectProductTypesInDb, productTypesInDb);

        await Client.DeleteProductType(newProductType);
        
        await AssertProductTypesDefault();
    }
    
    [Fact]
    public async Task DeleteProductType_DeleteProductType()
    {
        string newProductType = "Zoo";
        string? newProductTypeId = (await Client.PostNewProductType(newProductType)).String("id");
        
        List<JToken> expectProductTypesAfterPost = new JArray(InitialDb).ToList();
        expectProductTypesAfterPost.Add(new JObject() {["id"] = newProductTypeId, ["name"] = newProductType});

        List<JToken> productTypesAfterPost = (await Client.GetProductTypes()).ToList();
        Assert.Equal(expectProductTypesAfterPost, productTypesAfterPost);

        await Client.DeleteProductType(newProductType);
        
        List<JToken> productTypesAfterDelete = (await Client.GetProductTypes()).ToList();
        
        Assert.Equal(InitialDb, productTypesAfterDelete);
        
        await AssertProductTypesDefault();
    }

    private async Task AssertProductTypesDefault()
    {
        JArray productTypes = await Client.GetProductTypes();
        Assert.Equal(InitialDb, productTypes);
    }
}