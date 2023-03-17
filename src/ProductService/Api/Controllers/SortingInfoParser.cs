using Infrastructure.SortingSystem.Models;

namespace Api.Controllers;

public class SortingInfoParser<TEntity>
{
    public SortingInfo<TEntity> Parse(string rawPropertySortingInfo)
    {
        SortingSide sortingSide = GetSortingSide(rawPropertySortingInfo);
        string rawPropertyName = RemoveSortingSideFromString(rawPropertySortingInfo);

        return new SortingInfo<TEntity>(rawPropertyName, sortingSide);
    }

    public List<SortingInfo<TEntity>> Parse(IEnumerable<string> rawPropertySortingInfos)
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