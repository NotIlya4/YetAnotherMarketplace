using Api.Controllers.Attributes;
using Domain.Entities;
using Domain.Primitives;
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
    public async Task<ActionResult<IEnumerable<ProductTypeView>>> GetProductTypes()
    {
        List<ProductType> productTypes = await _productTypeService.GetProductTypes();
        List<ProductTypeView> productTypeNames = productTypes.Select(ProductTypeView.FromDomain).ToList();
        return Ok(productTypeNames);
    }

    [HttpPost]
    [ProducesOk]
    public async Task<ActionResult<ProductTypeView>> AddProductType(string productTypeName)
    {
        ProductType productType = await _productTypeService.Add(new Name(productTypeName));
        return Ok(ProductTypeView.FromDomain(productType));
    }

    [HttpDelete]
    [ProducesNoContent]
    public async Task<ActionResult> DeleteProductType(string productTypeName)
    {
        await _productTypeService.Delete(new Name(productTypeName));
        return NoContent();
    }
}