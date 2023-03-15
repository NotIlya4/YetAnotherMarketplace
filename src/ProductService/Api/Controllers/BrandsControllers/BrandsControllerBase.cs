using Api.Controllers.Attributes;
using Infrastructure.Services.BrandService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.BrandsControllers;

[Route("api/Brands")]
[ApiController]
[ProducesInternalException]
public class BrandsControllerBase : ControllerBase
{
    protected readonly IBrandService BrandService;

    public BrandsControllerBase(IBrandService brandService)
    {
        BrandService = brandService;
    }
}