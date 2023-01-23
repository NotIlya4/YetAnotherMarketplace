using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config;

public class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(100);
        builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
        builder.HasOne(b => b.ProductBrand).WithMany()
            .HasForeignKey(p => p.ProductBrandId);
        builder.HasOne(b => b.ProductType).WithMany()
            .HasForeignKey(p => p.ProductTypeId);
    }
}