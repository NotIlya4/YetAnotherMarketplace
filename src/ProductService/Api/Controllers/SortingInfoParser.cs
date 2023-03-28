using Infrastructure.SortingSystem;

namespace Api.Controllers;

public class SortingInfoParser
{
    public SortingInfo<TEntity> Parse<TEntity>(string rawPropertySortingInfo)
    {
        SortingSide sortingSide = GetSortingSide(rawPropertySortingInfo);
        string rawPropertyName = RemoveSortingSideFromString(rawPropertySortingInfo);

        return new SortingInfo<TEntity>(rawPropertyName, sortingSide);
    }

    public List<SortingInfo<TEntity>> Parse<TEntity>(IEnumerable<string>? rawPropertySortingInfos)
    {
        if (rawPropertySortingInfos is null)
        {
            return new List<SortingInfo<TEntity>>();
        }
        return rawPropertySortingInfos.Select(Parse<TEntity>).ToList();
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