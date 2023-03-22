using Domain.Entities;
using Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<ProductData> Products { get; set; } = null!;
    public DbSet<BrandData> Brands { get; set; } = null!;
    public DbSet<ProductTypeData> ProductTypes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InfrastructureAssemblyReference).Assembly);
    }
}