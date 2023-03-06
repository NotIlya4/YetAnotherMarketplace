using System.Linq.Expressions;
using Domain.Entities;
using Domain.Exceptions;

namespace Infrastructure.Services.ProductService;

public class ProductSortingField
{
    public Expression<Func<Product, object?>> ProductProperty { get; }

    public ProductSortingField(string productPropertyName)
    {
        ProductProperty = MapNameToProperty(productPropertyName);
    }

    private Expression<Func<Product, object?>> MapNameToProperty(string propertyName)
    {
        if (propertyName.Equals(nameof(Product.Name), StringComparison.OrdinalIgnoreCase))
        {
            return p => p.Name;
        }
        
        if (propertyName.Equals(nameof(Product.Price), StringComparison.OrdinalIgnoreCase))
        {
            return p => p.Price;
        }
        
        if (propertyName.Equals(nameof(Product.ProductType), StringComparison.OrdinalIgnoreCase))
        {
            return p => p.ProductType;
        }

        throw new ValidationException("Sorting field must be either of: name, price, productType");
    }
}