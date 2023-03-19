using Api.Controllers.Attributes;
using Domain.Entities;
using Infrastructure.Services.ProductTypeService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ProductTypesController;

[Tags("ProductTypes")]
[Route("api/product-types")]
[ApiController]
[ProducesInternalException]
public class ProductTypesController : ControllerBase
{
    private readonly IProductTypeService _productTypeService;

    public ProductTypesController(IProductTypeService productTypeService)
    {
        _productTypeService = productTypeService;
    }

    [HttpGet]
    [ProducesOk]
    public async Task<ActionResult<IEnumerable<string>>> GetProductTypes()
    {
        List<ProductType> productTypes = await _productTypeService.GetProductTypes();
        List<string> productTypeNames = productTypes.Select(p => p.Name.Value).ToList();
        return Ok(productTypeNames);
    }
}