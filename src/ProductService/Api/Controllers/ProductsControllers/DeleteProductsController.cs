using Api.Controllers.ProductsControllers.Helpers;
using Api.ProducesAttributes;
using Api.SwaggerEnrichers.ProductStrictFilterView;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.Repositories.ProductRepository;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ProductsControllers;

[Tags("Products")]
public class DeleteProductsController : ProductsControllerBase
{
    private IProductRepository ProductRepository { get; }
    public ViewMapper Mapper { get; }

    public DeleteProductsController(IProductRepository productRepository, ViewMapper mapper)
    {
        ProductRepository = productRepository;
        Mapper = mapper;
    }
    
    [HttpDelete]
    [Route("{propertyName}/{value}")]
    [ProducesEntityNotFound]
    [ProducesNoContent]
    public async Task<IActionResult> DeleteProduct([ProductStrictFilterPropertyName] string propertyName, string value)
    {
        await ProductRepository.Delete(new ProductStrictFilter(
            productPropertyName: propertyName, 
            expectedValue: value));
        return NoContent();
    }
}