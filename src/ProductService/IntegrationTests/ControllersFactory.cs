using Api.Controllers;
using Api.Controllers.ProductsControllers;

namespace IntegrationTests;

public class ControllersFactory
{
    public GetProductsController CreateGetProductsController(DatabaseProvider databaseProvider)
    {
        return new GetProductsController(ServiceFactory.CreateProductService(databaseProvider),
            new SortingInfoParser());
    }
}