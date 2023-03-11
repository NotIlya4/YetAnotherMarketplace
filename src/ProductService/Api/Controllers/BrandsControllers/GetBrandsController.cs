using Api.Controllers.BrandsControllers.Dtos;
using Api.ControllersAttributes;
using Domain.Entities;
using Domain.Primitives;
using Infrastructure.ListQuery;
using Infrastructure.Services.BrandService;
using Infrastructure.SortingSystem;
using Infrastructure.SortingSystem.Core;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.BrandsControllers;

public class GetBrandsController : BrandsControllerBase
{
    private readonly SortingInfoParser<Brand> _sortingInfoParser;

    public GetBrandsController(IBrandService brandService, SortingInfoParser<Brand> sortingInfoParser) : base(brandService)
    {
        _sortingInfoParser = sortingInfoParser;
    }
    
    [HttpGet]
    [ProducesOk]
    public async Task<ActionResult<IEnumerable<BrandView>>> GetBrands([FromQuery] GetBrandsQueryView getBrandsQueryView)
    {
        Pagination pagination = getBrandsQueryView.ToPagination();

        List<SortingInfo<Brand>> parsedPropertySortingInfos =
            _sortingInfoParser.Parse(getBrandsQueryView.Sorting);
        BrandSortingInfoProvider brandSortingInfoProvider = new(parsedPropertySortingInfos);
        
        List<Brand> brands = await BrandService.GetBrands(pagination, brandSortingInfoProvider);
        
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