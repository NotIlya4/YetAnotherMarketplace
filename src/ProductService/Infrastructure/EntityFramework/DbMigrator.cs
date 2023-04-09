using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework;

public class DbMigrator
{
    private readonly IServiceProvider _services;

    public DbMigrator(IServiceProvider services)
    {
        _services = services;
    }
    
    public async Task Migrate()
    {
        await _services.UsingScope<ApplicationDbContext>(async dbContext => { await dbContext.Database.MigrateAsync(); });
    }
}