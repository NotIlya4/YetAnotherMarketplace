namespace Infrastructure.SortingSystem.Product;

public class ProductSortingInfoCollection
{
    public ProductSortingInfo PrimarySorting { get; }
    public List<ProductSortingInfo> SecondarySortings { get; }

    public ProductSortingInfoCollection(ProductSortingInfo sortingInfo) 
        : this(new List<ProductSortingInfo>() {sortingInfo})
    {
        
    }
    
    public ProductSortingInfoCollection(List<ProductSortingInfo> sortingInfos)
    {
        PrimarySorting = sortingInfos.Count == 0
            ? new ProductSortingInfo(ProductSortingProperty.Name, SortingSide.Asc)
            : sortingInfos[0];
        SecondarySortings = sortingInfos.Skip(1).ToList();
    }
}