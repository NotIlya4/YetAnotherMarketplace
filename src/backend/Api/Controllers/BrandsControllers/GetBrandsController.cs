using Api.ControllersAttributes;
using Infrastructure.BrandService;
using Infrastructure.BrandService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.BrandsControllers;

public class GetBrandsController : BrandsControllerBase
{
    public GetBrandsController(IBrandService brandService) : base(brandService)
    {
        
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<GetBrandDto>>> GetBrands()
    {
        return Ok(await BrandService.GetBrands());
    }
    
    [HttpGet]
    [Route("id/{id}", Name = nameof(GetBrandById))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesEntityNotFound]
    public async Task<ActionResult<GetBrandDto>> GetBrandById(string id)
    {
        return Ok(await BrandService.GetBrandById(id));
    }
    
    [HttpGet]
    [Route("name/{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesEntityNotFound]
    public async Task<ActionResult<GetBrandDto>> GetBrandByName(string name)
    {
        return Ok(await BrandService.GetBrandByName(name));
    }
}