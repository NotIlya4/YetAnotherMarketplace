using Domain.Entities;
using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ProductTypeRepository;

public class ProductTypeRepository : IProductTypeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductTypeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ProductType>> GetAll()
    {
        return await _dbContext.ProductTypes.ToListAsync();
    }

    public async Task<ProductType> GetProductTypeByName(Name name)
    {
        return await _dbContext.ProductTypes.FirstAsyncOrThrow(pt => pt.Name.Equals(name));
    }

    public async Task Insert(ProductType productType)
    {
        await _dbContext.ProductTypes.AddAsync(productType);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(ProductType productType)
    {
        _dbContext.ProductTypes.Remove(productType);
        await _dbContext.SaveChangesAsync();
    }
}