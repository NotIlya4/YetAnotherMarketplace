using Api.Controllers.BrandsControllers.Dtos;
using Infrastructure.Services.BrandService;
using Infrastructure.Services.BrandService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.BrandsControllers;

public class CreateBrandsController : BrandsControllerBase
{
    public CreateBrandsController(IBrandService brandService) : base(brandService)
    {
        
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<GetBrandView>> CreateBrand(CreateBrandView createBrandView)
    {
        GetBrandDto brandDto = await BrandService.CreateNewBrand(createBrandView.ToCreateBrandDto());
        GetBrandView brandView = GetBrandView.FromGetBrandDto(brandDto);
        
        return CreatedAtRoute(nameof(GetBrandsController.GetBrandById), new { Id = brandView.Id }, brandView);
    }
}