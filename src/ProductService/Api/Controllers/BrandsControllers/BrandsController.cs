using Api.Controllers.Attributes;
using Domain.Entities;
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
    public async Task<ActionResult<IEnumerable<string>>> GetBrands()
    {
        List<Brand> brands = await _brandService.GetBrands();
        List<string> brandNames = brands.Select(b => b.Name.Value).ToList();
        return Ok(brandNames);
    }
}