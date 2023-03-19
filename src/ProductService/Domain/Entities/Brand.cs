using Domain.Primitives;

namespace Domain.Entities;

public class Brand
{
    public Guid Id { get; set; }
    public Name Name { get; set; }

    public Brand(Guid id, Name name)
    {
        Id = id;
        Name = name;
    }

    private Brand()
    {
        
    }
}