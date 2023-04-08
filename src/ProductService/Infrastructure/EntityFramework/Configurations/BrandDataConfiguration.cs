using Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class BrandDataConfiguration : IEntityTypeConfiguration<BrandData>
{
    public void Configure(EntityTypeBuilder<BrandData> builder)
    {
        
    }
}