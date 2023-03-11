using Domain.Exceptions;
using Infrastructure.SortingSystem.Core;

namespace Infrastructure.ListQuery;

public static class SortingTypeParser
{
    public static SortingSide ParseSortingType(string sortingTypeRaw)
    {
        sortingTypeRaw = sortingTypeRaw.ToLower();
        
        string[] ascending = new[] { "asc", "+", "ascending" };
        if (ascending.Contains(sortingTypeRaw))
        {
            return SortingSide.Asc;
        }
        
        string[] descending = new[] { "desc", "-", "descending" };
        if (descending.Contains(sortingTypeRaw))
        {
            return SortingSide.Desc;
        }

        throw new ValidationException("Sorting type must be either of: asc, desc");
    }
}