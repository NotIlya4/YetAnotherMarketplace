using Api.Properties;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Seeder;

namespace Api.Extensions;

public static class WebApplicationExtensions
{
    public static void UseConfiguredCors(this WebApplication applicationBuilder)
    {
        applicationBuilder.UseCors("All");
    }

    public static async Task MigrationsAndSeeding(this WebApplication applicationBuilder, ParametersProvider parameters)
    {
        if (parameters.AutoMigrate())
        {
            DbMigrator migrator = new(applicationBuilder.Services);
            await migrator.Migrate();
        }

        if (parameters.AutoSeed())
        {
            DbSeeder seeder = new(applicationBuilder.Services, new BrandsToSeed().BrandDatas,
                new ProductTypesToSeed().ProductTypeDatas, new ProductsToSeed().ProductDatas);
            await seeder.Seed();
        }
    }
}