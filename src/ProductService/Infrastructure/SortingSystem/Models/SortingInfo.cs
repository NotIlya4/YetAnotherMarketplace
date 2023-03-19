namespace Infrastructure.SortingSystem.Models;

public record struct SortingInfo : ISortingInfo
{
    public string PropertyName { get; }
    public SortingSide SortingSide { get; }

    public SortingInfo(string propertyName, SortingSide sortingSide)
    {
        PropertyName = propertyName;
        SortingSide = sortingSide;
    }
}