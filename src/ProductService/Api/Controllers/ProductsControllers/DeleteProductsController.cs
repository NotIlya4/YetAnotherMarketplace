using Api.ProducesAttributes;
using Api.SwaggerEnrichers.ProductStrictFilterView;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ProductsControllers;

[Tags("Products")]
public class DeleteProductsController : ProductsControllerBase
{
    private readonly IProductService _productService;

    public DeleteProductsController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpDelete]
    [Route("{propertyName}/{value}")]
    [ProducesEntityNotFound]
    [ProducesNoContent]
    public async Task<IActionResult> DeleteProduct([ProductStrictFilterPropertyName] string propertyName, string value)
    {
        await _productService.DeleteProduct(new ProductStrictFilter(
            productPropertyName: propertyName, 
            expectedValue: value));
        return NoContent();
    }
}