using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
using Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BrandRepository;

public class BrandRepository : IBrandRepository
{
    private DataMapper Mapper { get; }
    private ApplicationDbContext DbContext { get; }

    public BrandRepository(ApplicationDbContext dbContext, DataMapper mapper)
    {
        Mapper = mapper;
        DbContext = dbContext;
    }

    public async Task<List<Name>> GetBrands()
    {
        List<BrandData> brandDatas = await DbContext.Brands.OrderBy(b => b.Name).ToListAsync();
        return Mapper.MapBrand(brandDatas);
    }

    public async Task Add(Name brand)
    {
        BrandData brandData = Mapper.MapBrand(Guid.NewGuid(), brand);
        DbContext.SetEntry(brandData);
        
        await DbContext.Brands.AddAsync(brandData);
        await DbContext.SaveChangesAsync();
    }

    public async Task Delete(Name brand)
    {
        BrandData brandData = await DbContext.GetBrand(brand);
        DbContext.Brands.Remove(brandData);
        await DbContext.SaveChangesAsync();
    }
}