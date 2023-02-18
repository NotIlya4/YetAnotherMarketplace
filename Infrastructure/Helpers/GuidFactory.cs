using Domain.Entities.Brand;
using Domain.Entities.Product;

namespace Infrastructure.Helpers;

public class GuidFactory : IProductIdFactory, IBrandIdFactory
{
    public ProductId CreateProductId()
    {
        return new ProductId(Guid.NewGuid());
    }

    public BrandId CreateBrandId()
    {
        return new BrandId(Guid.NewGuid());
    }
}