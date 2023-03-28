namespace Infrastructure.SortingSystem;

public interface ISorting
{
    public string PropertyName { get; }
    public SortingSide SortingSide { get; }
}