using Domain.Entities;
using Domain.Exceptions;
using ExceptionCatcherMiddleware.Extensions;
using ExceptionCatcherMiddleware.Options;
using Infrastructure.EntityFramework;
using Infrastructure.ExceptionCatching;
using Infrastructure.PropertySystem;
using Infrastructure.Repositories.BrandRepository;
using Infrastructure.Repositories.Exceptions;
using Infrastructure.Repositories.ProductRepository;
using Infrastructure.Services.BrandService;
using Infrastructure.Services.ProductService;
using Infrastructure.SortingSystem;
using Infrastructure.SortingSystem.Core;
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

    public static void AddExceptionCatcherMiddlewareServicesConfigured(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddExceptionCatcherMiddlewareServices(optionsBuilder =>
        {
            optionsBuilder.CompilePolicy = MapperMethodsCompilePolicy.CompileAllAtStart;
            
            optionsBuilder.RegisterExceptionMapper<EntityNotFoundException, EntityNotFoundExceptionMapper>();
            optionsBuilder.RegisterExceptionMapper<ValidationException, ValidationExceptionMapper>();
        });
    }

    public static void AddSortingInfoParsers(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<SortingInfoParser<Product>>();
        serviceCollection.AddScoped<SortingInfoParser<Brand>>();
    }

    public static void AddPropertyLambdaBuilders(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IPropertyLambdaBuilder<Product, object>, PropertyLambdaBuilder<Product, object>>();
        serviceCollection.AddScoped<IPropertyLambdaBuilder<Brand, object>, PropertyLambdaBuilder<Brand, object>>();
    }

    public static void AddSortingAppliers(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<SortingApplier<Product>>();
        serviceCollection.AddScoped<SortingApplier<Brand>>();
    }
}