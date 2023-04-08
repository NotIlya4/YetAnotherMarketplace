using Api.ProducesAttributes;
using Domain.Primitives;
using Infrastructure.Repositories.BrandRepository;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Tags("Brands")]
[Route("api/brands")]
[ApiController]
[ProducesInternalException]
public class BrandsController : ControllerBase
{
    private IBrandRepository BrandRepository { get; }

    public BrandsController(IBrandRepository brandRepository)
    {
        BrandRepository = brandRepository;
    }
    
    [HttpGet]
    [ProducesOk]
    public async Task<ActionResult<List<string>>> GetBrands()
    {
        List<Name> brands = await BrandRepository.GetBrands();
        return Ok(brands.Select(b => b.Value).ToList());
    }

    [HttpPost]
    [Route("{brand}")]
    [ProducesNoContent]
    public async Task<ActionResult> Add(string brand)
    {
        await BrandRepository.Add(new Name(brand));
        return NoContent();
    }

    [HttpDelete]
    [Route("{brand}")]
    [ProducesNoContent]
    public async Task<ActionResult> Delete(string brand)
    {
        await BrandRepository.Delete(new Name(brand));
        return NoContent();
    }
}