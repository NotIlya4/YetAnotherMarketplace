using Api.Controllers.Attributes;
using Domain.Entities;
using Domain.Primitives;
using Infrastructure.Services.BrandService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.BrandsControllers;

[Tags("Brands")]
[Route("api/brands")]
[ApiController]
[ProducesInternalException]
public class BrandsController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }
    
    [HttpGet]
    [ProducesOk]
    public async Task<ActionResult<IEnumerable<BrandView>>> GetBrands()
    {
        List<Brand> brands = await _brandService.GetBrands();
        List<BrandView> brandNames = brands.Select(BrandView.FromDomain).ToList();
        return Ok(brandNames);
    }

    [HttpPost]
    [Route("{brandName}")]
    [ProducesOk]
    public async Task<ActionResult<BrandView>> AddBrand(string brandName)
    {
        Brand brand = await _brandService.Add(new Name(brandName));
        return Ok(BrandView.FromDomain(brand));
    }

    [HttpDelete]
    [Route("{brandName}")]
    [ProducesNoContent]
    public async Task<ActionResult> DeleteBrand(string brandName)
    {
        await _brandService.Delete(new Name(brandName));
        return NoContent();
    }
}