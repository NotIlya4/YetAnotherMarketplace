using Domain.Entities;
using Domain.Primitives;
using Infrastructure.EntityFramework.Models;

namespace IntegrationTests.Fixtures.EntityLists;

public class BrandsList
{
    public Brand Apple { get; }
    public Brand McDonalds { get; }

    public IReadOnlyList<Brand> Brands { get; }
    public IReadOnlyList<BrandData> BrandDatas { get; }

    public BrandsList()
    {
        Apple = new(new Guid("2d15e347-cf3d-4d8c-bdd7-c65f22e653f4"), new Name("Apple"));
        McDonalds = new(new Guid("aa7fe749-2e4b-45c4-b3f7-49c6f30d7d10"), new Name("McDonald's"));

        Brands = new List<Brand>()
        {
            Apple,
            McDonalds
        };
        BrandDatas = Brands.Select(BrandData.FromDomain).ToList();
    }
}