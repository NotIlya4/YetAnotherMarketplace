using Microsoft.EntityFrameworkCore;

namespace UnitTests.Infrastructure.Repositories.Extensions.QueryableExtensions.DbFixture;

public class QueryableDbContext : DbContext
{
    public DbSet<QueryableTestEntity> TestEntities { get; set; } = null!;
    
    public QueryableDbContext(DbContextOptions<QueryableDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}