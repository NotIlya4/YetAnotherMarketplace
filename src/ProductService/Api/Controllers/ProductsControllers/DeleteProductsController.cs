using Api.Controllers.Attributes;
using Domain.Primitives;
using Infrastructure.Services.BrandService;
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
    [Route("id/{id}")]
    [ProducesProductNotFound]
    [ProducesNoContent]
    public async Task<IActionResult> DeleteProductById(Guid id)
    {
        await ProductService.DeleteProductById(id);
        return NoContent();
    }
    
    [HttpDelete]
    [Route("name/{name}")]
    [ProducesProductNotFound]
    [ProducesNoContent]
    public async Task<IActionResult> DeleteProductById(string name)
    {
        await ProductService.DeleteProductByName(new NotNullString(name));
        return NoContent();
    }
}