using Domain.Entities;
using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ProductTypeRepository;

class ProductTypeRepository : IProductTypeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductTypeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<ProductType>> GetProductTypes()
    {
        return await _dbContext.ProductTypes.ToListAsync();
    }

    public async Task<ProductType> GetProductTypeByName(Name productType)
    {
        return await _dbContext
            .ProductTypes
            .FirstAsyncOrThrow<ProductTypeRepository, ProductType>(p => p.Name == productType);
    }
}