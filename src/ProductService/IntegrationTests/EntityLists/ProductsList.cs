using Domain.Entities;
using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.EntityLists;

public class ProductsList
{
    public Product IPhone13 { get; }
    public ProductData IPhone13Data { get; }
    public JObject IPhone13JObject { get; }
    
    public Product IPhone13ProMax { get; }
    public ProductData IPhone13ProMaxData { get; }
    public JObject IPhone13ProMaxJObject { get; }
    
    public Product BigMac { get; }
    public ProductData BigMacData { get; }
    public JObject BigMacJObject { get; }

    public Product IBurger { get; }
    public ProductData IBurgerData { get; }
    public JObject IBurgerJObject { get; }
    
    public Product QuarterPounder { get; }
    public ProductData QuarterPounderData { get; }
    public JObject QuarterPounderJObject { get; }

    public IReadOnlyList<Product> Products { get; }
    public IReadOnlyList<ProductData> ProductDatas { get; }
    public JArray ProductsJArray { get; }

    public ProductsList(BrandsList brandsList, ProductTypesList productTypesList)
    {
        DataMapper mapper = new();
        
        IPhone13 = new Product(
            id: new Guid("08c8d6f4-4441-4b49-8e0b-e9d3f966f4dc"),
            name: new Name("iPhone 13"),
            description: new Description("The Apple iPhone 13 features a stunning 6.1-inch Super Retina XDR " +
                                         "display with ProMotion technology, A15 Bionic chip, 5G connectivity, and " +
                                         "a dual-camera system with Night mode. It runs on iOS 15 and is available in " +
                                         "multiple storage capacities and colors."),
            price: new Price(799m),
            pictureUrl: new Uri(
                "https://www.apple.com/v/iphone-13/a/images/overview/hero/iphone_13_overview_hero__iwjco3lsqxi6_large.jpg"),
            productType: productTypesList.Smartphone,
            brand: brandsList.Apple);
        IPhone13Data = mapper.MapProduct(IPhone13, productTypesList.SmartphoneData, brandsList.AppleData);
        IPhone13JObject = new JObject()
        {
            ["id"] = "08c8d6f4-4441-4b49-8e0b-e9d3f966f4dc",
            ["name"] = "iPhone 13",
            ["description"] = "The Apple iPhone 13 features a stunning 6.1-inch Super Retina XDR " +
                              "display with ProMotion technology, A15 Bionic chip, 5G connectivity, and " +
                              "a dual-camera system with Night mode. It runs on iOS 15 and is available in " +
                              "multiple storage capacities and colors.",
            ["price"] = 799m,
            ["pictureUrl"] =
                "https://www.apple.com/v/iphone-13/a/images/overview/hero/iphone_13_overview_hero__iwjco3lsqxi6_large.jpg",
            ["productType"] = "Smartphone",
            ["brand"] = "Apple"
        };

        IPhone13ProMax = new Product(
            id: new Guid("8a29718b-2bed-4291-8464-0b928f7c0484"),
            name: new Name("iPhone 13 Pro Max"),
            description: new Description(
                "The Apple iPhone 13 Pro Max features a stunning 6.7-inch Super Retina XDR display " +
                "with ProMotion technology, A15 Bionic chip, 5G connectivity, and a triple-camera " +
                "system with Night mode and LiDAR Scanner. It runs on iOS 15 and is available in multiple " +
                "storage capacities and colors."),
            price: new Price(1099m),
            pictureUrl: new Uri("https://www.apple.com/v/iphone-13-pro/a/images/overview/hero/iphone_13_pro_overview_hero__b03xtql92rg6_large.jpg"),
            productType: productTypesList.Smartphone,
            brand: brandsList.Apple);
        IPhone13ProMaxData = mapper.MapProduct(IPhone13ProMax, productTypesList.SmartphoneData, brandsList.AppleData);
        IPhone13ProMaxJObject = new JObject()
        {
            ["id"] = "8a29718b-2bed-4291-8464-0b928f7c0484",
            ["name"] = "iPhone 13 Pro Max",
            ["description"] = "The Apple iPhone 13 Pro Max features a stunning 6.7-inch Super Retina XDR display " +
                              "with ProMotion technology, A15 Bionic chip, 5G connectivity, and a triple-camera " +
                              "system with Night mode and LiDAR Scanner. It runs on iOS 15 and is available in multiple " +
                              "storage capacities and colors.",
            ["price"] = 1099m,
            ["pictureUrl"] =
                "https://www.apple.com/v/iphone-13-pro/a/images/overview/hero/iphone_13_pro_overview_hero__b03xtql92rg6_large.jpg",
            ["productType"] = "Smartphone",
            ["brand"] = "Apple"
        };
        
        BigMac = new Product(
            id: new Guid("0a946eb1-bdf1-47d7-a675-ec65a3c74715"),
            name: new Name("Big Mac"),
            description: new Description(
                "Two 100% pure beef patties and special sauce sandwiched between a sesame seed bun. " +
                "It's topped off with pickles, crisp lettuce, onions and American cheese for a 100% beef " +
                "burger with a taste like no other."),
            price: new Price(3.99m),
            pictureUrl: new Uri(
                "https://www.mcdonalds.com/is/image/content/dam/usa/nfl/assets/img/menu/hero/hero-our-food-big-mac.jpg"),
            productType: productTypesList.Burger,
            brand: brandsList.McDonalds);
        BigMacData = mapper.MapProduct(BigMac, productTypesList.BurgerData, brandsList.McDonaldsData);
        BigMacJObject = new JObject()
        {
            ["id"] = "0a946eb1-bdf1-47d7-a675-ec65a3c74715",
            ["name"] = "Big Mac",
            ["description"] = "Two 100% pure beef patties and special sauce sandwiched between a sesame seed bun. " +
                              "It's topped off with pickles, crisp lettuce, onions and American cheese for a 100% beef " +
                              "burger with a taste like no other.",
            ["price"] = 3.99m,
            ["pictureUrl"] =
                "https://www.mcdonalds.com/is/image/content/dam/usa/nfl/assets/img/menu/hero/hero-our-food-big-mac.jpg",
            ["productType"] = "Burger",
            ["brand"] = "McDonald's"
        };
        
        IBurger = new Product(
            id: new Guid("70f4edc3-5cca-4763-bd5d-1e8e33505405"),
            name: new Name("iBurger"),
            description: new Description(
                "The iBurger is a delicious flame-grilled burger with cheddar cheese, lettuce, " +
                "tomatoes, and special sauce on a sesame seed bun."),
            price: new Price(9.99m),
            pictureUrl: new Uri("https://www.example.com/iburger.jpg"),
            productType: productTypesList.Burger,
            brand: brandsList.Apple);
        IBurgerData = mapper.MapProduct(IBurger, productTypesList.BurgerData, brandsList.AppleData);
        IBurgerJObject = new JObject()
        {
            ["id"] = "70f4edc3-5cca-4763-bd5d-1e8e33505405",
            ["name"] = "iBurger",
            ["description"] = "The iBurger is a delicious flame-grilled burger with cheddar cheese, lettuce, " +
                              "tomatoes, and special sauce on a sesame seed bun.",
            ["price"] = 9.99m,
            ["pictureUrl"] = "https://www.example.com/iburger.jpg",
            ["productType"] = "Burger",
            ["brand"] = "Apple"
        };


        QuarterPounder = new Product(
            id: new Guid("3fa33b0e-467a-420e-a479-cb43164fec70"),
            name: new Name("Quarter Pounder with Cheese"),
            description: new Description(
                "A quarter pound of 100% pure beef, two slices of cheese, onions, pickles, mustard, and ketchup on a " +
                "toasted sesame seed bun."),
            price: new Price(4.79m),
            pictureUrl: new Uri("https://www.mcdonalds.com/is/image/content/dam/usa/nfl/assets/menu-items/Quarter-Pounder-with-" +
                                "Cheese-Extra-Value-Meals-Extra-Value-Meals.png?$Product_Desktop$"),
            productType: productTypesList.Burger,
            brand: brandsList.McDonalds);
        QuarterPounderData = mapper.MapProduct(QuarterPounder, productTypesList.BurgerData, brandsList.McDonaldsData);
        QuarterPounderJObject = new JObject()
        {
            ["id"] = "3fa33b0e-467a-420e-a479-cb43164fec70",
            ["name"] = "Quarter Pounder with Cheese",
            ["description"] = "A quarter pound of 100% pure beef, two slices of cheese, onions, pickles, mustard, and ketchup on a " +
                              "toasted sesame seed bun.",
            ["price"] = 4.79m,
            ["pictureUrl"] =
                "https://www.mcdonalds.com/is/image/content/dam/usa/nfl/assets/menu-items/Quarter-Pounder-with-" +
                "Cheese-Extra-Value-Meals-Extra-Value-Meals.png?$Product_Desktop$",
            ["productType"] = "Burger",
            ["brand"] = "McDonald's"
        };

        Products = new List<Product>()
        {
            BigMac,
            IBurger,
            IPhone13,
            IPhone13ProMax,
            QuarterPounder
        };

        ProductDatas = new List<ProductData>()
        {
            BigMacData,
            IBurgerData,
            IPhone13Data,
            IPhone13ProMaxData,
            QuarterPounderData
        };

        ProductsJArray = new JArray()
        {
            BigMacJObject,
            IBurgerJObject,
            IPhone13JObject,
            IPhone13ProMaxJObject,
            QuarterPounderJObject
        };
    }
}