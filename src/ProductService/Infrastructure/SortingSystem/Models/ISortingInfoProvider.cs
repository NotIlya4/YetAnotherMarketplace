namespace Infrastructure.SortingSystem.Models;

public interface ISortingInfoProvider<TEntity>
{
    public SortingInfo<TEntity> PrimarySorting { get; }
    public List<SortingInfo<TEntity>> SecondarySortings { get; }
}