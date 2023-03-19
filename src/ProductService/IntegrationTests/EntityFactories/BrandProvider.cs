using Domain.Entities;
using Domain.Primitives;

namespace IntegrationTests.EntityFactories;

public class BrandProvider
{
    public Brand Apple { get; }
    public Brand Samsung { get; }
    public Brand Adidas { get; }
    public List<Brand> Brands { get; }

    public BrandProvider()
    {
        Apple = new Brand(
            id: new Guid("31cbbc70-e0b9-4ee5-876b-f47437648dd1"),
            name: new Name("Apple"));
        
        Samsung = new Brand(
            id: new Guid("3cf08484-8945-4367-8ab1-e2268ce5ce90"),
            name: new Name("Samsung"));

        Adidas = new Brand(
            id: new Guid("1cf73f68-58f2-4bf7-9c2f-6c5b6a1b3e1d"),
            name: new Name("Adidas"));

        Brands = new List<Brand>()
        {
            Apple,
            Samsung,
            Adidas
        };
    }
}