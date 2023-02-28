using Infrastructure.BrandService;
using Infrastructure.ExceptionCatching;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.BrandsControllers;

[Route("api/Brands")]
[ApiController]
[ProducesResponseType(typeof(BadResponseDto), StatusCodes.Status500InternalServerError)]
public class BrandsControllerBase : ControllerBase
{
    protected IBrandService BrandService { get; }

    public BrandsControllerBase(IBrandService brandService)
    {
        BrandService = brandService;
    }
}