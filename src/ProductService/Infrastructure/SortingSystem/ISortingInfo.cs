namespace Infrastructure.SortingSystem;

public interface ISortingInfo
{
    public string PropertyName { get; }
    public SortingSide SortingSide { get; }
}