using Infrastructure.BrandService;
using Infrastructure.BrandService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet]
    public async Task<List<GetBrandDto>> GetBrands()
    {
        return await _brandService.GetBrands();
    }

    [HttpGet]
    [Route("id/{id}")]
    public async Task<GetBrandDto> GetBrandById(string id)
    {
        return await _brandService.GetBrandById(id);
    }

    [HttpPost]
    public async Task CreateProduct(CreateBrandDto createBrandDto)
    {
        await _brandService.CreateNewBrand(createBrandDto);
    }

    [HttpGet]
    [Route("name/{name}")]
    public async Task<GetBrandDto> GetBrandByName(string name)
    {
        return await _brandService.GetBrandByName(name);
    }
}
