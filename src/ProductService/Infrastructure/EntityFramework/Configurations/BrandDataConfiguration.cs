using Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class BrandDataConfiguration : IEntityTypeConfiguration<BrandData>
{
    private EntityTypeBuilder<BrandData> Builder { get; set; } = null!;
    
    public void Configure(EntityTypeBuilder<BrandData> builder)
    {
        Builder = builder;

        Id();
        Name();
    }


    private void Id()
    {
        Builder.HasKey(b => b.Id);
    }

    private void Name()
    {
        Builder.HasIndex(b => b.Name);
    }
}