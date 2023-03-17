using Api.Controllers;
using Api.Controllers.ProductsControllers;
using Domain.Entities;
using Infrastructure.EntityFramework;

namespace IntegrationTests;

public class ControllersFactory
{
    private readonly ServiceFactory _serviceFactory = new ServiceFactory();
    
    public GetProductsController CreateGetProductsController(DatabaseProvider databaseProvider)
    {
        return new GetProductsController(ServiceFactory.CreateProductService(databaseProvider),
            new SortingInfoParser<Product>());
    }
}