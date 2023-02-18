using Domain.Entities.Brand;
using Domain.Entities.Product;
using Infrastructure.Data.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.EntityFramework;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Brand> Brands { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
    }
}