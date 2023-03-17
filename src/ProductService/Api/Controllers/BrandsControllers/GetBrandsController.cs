using Api.Controllers.Attributes;
using Api.Controllers.BrandsControllers.Views;
using Domain.Entities;
using Domain.Primitives;
using Infrastructure.FilteringSystem;
using Infrastructure.Services.BrandService;
using Infrastructure.SortingSystem.Models;
using Infrastructure.SortingSystem.SortingInfoProviders;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.BrandsControllers;

[Tags("Brands")]
public class GetBrandsController : BrandsControllerBase
{
    public GetBrandsController(IBrandService brandService) : base(brandService)
    {
    }
    
    [HttpGet]
    [ProducesOk]
    public async Task<ActionResult<IEnumerable<BrandView>>> GetBrands()
    {
        List<Brand> brands = await BrandService.GetBrands();
        List<BrandView> brandViews = brands.Select(BrandView.FromGetBrandDto).ToList();
        return Ok(brandViews);
    }

    [HttpGet]
    [Route("name/{name}", Name = nameof(GetBrandByName))]
    [ProducesOk]
    [ProducesBrandNotFound]
    public async Task<ActionResult<BrandView>> GetBrandByName(string name)
    {
        Brand brand = await BrandService.GetBrandByName(new Name(name));
        BrandView brandView = BrandView.FromGetBrandDto(brand);
        return Ok(brandView);
    }
}