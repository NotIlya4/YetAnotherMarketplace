using Domain.Primitives;

namespace Domain.Entities.Brand;

public class BrandId : GuidId
{
    public BrandId(Guid id) : base(id)
    {
    }

    public BrandId(string id) : base(id)
    {
    }
}