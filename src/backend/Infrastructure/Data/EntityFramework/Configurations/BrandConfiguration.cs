using Domain.Entities.Brand;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityFramework.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public EntityTypeBuilder<Brand> Builder { get; set; } = null!;

    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        Builder = builder;
        
        ConfigureKey();
        ConfigureName();
    }

    private void ConfigureKey()
    {
        Builder
            .Property(b => b.Id)
            .HasConversion(
                b => b.Id.ToString(),
                s => new BrandId(s));
        Builder
            .HasKey(b => b.Id);
    }

    private void ConfigureName()
    {
        Builder
            .HasIndex(b => b.Name)
            .IsUnique();
    }
}