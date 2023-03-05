using Domain.Exceptions;
using ExceptionCatcherMiddleware.Extensions;
using ExceptionCatcherMiddleware.Options;
using Infrastructure.EntityFramework;
using Infrastructure.ExceptionCatching;
using Infrastructure.Repositories.BrandRepository;
using Infrastructure.Repositories.Exceptions;
using Infrastructure.Repositories.ProductRepository;
using Infrastructure.Services.BrandService;
using Infrastructure.Services.ProductService;
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
}