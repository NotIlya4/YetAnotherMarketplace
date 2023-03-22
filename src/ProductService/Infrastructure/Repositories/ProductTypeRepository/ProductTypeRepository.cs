using Domain.Entities;
using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
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
        List<ProductTypeData> productTypeDatas = await _dbContext.ProductTypes.ToListAsync();
        List<ProductType> productTypes = productTypeDatas.Select(p => p.ToDomain()).ToList();
        return productTypes;
    }

    public async Task<ProductType> GetProductTypeByName(Name name)
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