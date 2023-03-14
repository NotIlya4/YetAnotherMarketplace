using Api.Controllers.Attributes;
using Infrastructure.Services.BrandService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.BrandsControllers;

[Route("api/Brands")]
[ApiController]
[ProducesInternalException]
public class BrandsControllerBase : ControllerBase
{
    protected IBrandService BrandService { get; }

    public BrandsControllerBase(IBrandService brandService)
    {
        BrandService = brandService;
    }
}