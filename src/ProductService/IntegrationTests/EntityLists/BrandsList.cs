using Domain.Entities;
using Domain.Primitives;
using Infrastructure.EntityFramework.Models;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.EntityLists;

public class BrandsList
{
    public Brand Apple { get; }
    public JObject AppleJObject { get; }
    public Brand McDonalds { get; }
    public JObject McDonaldsJObject { get; }

    public IReadOnlyList<Brand> Brands { get; }
    public IReadOnlyList<BrandData> BrandDatas { get; }
    public JArray BrandsJArray { get; }

    public BrandsList()
    {
        Apple = new(new Guid("2d15e347-cf3d-4d8c-bdd7-c65f22e653f4"), new Name("Apple"));
        AppleJObject = new JObject() { ["id"] = "2d15e347-cf3d-4d8c-bdd7-c65f22e653f4", ["name"] = "Apple" };
        
        McDonalds = new(new Guid("aa7fe749-2e4b-45c4-b3f7-49c6f30d7d10"), new Name("McDonald's"));
        McDonaldsJObject = new JObject() { ["id"] = "aa7fe749-2e4b-45c4-b3f7-49c6f30d7d10", ["name"] = "McDonald's" };

        Brands = new List<Brand>()
        {
            Apple,
            McDonalds
        };
        
        BrandDatas = Brands.Select(BrandData.FromDomain).ToList();

        BrandsJArray = new JArray()
        {
            AppleJObject,
            McDonaldsJObject
        };
    }
}