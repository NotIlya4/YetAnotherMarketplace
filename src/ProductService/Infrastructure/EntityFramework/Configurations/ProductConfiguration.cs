using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public EntityTypeBuilder<Product> Builder { get; set; } = null!;
    
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        Builder = builder;
        
        ConfigureId();
        ConfigureName();
        ConfigureDescription();
        ConfigurePrice();
        ConfigurePictureUrl();
        ConfigureProductType();
        ConfigureBrand();
    }
    
    private void ConfigureId()
    {
        Builder
            .Property(p => p.Id)
            .HasConversion(ConvertersProvider.GetGuidConverter());
        Builder
            .HasKey(p => p.Id);
    }

    private void ConfigureName()
    {
        Builder
            .Property(p => p.Name)
            .HasConversion(ConvertersProvider.GetNameConverter());
        Builder
            .HasIndex(p => p.Name)
            .IsUnique();
    }
    
    private void ConfigureDescription()
    {
        Builder
            .Property(p => p.Description)
            .HasConversion(ConvertersProvider.GetDescriptionConverter());
    }

    private void ConfigurePrice()
    {
        Builder
            .Property(p => p.Price)
            .HasConversion(ConvertersProvider.GetPriceConverter());
        Builder
            .Property(p => p.Price)
            .HasColumnType("decimal(19,4)");
    }
    
    private void ConfigurePictureUrl()
    {
        Builder
            .Property(p => p.PictureUrl)
            .HasConversion(ConvertersProvider.GetUriConverter());
    }
    
    private void ConfigureProductType()
    {
        Builder
            .HasOne(p => p.ProductType)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
    }

    private void ConfigureBrand()
    {
        Builder
            .HasOne(p => p.Brand)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
    }
}