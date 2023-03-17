using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.SortingSystemTests;

public class SortingDbContext : DbContext
{
    public DbSet<TestEntity> TestEntities { get; set; } = null!;
    
    public SortingDbContext(DbContextOptions<SortingDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}