using Domain.Entities;
using Domain.Primitives;

namespace IntegrationTests.EntityFactories;

public class ProductProvider
{
    public Product Airpods { get; }
    public Product Iphone { get; }
    public Product SamsungTv { get; }
    public Product AdidasShoes { get; }
    public List<Product> Products { get; }
    
    public ProductProvider(ProductTypeProvider productTypeProvider, BrandProvider brandProvider)
    {
        Airpods = new Product(
            id: new Guid("b4083a6d-d453-410b-84bc-665dac88e2b2"),
            name: new Name("Airpods"),
            description: new Description("Wireless earbuds with charging case"),
            price: new Price(1099),
            pictureUrl: new Uri("https://example.com/airpods.jpg"),
            productType: productTypeProvider.Headphones,
            brand: brandProvider.Apple);
        
        Iphone = new Product(
            id: new Guid("d445b71e-2e24-4c95-9193-2e4458557d3f"),
            name: new Name("IPhone 13 Pro Max"),
            description: new Description("The latest iPhone with a stunning OLED display and powerful A15 Bionic chip"),
            price: new Price(1099),
            pictureUrl: new Uri("https://www.apple.com/iphone-13-pro/"),
            productType: productTypeProvider.MobilePhone,
            brand: brandProvider.Apple);
        
        SamsungTv = new Product(
            id: new Guid("1a3f82ca-f222-4530-9c7f-1f073803708d"),
            name: new Name("Samsung QLED TV"),
            description: new Description("A top-of-the-line 4K TV with stunning picture quality and advanced features"),
            price: new Price(2499.99m),
            pictureUrl: new Uri("https://www.samsung.com/us/televisions-home-theater/tvs/qled-4k-tvs/65-class-q90a-qled-4k-uhd-hdr-smart-tv-2021-qn65q90aafxza/"),
            productType: productTypeProvider.Television,
            brand: brandProvider.Samsung);

        AdidasShoes = new Product(
            id: new Guid("1cf73f68-58f2-4bf7-9c2f-6c5b6a1b3e1d"),
            name: new Name("Adidas Ultraboost 21"),
            description: new Description(
                "These adidas Ultraboost 21 Shoes showcase a bold look inspired by speed. The foot-hugging adidas Primeknit upper has stitched-in reinforcement for a locked-in fit. Responsive cushioning returns energy to your stride with every step"),
            price: new Price(180),
            pictureUrl: new Uri(
                "https://assets.adidas.com/images/h_840,f_auto,q_auto:sensitive,fl_lossy/83cb117148e7441ab7c2ad4d0101014c_9366/Ultraboost_21_Shoes_Black_FX7725_01_standard.jpg"),
            productType: productTypeProvider.Shoes,
            brand: brandProvider.Adidas);

        Products = new List<Product>()
        {
            Airpods,
            Iphone,
            SamsungTv,
            AdidasShoes
        };
    }
}