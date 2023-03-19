using Api.Controllers;
using Api.Swagger.EnricherSystem.Extensions;
using Api.Swagger.NullableSystem;
using Domain.Exceptions;
using ExceptionCatcherMiddleware.Extensions;
using ExceptionCatcherMiddleware.Options;
using Infrastructure.EntityFramework;
using Infrastructure.ExceptionCatching;
using Infrastructure.Repositories.BrandRepository;
using Infrastructure.Repositories.Exceptions;
using Infrastructure.Repositories.ProductRepository;
using Infrastructure.Repositories.ProductTypeRepository;
using Infrastructure.Services.BrandService;
using Infrastructure.Services.ProductService;
using Infrastructure.Services.ProductTypeService;
using Infrastructure.SortingSystem;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class DiExtensions
{
    public static void AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProductService, ProductService>();
        serviceCollection.AddScoped<IBrandService, BrandService>();
        serviceCollection.AddScoped<IProductTypeService, ProductTypeService>();
        serviceCollection.AddScoped<SortingInfoParser>();
    }
    
    public static void AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProductRepository, ProductRepository>();
        serviceCollection.AddScoped<IBrandRepository, BrandRepository>();
        serviceCollection.AddScoped<IProductTypeRepository, ProductTypeRepository>();
        serviceCollection.AddScoped<SortingApplier>();
        serviceCollection.AddScoped<PropertyReflections>();
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

    public static void AddConfiguredSwaggerGen(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSwaggerGen(options =>
        {
            options.DescribeAllParametersInCamelCase();
            options.AddNullableFilters();
            options.AddEnricherFilters();
            options.EnableAnnotations();
        });
    }
}