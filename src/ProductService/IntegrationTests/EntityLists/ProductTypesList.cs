using Domain.Entities;
using Domain.Primitives;
using Infrastructure.EntityFramework.Models;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.EntityLists;

public class ProductTypesList
{
    public ProductType Smartphone { get; }
    public JObject SmartphoneJObject { get; }
    public ProductType Burger { get; }
    public JObject BurgerJObject { get; }

    public IReadOnlyList<ProductType> ProductTypes { get; }
    public IReadOnlyList<ProductTypeData> ProductTypeDatas { get; }
    public JArray ProductTypesJArray { get; }

    public ProductTypesList()
    {
        Smartphone = new ProductType(new Guid("f68d9bd6-e7c5-4f50-8147-d5b85b292bcf"), new Name("Smartphone"));
        SmartphoneJObject = new JObject() { ["id"] = "f68d9bd6-e7c5-4f50-8147-d5b85b292bcf", ["name"] = "Smartphone" };
        
        Burger = new ProductType(new Guid("70a4fa45-b9f9-4409-8d13-c55dabfa3169"), new Name("Burger"));
        BurgerJObject = new JObject() { ["id"] = "70a4fa45-b9f9-4409-8d13-c55dabfa3169", ["name"] = "Burger" };

        ProductTypes = new List<ProductType>()
        {
            Burger,
            Smartphone,
        };
        
        ProductTypeDatas = ProductTypes.Select(ProductTypeData.FromDomain).ToList();

        ProductTypesJArray = new JArray()
        {
            BurgerJObject,
            SmartphoneJObject
        };
    }
}