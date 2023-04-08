using Domain.Primitives;
using Infrastructure.EntityFramework.Models;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.EntityLists;

public class ProductTypesList
{
    public Name Smartphone { get; }
    public ProductTypeData SmartphoneData { get; }
    
    public Name Burger { get; }
    public ProductTypeData BurgerData { get; }

    public IReadOnlyList<Name> ProductTypes { get; }
    public IReadOnlyList<ProductTypeData> ProductTypeDatas { get; }
    public JArray ProductTypesJArray { get; }

    public ProductTypesList()
    {
        string smartphoneId = "f68d9bd6-e7c5-4f50-8147-d5b85b292bcf";
        string smartphoneName = "Smartphone";
        Smartphone = new Name(smartphoneName);
        SmartphoneData = new ProductTypeData() { Id = smartphoneId, Name = smartphoneName };

        string burgerId = "70a4fa45-b9f9-4409-8d13-c55dabfa3169";
        string burgerName = "Burger";
        Burger = new Name(burgerName);
        BurgerData = new ProductTypeData() { Id = burgerId, Name = burgerName };

        ProductTypes = new List<Name>()
        {
            Burger,
            Smartphone,
        };

        ProductTypeDatas = new List<ProductTypeData>()
        {
            BurgerData,
            SmartphoneData
        };
        
        ProductTypesJArray = new JArray()
        {
            burgerName,
            smartphoneName
        };
    }
}