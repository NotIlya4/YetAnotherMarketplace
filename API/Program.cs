using API.Helpers;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.

services.AddControllers();
services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
services.AddAutoMapper(typeof(MappingProfiles));
services.AddDbContext<StoreContext>(options => { options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")); });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    ILogger logger = app.Services.GetRequiredService<ILoggerFactory>().CreateLogger<string>();
    StoreContext dbContext = scope.ServiceProvider.GetRequiredService<StoreContext>();
    try
    {
        await dbContext.Database.MigrateAsync();
    }
    catch (OperationCanceledException e)
    {
        logger.LogError(e, "Error occured during migration");
        throw;
    }
    await StoreContextSeed.SeedAsync(dbContext);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();