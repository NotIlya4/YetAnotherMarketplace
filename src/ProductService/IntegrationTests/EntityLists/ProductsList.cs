using Api.Controllers.ProductsControllers.Views;
using Domain.Entities;
using Domain.Primitives;
using Infrastructure.EntityFramework.Models;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.EntityLists;

public class ProductsList
{
    public Product IPhone13 { get; }
    public Product IPhone13ProMax { get; }
    public Product BigMac { get; }
    public Product QuerterPounder { get; }

    public IReadOnlyList<Product> Products { get; }
    public IReadOnlyList<ProductData> ProductDatas { get; }
    public JArray ProductsJArray { get; }

    public ProductsList(BrandsList brandsList, ProductTypesList productTypesList)
    {
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

        QuerterPounder = new Product(
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

        Products = new List<Product>()
        {
            BigMac,
            IPhone13,
            IPhone13ProMax,
            QuerterPounder
        };
        ProductDatas = Products.Select(ProductData.FromDomain).ToList();

        List<ProductView> productViews = ProductView.FromDomain(Products);
        JFactory jFactory = new();
        ProductsJArray = jFactory.Create(productViews);
    }
}