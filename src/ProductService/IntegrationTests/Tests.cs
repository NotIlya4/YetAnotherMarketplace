using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
using IntegrationTests.Fixtures.Db;

namespace IntegrationTests;

public class Tests
{
    public ApplicationDbContext DbContext { get; }
    
    public Tests(DbFixture fixture)
    {
        DbContext = fixture.DbContext;
    }

    [Fact]
    public void Test()
    {
        List<ProductData> products = DbContext.Products.ToList();
    }
}