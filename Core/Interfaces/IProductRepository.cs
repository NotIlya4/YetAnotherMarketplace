using Core.Entities;


namespace Core.Interfaces;
public interface IProductRepository
{
    public Task<Product> GetProductByIdAsync(int id);
    public Task<IEnumerable<Product>> GetProductsAsync();
    public Task<IEnumerable<ProductBrand>> GetProductBrandsAsync();
    public Task<IEnumerable<ProductType>> GetProductTypesAsync();
}