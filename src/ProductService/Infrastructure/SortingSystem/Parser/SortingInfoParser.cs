using Infrastructure.SortingSystem.Core;

namespace Infrastructure.SortingSystem.Parser;

public class SortingInfoParser<TEntity>
{
    public PropertySortingInfo<TEntity> Parse(string rawPropertySortingInfo)
    {
        SortingSide sortingSide = GetSortingSide(rawPropertySortingInfo);
        string rawPropertyName = RemoveSortingSideFromString(rawPropertySortingInfo);

        return new PropertySortingInfo<TEntity>(rawPropertyName, sortingSide);
    }

    public List<PropertySortingInfo<TEntity>> Parse(IEnumerable<string> rawPropertySortingInfos)
    {
        return rawPropertySortingInfos.Select(Parse).ToList();
    }
    
    private SortingSide GetSortingSide(string rawSortingField)
    {
        if (rawSortingField[0] == '+')
        {
            return SortingSide.Asc;
        }

        if (rawSortingField[0] == '-')
        {
            return SortingSide.Desc;
        }

        return SortingSide.Asc;
    }

    private string RemoveSortingSideFromString(string rawSortingField)
    {
        if (rawSortingField[0] == '+' || rawSortingField[0] == '-')
        {
            return rawSortingField.Substring(1);
        }

        return rawSortingField;
    }
}