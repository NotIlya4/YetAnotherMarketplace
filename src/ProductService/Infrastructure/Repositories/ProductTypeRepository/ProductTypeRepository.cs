using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
using Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ProductTypeRepository;

public class ProductTypeRepository : IProductTypeRepository
{
    private DataMapper Mapper { get; }
    private ApplicationDbContext DbContext { get; }

    public ProductTypeRepository(ApplicationDbContext dbContext, DataMapper mapper)
    {
        Mapper = mapper;
        DbContext = dbContext;
    }

    public async Task<List<Name>> GetProductTypes()
    {
        List<ProductTypeData> productTypeDatas = await DbContext.ProductTypes.OrderBy(pt => pt.Name).ToListAsync();
        return Mapper.MapProductType(productTypeDatas);
    }

    public async Task Add(Name productType)
    {
        ProductTypeData productTypeData = Mapper.MapProductType(Guid.NewGuid(), productType);
        DbContext.SetEntry(productTypeData);
        
        await DbContext.ProductTypes.AddAsync(productTypeData);
        await DbContext.SaveChangesAsync();
    }

    public async Task Delete(Name productType)
    {
        ProductTypeData productTypeData = await DbContext.ProductTypes.FirstAsyncOrThrow(p => p.Name == productType.Value);
        DbContext.SetEntry(productTypeData);
        
        DbContext.ProductTypes.Remove(productTypeData);
        await DbContext.SaveChangesAsync();
    }
}