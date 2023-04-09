using Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class ProductDataConfiguration : IEntityTypeConfiguration<ProductData>
{
    public EntityTypeBuilder<ProductData> Builder { get; set; } = null!;
    
    public void Configure(EntityTypeBuilder<ProductData> builder)
    {
        Builder = builder;
        
        Id();
        Name();
        Description();
        Price();
        PictureUrl();
        ProductType();
        Brand();
    }

    private void Id()
    {
        Builder.HasKey(p => p.Id);
    }

    private void Name()
    {
        Builder.HasIndex(p => p.Name);
    }

    private void Description()
    {
        
    }

    private void Price()
    {
        Builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
    }

    private void PictureUrl()
    {
        
    }

    private void ProductType()
    {
        
    }

    private void Brand()
    {
        
    }
}