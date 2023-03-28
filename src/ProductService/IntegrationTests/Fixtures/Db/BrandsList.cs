using Domain.Entities;
using Domain.Primitives;

namespace IntegrationTests.Fixtures.Db;

public class BrandsList
{
    public Brand Apple { get; }
    public Brand McDonalds { get; }

    public List<Brand> Brands { get; }

    public BrandsList()
    {
        Apple = new(new Guid("2d15e347-cf3d-4d8c-bdd7-c65f22e653f4"), new Name("Apple"));
        McDonalds = new(new Guid("aa7fe749-2e4b-45c4-b3f7-49c6f30d7d10"), new Name("McDonald's"));

        Brands = new()
        {
            Apple,
            McDonalds
        };
    }
}