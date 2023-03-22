using Api.Controllers.Attributes;
using Domain.Primitives;
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
    public async Task<IActionResult> DeleteProductById(string id)
    {
        await ProductService.DeleteProductById(new Guid(id));
        return NoContent();
    }
}