using Api.ProducesAttributes;
using Domain.Primitives;
using Infrastructure.Repositories.ProductTypeRepository;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Tags("ProductTypes")]
[Route("api/product-types")]
[ApiController]
[ProducesInternalException]
public class ProductTypesController : ControllerBase
{
    private IProductTypeRepository ProductTypeRepository { get; }

    public ProductTypesController(IProductTypeRepository productTypeRepository)
    {
        ProductTypeRepository = productTypeRepository;
    }

    [HttpGet]
    [ProducesOk]
    public async Task<ActionResult<IEnumerable<string>>> GetProductTypes()
    {
        List<Name> productTypes = await ProductTypeRepository.GetProductTypes();
        return Ok(productTypes.Select(p => p.Value));
    }

    [HttpPost]
    [Route("{productType}")]
    [ProducesNoContent]
    public async Task<ActionResult> Add(string productType)
    {
        await ProductTypeRepository.Add(new Name(productType));
        return NoContent();
    }

    [HttpDelete]
    [Route("{productType}")]
    [ProducesNoContent]
    public async Task<ActionResult> Delete(string productType)
    {
        await ProductTypeRepository.Delete(new Name(productType));
        return NoContent();
    }
}