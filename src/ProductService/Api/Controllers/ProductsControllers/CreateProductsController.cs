using Api.Controllers.ProductsControllers.Helpers;
using Api.Controllers.ProductsControllers.Views;
using Api.ProducesAttributes;
using Domain.Entities;
using Infrastructure.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ProductsControllers;

[Tags("Products")]
public class CreateProductsController : ProductsControllerBase
{
    private IProductService ProductService { get; }
    private ViewMapper Mapper { get; }

    public CreateProductsController(IProductService productService, ViewMapper mapper)
    {
        ProductService = productService;
        Mapper = mapper;
    }

    [HttpPost]
    [ProducesOk]
    public async Task<ActionResult<ProductView>> CreateProduct(CreateProductCommandView commandView)
    {
        Product product = await ProductService.CreateNewProduct(Mapper.MapCreateProductCommand(commandView));
        ProductView productView = Mapper.MapProduct(product);
        return Ok(productView);
    }
}