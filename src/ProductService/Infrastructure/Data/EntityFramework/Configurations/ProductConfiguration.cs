using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityFramework.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public EntityTypeBuilder<Product> Builder { get; set; } = null!;
    
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        Builder = builder;
        
        ConfigurePrimaryKey();
        ConfigureName();
        ConfigureBrandForeignKey();
        ConfigurePrice();
    }

    private void ConfigurePrimaryKey()
    {
        Builder
            .Property(p => p.Id)
            .HasConversion(
                p => p.Id.ToString(),
                s => new ProductId(s));
        Builder.HasKey(p => p.Id);
    }

    private void ConfigureName()
    {
        Builder
            .HasIndex(p => p.Name)
            .IsUnique();
    }

    private void ConfigureBrandForeignKey()
    {
        Builder
            .HasOne(p => p.Brand)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
    }

    private void ConfigurePrice()
    {
        Builder
            .Property(p => p.Price)
            .HasColumnType("decimal(19,4)");
    }
}