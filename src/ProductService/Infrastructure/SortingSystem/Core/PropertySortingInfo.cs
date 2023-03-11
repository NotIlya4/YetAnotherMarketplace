using System.Linq.Expressions;
using Infrastructure.PropertySystem;

namespace Infrastructure.SortingSystem.Core;

public readonly struct PropertySortingInfo<TEntity> : IPropertySortingInfoProvider<TEntity>
{
    public Expression<Func<TEntity, object>> PropertyLambda { get; }
    public PropertyName<TEntity> PropertyName { get; }
    public SortingSide SortingSide { get; }

    public PropertySortingInfo(PropertyName<TEntity> propertyName, SortingSide sortingSide) 
        : this(new Property<TEntity>(propertyName), sortingSide)
    {
        
    }

    public PropertySortingInfo(string rawPropertyName, SortingSide sortingSide) 
        : this(new Property<TEntity>(rawPropertyName), sortingSide)
    {
        
    }

    public PropertySortingInfo(Property<TEntity> property, SortingSide sortingSide)
    {
        PropertyLambda = property.Lambda;
        PropertyName = property.Name;
        SortingSide = sortingSide;
    }
}