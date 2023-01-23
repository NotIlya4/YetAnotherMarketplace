using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ProductRepository : IProductRepository
{
    public StoreContext _context;

    public ProductRepository(StoreContext context)
    {
        _context = context;
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _context.Products
            .Include(p => p.ProductBrand)
            .Include(p => p.ProductType)
            .FirstAsync(p => p.Id == id) ?? throw new ArgumentNullException();
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _context.Products
            .Include(p => p.ProductBrand)
            .Include(p => p.ProductType)
            .ToListAsync();
    }

    public async Task<IEnumerable<ProductBrand>> GetProductBrandsAsync()
    {
        return await _context.ProductBrands.ToListAsync();
    }

    public async Task<IEnumerable<ProductType>> GetProductTypesAsync()
    {
        return await _context.ProductTypes.ToListAsync();
    }
}