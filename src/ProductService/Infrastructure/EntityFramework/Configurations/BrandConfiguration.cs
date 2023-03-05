using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public EntityTypeBuilder<Brand> Builder { get; set; } = null!;

    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        Builder = builder;
        
        ConfigureId();
        ConfigureName();
        ConfigureWebsite();
    }

    private void ConfigureId()
    {
        Builder
            .Property(b => b.Id)
            .HasConversion(ConvertersProvider.GetGuidConverter());
        Builder
            .HasKey(b => b.Id);
    }

    private void ConfigureName()
    {
        Builder
            .Property(b => b.Name)
            .HasConversion(ConvertersProvider.GetHandsomeStringConverter());
        Builder
            .HasIndex(b => b.Name)
            .IsUnique();
    }

    private void ConfigureWebsite()
    {
        Builder
            .Property(b => b.Website)
            .HasConversion(ConvertersProvider.GetUriConverter());
    }
}