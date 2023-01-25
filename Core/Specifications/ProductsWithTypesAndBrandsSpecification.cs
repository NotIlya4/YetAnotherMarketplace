using Core.Entities;

namespace Core.Specifications;

public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
{
    public ProductsWithTypesAndBrandsSpecification() : base(null)
    {
        AddInclude(p => p.ProductType);
        AddInclude(p => p.ProductBrand);
    }
}
