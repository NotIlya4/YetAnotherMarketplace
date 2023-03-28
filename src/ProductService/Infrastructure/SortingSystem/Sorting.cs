namespace Infrastructure.SortingSystem;

public class Sorting : ISorting
{
    public string PropertyName { get; }
    public SortingSide SortingSide { get; }

    public Sorting(string propertyName, SortingSide sortingSide)
    {
        PropertyName = propertyName;
        SortingSide = sortingSide;
    }
}