using Api.Controllers.ProductsControllers.Helpers;
using Api.SwaggerMakeAllRequiredFilters;
using Domain.Exceptions;
using ExceptionCatcherMiddleware.Extensions;
using ExceptionCatcherMiddleware.Options;
using Infrastructure.EntityFramework;
using Infrastructure.ExceptionCatching;
using Infrastructure.ProductService;
using Infrastructure.Repositories.BrandRepository;
using Infrastructure.Repositories.Exceptions;
using Infrastructure.Repositories.ProductRepository;
using Infrastructure.Repositories.ProductTypeRepository;
using Microsoft.EntityFrameworkCore;
using SwaggerEnrichers.Extensions;

namespace Api.Extensions;

public static class DiExtensions
{
    public static void AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProductService, ProductService>();
        serviceCollection.AddScoped<SortingInfoParser>();
    }
    
    public static void AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProductRepository, ProductRepository>();
        serviceCollection.AddScoped<IBrandRepository, BrandRepository>();
        serviceCollection.AddScoped<IProductTypeRepository, ProductTypeRepository>();
    }

    public static void AddAppDbContext(this IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddDbContext<ApplicationDbContext>(builder =>
        {
            builder.UseSqlServer(connectionString, b => b.MigrationsAssembly("Infrastructure"));
            builder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
    }

    public static void AddConfiguredCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("All", policyBuilder =>
            {
                policyBuilder.AllowAnyHeader();
                policyBuilder.AllowAnyMethod();
                policyBuilder.AllowAnyOrigin();
            });
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

    public static void AddMappers(this IServiceCollection services)
    {
        services.AddScoped<DataMapper>();
        services.AddScoped<ViewMapper>();
    }

    public static void AddConfiguredSwaggerGen(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSwaggerGen(options =>
        {
            options.DescribeAllParametersInCamelCase();
            options.AddRequiredFilters();
            options.AddEnricherFilters();
            options.EnableAnnotations();
        });
    }
}