using Api.Controllers.Attributes;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ProductsControllers;

[Tags("Products")]
public class DeleteProductsController : ProductsControllerBase
{
    public DeleteProductsController(IProductService productService) : base(productService)
    {
    }
    
    [HttpDelete]
    [Route("{propertyName}/{value}")]
    [ProducesProductNotFound]
    [ProducesNoContent]
    public async Task<IActionResult> DeleteProductById(string propertyName, string value)
    {
        await ProductService.DeleteProduct(new ProductStrictFilter(propertyName, value));
        return NoContent();
    }
}