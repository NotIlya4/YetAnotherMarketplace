using Domain.Entities;
using Domain.Primitives;

namespace IntegrationTests.EntityFactories;

public class ProductTypeProvider
{
    public ProductType Headphones { get; }
    public ProductType MobilePhone { get; }
    public ProductType Television { get; }
    public ProductType Shoes { get; }
    public List<ProductType> ProductTypes { get; }

    public ProductTypeProvider()
    {
        Headphones = new ProductType(
            id: new Guid("2a2f2bb9-c59e-43a4-a1d8-512c02bd895f"),
            name: new Name("Headphones"));
        
        MobilePhone = new ProductType(
            id: new Guid("9b78198c-3bf2-4b6e-893e-675af99087a7"),
            name: new Name("Mobile Phone"));
        
        Television = new ProductType(
            id: new Guid("92fb9aec-1e8c-4625-b30b-71dcac6e4963"),
            name: new Name("Television"));

        Shoes = new ProductType(
            id: new Guid("91b0c9fc-0197-4246-a5aa-0d05eeb5a6f7"),
            name: new Name("Shoes"));

        ProductTypes = new List<ProductType>()
        {
            Headphones,
            MobilePhone,
            Television,
            Shoes
        };
    }
}