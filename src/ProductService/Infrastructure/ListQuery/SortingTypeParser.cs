using Domain.Exceptions;

namespace Infrastructure.ListQuery;

public static class SortingTypeParser
{
    public static SortingType ParseSortingType(string sortingTypeRaw)
    {
        sortingTypeRaw = sortingTypeRaw.ToLower();
        
        string[] ascending = new[] { "asc", "+", "ascending" };
        if (ascending.Contains(sortingTypeRaw))
        {
            return SortingType.Asc;
        }
        
        string[] descending = new[] { "desc", "-", "descending" };
        if (descending.Contains(sortingTypeRaw))
        {
            return SortingType.Desc;
        }

        throw new ValidationException("Sorting type must be either of: asc, desc");
    }
}