using Infrastructure.Repositories.Extensions;

namespace Infrastructure.SortingSystem;

public class SortingInfo : ISortingInfo
{
    public string PropertyName { get; }
    public SortingSide SortingSide { get; }

    public SortingInfo(string propertyName, SortingSide sortingSide)
    {
        PropertyName = propertyName;
        SortingSide = sortingSide;
    }
}