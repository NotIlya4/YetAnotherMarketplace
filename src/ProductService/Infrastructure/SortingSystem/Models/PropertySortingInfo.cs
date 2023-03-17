namespace Infrastructure.SortingSystem.Models;

public readonly record struct SortingInfo<TEntity>(PropertyName<TEntity> PropertyName, SortingSide SortingSide)
{
    public SortingInfo(string rawPropertyName, SortingSide sortingSide) 
        : this(new PropertyName<TEntity>(rawPropertyName), sortingSide)
    {
        
    }
}