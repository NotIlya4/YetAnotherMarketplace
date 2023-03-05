using Api.Controllers.BrandsControllers.Dtos;
using Api.ControllersAttributes;
using Domain.Primitives;
using Infrastructure.Repositories.Primitives;
using Infrastructure.Services.BrandService;
using Infrastructure.Services.BrandService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.BrandsControllers;

public class GetBrandsController : BrandsControllerBase
{
    public GetBrandsController(IBrandService brandService) : base(brandService)
    {
        
    }
    
    [HttpGet]
    [ProducesOk]
    public async Task<ActionResult<IEnumerable<GetBrandView>>> GetBrands(int offset, int limit)
    {
        List<GetBrandDto> brandDtos = await BrandService.GetBrands(new Pagination(offset, limit));
        List<GetBrandView> brandViews = brandDtos.Select(GetBrandView.FromGetBrandDto).ToList();
        return Ok(brandViews);
    }
    
    [HttpGet]
    [Route("id/{id}", Name = nameof(GetBrandById))]
    [ProducesOk]
    [ProducesNotFound]
    public async Task<ActionResult<GetBrandView>> GetBrandById(Guid id)
    {
        GetBrandDto brandDto = await BrandService.GetBrandById(id);
        GetBrandView brandView = GetBrandView.FromGetBrandDto(brandDto);
        return Ok(brandView);
    }
    
    [HttpGet]
    [Route("name/{name}")]
    [ProducesOk]
    [ProducesNotFound]
    public async Task<ActionResult<GetBrandView>> GetBrandByName(string name)
    {
        GetBrandDto brandDto = await BrandService.GetBrandByName(new NotNullString(name));
        GetBrandView brandView = GetBrandView.FromGetBrandDto(brandDto);
        return Ok(brandView);
    }
}