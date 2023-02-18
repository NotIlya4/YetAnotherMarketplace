using Infrastructure.ProductService;
using Infrastructure.ProductService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<List<GetProductDto>> GetProducts()
    {
        return await _productService.GetProducts();
    }

    [HttpGet]
    [Route("id/{id}")]
    public async Task<GetProductDto> GetProductById(string id)
    {
        return await _productService.GetProductById(id);
    }

    [HttpGet]
    [Route("name/{name}")]
    public async Task<GetProductDto> GetProductByName(string name)
    {
        return await _productService.GetProductByName(name);
    }

    [HttpPost]
    public async Task CreateProduct(CreateProductDto createProductDto)
    {
        await _productService.CreateNewProduct(createProductDto);
    }
}