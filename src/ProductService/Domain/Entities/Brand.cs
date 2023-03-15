using Domain.Primitives;

namespace Domain.Entities;

public class Brand
{
    public Guid Id { get; set; }
    public Name Name { get; set; }
    public Uri Website { get; set; }

    public Brand(Guid id, Name name, Uri website)
    {
        Id = id;
        Name = name;
        Website = website;
    }

    private Brand()
    {
        Website = null!;
    }
}