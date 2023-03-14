using Api.Controllers.BrandsControllers.Views;
using Domain.Entities;
using Infrastructure.Services.BrandService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.BrandsControllers;

public class CreateBrandsController : BrandsControllerBase
{
    public CreateBrandsController(IBrandService brandService) : base(brandService)
    {
        
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<BrandView>> CreateBrand(CreateBrandCommandView createBrandCommandView)
    {
        Brand brand = await BrandService.CreateNewBrand(createBrandCommandView.ToCreateBrandDto());
        BrandView brandView = BrandView.FromGetBrandDto(brand);
        
        return CreatedAtRoute(nameof(GetBrandsController.GetBrandById), new { Id = brandView.Id }, brandView);
    }
}