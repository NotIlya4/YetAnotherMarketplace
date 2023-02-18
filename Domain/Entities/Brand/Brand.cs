using Domain.Primitives;

namespace Domain.Entities.Brand;

public class Brand : BaseModel<BrandId>
{
    public Brand(BrandId id, string name, Uri website) : base(id)
    {
        Name = name;
        Website = website;
    }

    private Brand() : base(null!)
    {
    }

    public string Name { get; set; }
    public Uri Website { get; set; }
}