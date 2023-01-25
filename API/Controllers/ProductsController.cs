using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specifications;

namespace API.Controllers;

[ApiController]
[Route("api/Products")]
public class ProductsController : ControllerBase
{
    private readonly IGenericRepository<Product> _productsRepo;
    private readonly IGenericRepository<ProductBrand> _productBrandRepo;
    private readonly IGenericRepository<ProductType> _productTypeRepo;

    public ProductsController(
            IGenericRepository<Product> productsRepo,
            IGenericRepository<ProductBrand> productBrandRepo,
            IGenericRepository<ProductType> productTypeRepo
        )
    {
        _productsRepo = productsRepo;
        _productBrandRepo = productBrandRepo;
        _productTypeRepo = productTypeRepo;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
    {
        return Ok(await _productsRepo.ListAsync(new ProductsWithTypesAndBrandsSpecification()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id) 
    {
        var spec = new ProductsWithTypesAndBrandsSpecification(id);

        Product? prod = await _productsRepo.GetEntityWithSpec(spec);

        if (prod is null) {
            return NotFound();
        }

        return Ok(prod);
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
    {
        return Ok(await _productBrandRepo.GetAllAsync());
    }

    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetTypes()
    {
        return Ok(await _productTypeRepo.GetAllAsync());
    }
}