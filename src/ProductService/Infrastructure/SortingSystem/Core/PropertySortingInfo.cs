using Infrastructure.PropertySystem;

namespace Infrastructure.SortingSystem.Core;

public readonly struct SortingInfo<TEntity> : ISortingInfo<TEntity>
{
    public PropertyName<TEntity> PropertyName { get; }
    public SortingSide SortingSide { get; }

    public SortingInfo(string rawPropertyName, SortingSide sortingSide) 
        : this(new PropertyName<TEntity>(rawPropertyName), sortingSide)
    {
        
    }
    
    public SortingInfo(PropertyName<TEntity> propertyName, SortingSide sortingSide)
    {
        PropertyName = propertyName;
        SortingSide = sortingSide;
    }
}