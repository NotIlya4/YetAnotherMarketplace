using Domain.Entities.Brand;
using Domain.Entities.Product;
using ExceptionCatcherMiddleware.Extensions;
using ExceptionCatcherMiddleware.Options;
using Infrastructure.BrandService;
using Infrastructure.Data.EntityFramework;
using Infrastructure.Data.Repositories.BrandRepository;
using Infrastructure.Data.Repositories.ProductRepository;
using Infrastructure.Data.Repositories.QueryableExtensions;
using Infrastructure.ExceptionCatching;
using Infrastructure.Helpers;
using Infrastructure.ProductService;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class DiExtensions
{
    public static void AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProductService, ProductService>();
        serviceCollection.AddScoped<IBrandService, BrandService>();
    }
    
    public static void AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProductRepository, ProductRepository>();
        serviceCollection.AddScoped<IBrandRepository, BrandRepository>();
    }

    public static void AddAppDbContext(this IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddDbContext<ApplicationDbContext>(builder =>
        {
            builder.UseSqlServer(connectionString, b => b.MigrationsAssembly("Infrastructure"));
        });
    }

    public static void AddDomainModelsIdGenerators(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProductIdFactory, GuidFactory>();
        serviceCollection.AddScoped<IBrandIdFactory, GuidFactory>();
    }

    public static void AddExceptionCatcherMiddlewareServicesConfigured(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddExceptionCatcherMiddlewareServices(optionsBuilder =>
        {
            optionsBuilder.CompilePolicy = MapperMethodsCompilePolicy.CompileAllAtStart;
            
            optionsBuilder.RegisterExceptionMapper<EntityNotFoundException, EntityNotFoundExceptionMapper>();
        });
    }
}