namespace Infrastructure.SortingSystem.Models;

public interface ISortingInfo
{
    public string PropertyName { get; }
    public SortingSide SortingSide { get; }
}