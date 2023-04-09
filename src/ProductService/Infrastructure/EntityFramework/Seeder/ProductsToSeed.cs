using Infrastructure.EntityFramework.Models;

namespace Infrastructure.EntityFramework.Seeder;

public class ProductsToSeed
{
    public List<ProductData> ProductDatas { get; }
    private BrandsToSeed BrandSeeder { get; } = new();
    private ProductTypesToSeed ProductTypesToSeed { get; } = new();

    public ProductsToSeed()
    {
        ProductData product1 = new ProductData()
        {
            Id = "671cb8a2-d9ee-43a6-8704-c9169206da9a",
            Name = "Converse Waterproof Rubber Boots",
            Description =
                "Stay dry in style with these waterproof rubber boots from Converse. Featuring a sleek design and superior grip, they are perfect for any rainy day.",
            Price = 75m,
            PictureUrl = "http://localhost:5000/static/pictures/shoes-002-500.jpg",
            Brand = BrandSeeder.Converse,
            ProductType = ProductTypesToSeed.Shoes
        };
        ProductData product2 = new ProductData()
        {
            Id = "90757a26-4a01-4864-b02d-422c393b7050",
            Name = "Warrior Slim Fit Pants",
            Description =
                "Unleash your inner beast with these savage skinny pants by Fitwear, built to withstand the toughest workouts and toughest lifestyles.",
            Price = 59.99m,
            PictureUrl = "http://localhost:5000/static/pictures/pants-003-500.jpg",
            Brand = BrandSeeder.Fitwear,
            ProductType = ProductTypesToSeed.Pants
        };
        ProductData product3 = new ProductData()
        {
            Id = "97697238-e5ef-489f-a866-82b5a8af328f",
            Name = "Fitwear Performance Pants",
            Description =
                "These high-performance pants are made with moisture-wicking fabric and a flexible waistband for ultimate comfort during any workout.",
            Price = 69.99m,
            PictureUrl = "http://localhost:5000/static/pictures/pants-001-500.jpg",
            Brand = BrandSeeder.Fitwear,
            ProductType = ProductTypesToSeed.Pants
        };
        ProductData product4 = new ProductData()
        {
            Id = "9f6d6cfd-d919-405a-9c5e-c3c7ead59485",
            Name = "Skyline Skinny Fit Pants",
            Description =
                "Comfortable and versatile skinny pants with a modern design for any occasion by Flexpants.",
            Price = 54.99m,
            PictureUrl = "http://localhost:5000/static/pictures/pants-002-500.jpg",
            Brand = BrandSeeder.Flexpants,
            ProductType = ProductTypesToSeed.Pants
        };
        ProductData product5 = new ProductData()
        {
            Id = "ac8a34a8-ad32-4474-a17b-82c2a2963e4c",
            Name = "Chuck 70 High Top",
            Description =
                "Upgrade your shoe collection with these classic and comfortable Chuck 70 High Top sneakers from Converse, designed for the modern man with style.",
            Price = 90m,
            PictureUrl = "http://localhost:5000/static/pictures/shoes-001-500.jpg",
            Brand = BrandSeeder.Converse,
            ProductType = ProductTypesToSeed.Shoes
        };
        ProductData product6 = new ProductData()
        {
            Id = "b1a66082-15d2-4f45-9090-da5ee0598d06",
            Name = "Softstyle T-Shirt - Sunshine",
            Description =
                "Brighten up your day with the T-Shirt in Sunshine! Made from a lightweight fabric, this shirt is perfect for any sunny occasion.",
            Price = 14.99m,
            PictureUrl = "http://localhost:5000/static/pictures/tshirt-002-500.jpg",
            Brand = BrandSeeder.Gildan,
            ProductType = ProductTypesToSeed.TShirt
        };
        ProductData product7 = new ProductData()
        {
            Id = "beaaa5d4-e03c-43df-8d73-b20c302caa87",
            Name = "Apple Watch",
            Description =
                "Apple Watch: sleek, fitness tracking, messaging, calls, app library, customizable watch faces, for on-the-go lifestyles.",
            Price = 499.99m,
            PictureUrl = "http://localhost:5000/static/pictures/watches-001-500.jpg",
            Brand = BrandSeeder.Apple,
            ProductType = ProductTypesToSeed.Watches
        };
        ProductData product8 = new ProductData()
        {
            Id = "ead147d9-a64c-4423-8bcc-fcfc78f85604",
            Name = "Hanes Blackout T-Shirt",
            Description =
                "Made from soft and durable cotton, this t-shirt provides ultimate comfort and style for everyday wear.",
            Price = 12.99m,
            PictureUrl = "http://localhost:5000/static/pictures/tshirt-003-500.jpg",
            Brand = BrandSeeder.Hanes,
            ProductType = ProductTypesToSeed.TShirt
        };
        ProductData product9 = new ProductData()
        {
            Id = "f7aa92d6-9bde-4525-bce3-959c4b55aa14",
            Name = "Gildan Ultra Cotton T-Shirt",
            Description =
                "Stay comfortable all day long in this classic and durable Gildan Ultra Cotton t-shirt, made from pre-shrunk featuring a seamless collar stitching.",
            Price = 15.99m,
            PictureUrl = "http://localhost:5000/static/pictures/tshirt-001-500.jpg",
            Brand = BrandSeeder.Gildan,
            ProductType = ProductTypesToSeed.TShirt
        };

        ProductDatas = new List<ProductData>()
            { product1, product2, product3, product4, product5, product6, product7, product8, product9 };
    }
}