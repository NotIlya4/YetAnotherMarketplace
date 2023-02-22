using Infrastructure.BrandService;
using Infrastructure.BrandService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.BrandsControllers;

public class CreateBrandsController : BrandsControllerBase
{
    public CreateBrandsController(IBrandService brandService) : base(brandService)
    {
        
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<GetBrandDto>> CreateProduct(CreateBrandDto createBrandDto)
    {
        GetBrandDto brandDto = await BrandService.CreateNewBrand(createBrandDto);
        // return CreatedAtAction(nameof(GetBrandsController.GetBrandById), new { Id = brandDto.Id }, brandDto);
        return CreatedAtRoute(nameof(GetBrandsController.GetBrandById), new { Id = brandDto.Id }, brandDto);
    }
}