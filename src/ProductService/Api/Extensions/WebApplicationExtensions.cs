using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class WebApplicationExtensions
{
    public static void ApplyMigrations(this WebApplication applicationBuilder)
    {
        applicationBuilder.Services.ApplyMigrations();
    }

    public static void ApplyMigrations(this IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
            dbContext.Database.Migrate();
        }
    }

    public static void UseConfiguredCors(this WebApplication applicationBuilder)
    {
        applicationBuilder.UseCors("All");
    }
}