using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class WebApplicationExtensions
{
    public static void ApplyMigrations(this WebApplication applicationBuilder)
    {
        var logger = applicationBuilder.Services.GetRequiredService<ILogger<WebApplication>>();

        using (var scope = applicationBuilder.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var migrations = dbContext.Database.GetPendingMigrations();
        
            foreach (var migration in migrations)
            {
                logger.LogInformation("{Migration} migration will be applied", migration);
            }
        
            dbContext.Database.Migrate();
        }
    }
}