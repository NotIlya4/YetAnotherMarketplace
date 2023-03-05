using Domain.Primitives;

namespace Domain.Entities;

public class Brand
{
    public Brand(Guid id, NotNullString name, Uri website)
    {
        Id = id;
        Name = name;
        Website = website;
    }

    private Brand()
    {
        Website = null!;
    }

    public Guid Id { get; set; }
    public NotNullString Name { get; set; }
    public Uri Website { get; set; }
}