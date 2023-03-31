using Domain.Entities;
using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
using Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ProductTypeRepository;

public class ProductTypesRepository : IProductTypesRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductTypesRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ProductType>> GetProductTypes()
    {
        List<ProductTypeData> productTypeDatas = await _dbContext.ProductTypes.OrderBy(pt => pt.Name).ToListAsync();
        List<ProductType> productTypes = productTypeDatas.Select(p => p.ToDomain()).ToList();
        return productTypes;
    }

    public async Task<ProductType> GetProductType(Name name)
    {
        ProductTypeData productTypeData = await _dbContext.ProductTypes.FirstAsyncOrThrow(pt => pt.Name.Equals(name));
        return productTypeData.ToDomain();
    }

    public async Task Insert(ProductType productType)
    {
        await _dbContext.ProductTypes.AddAsync(ProductTypeData.FromDomain(productType));
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(ProductType productType)
    {
        _dbContext.ProductTypes.Remove(ProductTypeData.FromDomain(productType));
        await _dbContext.SaveChangesAsync();
    }
}