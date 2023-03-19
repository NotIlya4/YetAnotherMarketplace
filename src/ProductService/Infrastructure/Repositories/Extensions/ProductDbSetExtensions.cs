using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Extensions;

public static class ProductDbSetExtensions
{
    public static IQueryable<Product> IncludeProductDependencies(this DbSet<Product> dbSet)
    {
        return dbSet
            .Include(p => p.Brand)
            .Include(p => p.ProductType);
    }
}