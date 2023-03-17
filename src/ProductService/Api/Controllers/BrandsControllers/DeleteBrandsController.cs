using Api.Controllers.Attributes;
using Domain.Primitives;
using Infrastructure.Services.BrandService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.BrandsControllers;

[Tags("Brands")]
public class DeleteBrandsController : BrandsControllerBase
{
    public DeleteBrandsController(IBrandService brandService) : base(brandService)
    {
    }
    
    [HttpDelete]
    [Route("name/{name}")]
    [ProducesBrandNotFound]
    [ProducesNoContent]
    public async Task<IActionResult> DeleteBrandByName(string name)
    {
        await BrandService.DeleteBrandByName(new Name(name));
        return NoContent();
    }
}