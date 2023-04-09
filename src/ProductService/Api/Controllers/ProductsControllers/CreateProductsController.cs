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
    private readonly IProductService _productService;
    private readonly ViewMapper _mapper;

    public CreateProductsController(IProductService productService, ViewMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesOk]
    public async Task<ActionResult<ProductView>> CreateProduct(CreateProductCommandView commandView)
    {
        Product product = await _productService.CreateNewProduct(_mapper.MapCreateProductCommand(commandView));
        ProductView productView = _mapper.MapProduct(product);
        return Ok(productView);
    }
}