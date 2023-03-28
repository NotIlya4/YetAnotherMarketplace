using Microsoft.EntityFrameworkCore;

namespace UnitTests.Infrastructure.Repositories.Extensions.QueryableExtensions.DbFixture;

[CollectionDefinition(nameof(QueryableDbFixture))]
public class QueryableDbFixture : IDisposable, ICollectionFixture<QueryableDbFixture>
{
    public QueryableDbContext DbContext { get; }
    
    public QueryableDbFixture()
    {
        var entitiesProvider = new QueryableTestEntityList();
        
        DbContextOptions<QueryableDbContext> options = new DbContextOptionsBuilder<QueryableDbContext>()
            .UseInMemoryDatabase("SortingTest")
            .Options;
        DbContext = new QueryableDbContext(options);

        DbContext.TestEntities.AddRange(entitiesProvider.Entities);
        DbContext.SaveChanges();
    }

    public void Dispose()
    {
        DbContext.Dispose();
    }
}