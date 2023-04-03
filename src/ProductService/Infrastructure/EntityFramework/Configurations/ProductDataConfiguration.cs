using Domain.Entities;
using Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class ProductDataConfiguration : IEntityTypeConfiguration<ProductData>
{
    public void Configure(EntityTypeBuilder<ProductData> builder)
    {
        
    }
}