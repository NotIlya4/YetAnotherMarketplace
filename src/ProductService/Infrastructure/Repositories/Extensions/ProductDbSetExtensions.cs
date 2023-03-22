using Domain.Entities;
using Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Extensions;

public static class ProductDbSetExtensions
{
    public static IQueryable<ProductData> IncludeProductDependencies(this DbSet<ProductData> dbSet)
    {
        return dbSet
            .Include(p => p.Brand)
            .Include(p => p.ProductType);
    }
}