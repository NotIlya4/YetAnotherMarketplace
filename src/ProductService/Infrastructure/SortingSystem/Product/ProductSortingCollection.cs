namespace Infrastructure.SortingSystem.Product;

public class ProductSortingCollection
{
    public ProductSorting PrimarySorting { get; }
    public List<ProductSorting> SecondarySortings { get; }

    public ProductSortingCollection(ProductSorting sorting) 
        : this(new List<ProductSorting>() {sorting})
    {
        
    }
    
    public ProductSortingCollection(List<ProductSorting> sortingInfos)
    {
        PrimarySorting = sortingInfos.Count == 0
            ? new ProductSorting(ProductSortingProperty.Name, SortingSide.Asc)
            : sortingInfos[0];
        SecondarySortings = sortingInfos.Skip(1).ToList();
    }
}