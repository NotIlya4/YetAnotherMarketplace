namespace Infrastructure.SortingSystem.Core;

public interface ISortingInfoProvider<TEntity>
{
    public IPropertySortingInfoProvider<TEntity> PrimarySorting { get; }
    public IEnumerable<IPropertySortingInfoProvider<TEntity>> SecondarySortings { get; }
}