using Domain.Primitives;

namespace Domain.Entities;

public class ProductType
{
    public Guid Id { get; set; }
    public Name Name { get; set; }

    public ProductType(Guid id, Name name)
    {
        Id = id;
        Name = name;
    }
}