namespace Infrastructure.SortingSystem.Core;

public interface ISortingInfoProvider<TEntity>
{
    public SortingInfo<TEntity> PrimarySorting { get; }
    public IEnumerable<SortingInfo<TEntity>> SecondarySortings { get; }
}