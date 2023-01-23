using System.Text.Json;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data;

public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext context)
    {
        if (!context.ProductBrands.Any())
        {
            string brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/Brands.json");
            IEnumerable<ProductBrand> brands = JsonSerializer.Deserialize<IEnumerable<ProductBrand>>(brandsData) ?? throw new ArgumentNullException();
            await context.ProductBrands.AddRangeAsync(brands);
            await context.SaveChangesAsync();
        }

        if (!context.ProductTypes.Any())
        {
            string typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
            IEnumerable<ProductType> types = JsonSerializer.Deserialize<IEnumerable<ProductType>>(typesData) ?? throw new ArgumentNullException();
            await context.ProductTypes.AddRangeAsync(types);
            await context.SaveChangesAsync();
        }

        if (!context.Products.Any())
        {
            string productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
            IEnumerable<Product> products = JsonSerializer.Deserialize<IEnumerable<Product>>(productsData) ?? throw new ArgumentNullException();
            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();
        }
    }
}