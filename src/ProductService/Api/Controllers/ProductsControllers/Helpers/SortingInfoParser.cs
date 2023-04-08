using Infrastructure.SortingSystem;
using Infrastructure.SortingSystem.Product;

namespace Api.Controllers.ProductsControllers.Helpers;

public class SortingInfoParser
{
    public ProductSorting ParseProductSortingInfo(string rawSortingInfo)
    {
        SortingSide sortingSide = GetSortingSide(rawSortingInfo);
        string propertyName = RemoveSortingSideFromString(rawSortingInfo);

        return new ProductSorting(propertyName, sortingSide);
    }
    
    public List<ProductSorting> ParseProductSortingInfo(IEnumerable<string> rawSortingInfos)
    {
        return rawSortingInfos.Select(ParseProductSortingInfo).ToList();
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