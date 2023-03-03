using Infrastructure.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class WebApplicationExtensions
{
    public static void UpdateDb(this WebApplication applicationBuilder)
    {
        var logger = applicationBuilder.Services.GetRequiredService<ILogger<WebApplication>>();
        
        var dbContext = applicationBuilder.Services.GetRequiredService<ApplicationDbContext>();
        var migrations = dbContext.Database.GetPendingMigrations();
        
        foreach (var migration in migrations)
        {
            logger.LogInformation("{Migration} migration will be applied", migration);
        }
        
        dbContext.Database.Migrate();
    }
}