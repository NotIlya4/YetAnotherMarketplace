using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.SortingSystemTests;

public class SortingDbFixture : IDisposable
{
    public SortingDbContext DbContext { get; }
    
    public SortingDbFixture()
    {
        var entitiesProvider = new TestEntityList();
        
        DbContextOptions<SortingDbContext> options = new DbContextOptionsBuilder<SortingDbContext>()
            .UseInMemoryDatabase("SortingTest")
            .Options;
        DbContext = new SortingDbContext(options);

        DbContext.TestEntities.AddRange(entitiesProvider.Entities);
        DbContext.SaveChanges();
    }

    public void Dispose()
    {
        DbContext.Dispose();
    }
}