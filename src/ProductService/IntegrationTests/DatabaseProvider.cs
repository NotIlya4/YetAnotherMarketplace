using Infrastructure.EntityFramework;
using Infrastructure.Repositories.BrandRepository;
using Infrastructure.Repositories.ProductRepository;
using Infrastructure.Repositories.ProductTypeRepository;
using Infrastructure.SortingSystem;
using IntegrationTests.EntityFactories;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests;

public class DatabaseProvider : IAsyncLifetime
{
    public ProductProvider ProductProvider { get; private set; } = null!;
    public ProductTypeProvider ProductTypeProvider { get; private set; } = null!;
    public BrandProvider BrandProvider { get; private set; } = null!;

    public ProductRepository ProductRepository { get; private set; } = null!;
    public ProductTypeRepository ProductTypeRepository { get; private set; } = null!;
    public BrandRepository BrandRepository { get; private set; } = null!;
    
    public ApplicationDbContext DbContext { get; private set; } = null!;

    public async Task InitializeAsync()
    {
        BrandProvider = new BrandProvider();
        ProductTypeProvider = new ProductTypeProvider();
        ProductProvider = new ProductProvider(ProductTypeProvider, BrandProvider);
        
        DbContext = CreateDbContext();

        await Seed();

        ProductRepository = CreateProductRepository();
        ProductTypeRepository = CreateProductTypeRepository();
        BrandRepository = CreateBrandRepository();
    }

    private ApplicationDbContext CreateDbContext()
    {
        DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("Db")
            .Options;

        return new ApplicationDbContext(options);
    }

    private async Task Seed()
    {
        await DbContext.ProductTypes.AddRangeAsync(ProductTypeProvider.ProductTypes);
        await DbContext.Brands.AddRangeAsync(BrandProvider.Brands);
        await DbContext.Products.AddRangeAsync(ProductProvider.Products);
        
        await DbContext.SaveChangesAsync();
    }

    private ProductRepository CreateProductRepository()
    {
        SortingApplier sortingApplier = new(new PropertyReflections());
        
        return new ProductRepository(DbContext, sortingApplier);
    }

    private BrandRepository CreateBrandRepository()
    {
        return new BrandRepository(DbContext);
    }

    private ProductTypeRepository CreateProductTypeRepository()
    {
        return new ProductTypeRepository(DbContext);
    }

    public async Task DisposeAsync()
    {
        await DbContext.DisposeAsync();
    }
}