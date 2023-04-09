using Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class ProductTypeDataConfiguration : IEntityTypeConfiguration<ProductTypeData>
{
    private EntityTypeBuilder<ProductTypeData> Builder { get; set; } = null!;
    
    public void Configure(EntityTypeBuilder<ProductTypeData> builder)
    {
        Builder = builder;
        
        Id();
        Name();
    }

    private void Id()
    {
        Builder.HasKey(p => p.Id);
    }

    private void Name()
    {
        Builder.HasIndex(p => p.Name);
    }
}