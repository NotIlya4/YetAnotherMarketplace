using Domain.Primitives;

namespace Domain.Entities.Product;

public class ProductId : GuidId
{
    public ProductId(Guid id) : base(id)
    {
    }

    public ProductId(string id) : base(id)
    {
    }
}