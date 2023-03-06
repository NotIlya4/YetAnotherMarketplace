using Api.Controllers.BrandsControllers.Dtos;
using Api.ControllersAttributes;
using Domain.Entities;
using Domain.Primitives;
using Infrastructure.Services.BrandService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.BrandsControllers;

public class GetBrandsController : BrandsControllerBase
{
    public GetBrandsController(IBrandService brandService) : base(brandService)
    {
        
    }
    
    [HttpGet]
    [ProducesOk]
    public async Task<ActionResult<IEnumerable<BrandView>>> GetBrands(GetBrandsQueryView getBrandsQueryView)
    {
        List<Brand> brands = await BrandService.GetBrands(
            pagination: getBrandsQueryView.ToPagination(),
            sortingType: getBrandsQueryView.ToSortingType());
        List<BrandView> brandViews = brands.Select(BrandView.FromGetBrandDto).ToList();
        return Ok(brandViews);
    }
    
    [HttpGet]
    [Route("id/{id}", Name = nameof(GetBrandById))]
    [ProducesOk]
    [ProducesNotFound]
    public async Task<ActionResult<BrandView>> GetBrandById(Guid id)
    {
        Brand brand = await BrandService.GetBrandById(id);
        BrandView brandView = BrandView.FromGetBrandDto(brand);
        return Ok(brandView);
    }
    
    [HttpGet]
    [Route("name/{name}")]
    [ProducesOk]
    [ProducesNotFound]
    public async Task<ActionResult<BrandView>> GetBrandByName(string name)
    {
        Brand brand = await BrandService.GetBrandByName(new NotNullString(name));
        BrandView brandView = BrandView.FromGetBrandDto(brand);
        return Ok(brandView);
    }
}