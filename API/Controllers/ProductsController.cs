using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers;

[ApiController]
[Route("api/Products")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repo;

    public ProductsController(IProductRepository repo)
    {
        this._repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        IEnumerable<Product> prods = await _repo.GetProductsAsync();

        return Ok(prods);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id) 
    {
        Product? prod = await _repo.GetProductByIdAsync(id);

        if (prod is null) {
            return BadRequest();
        }

        return Ok(prod);
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IEnumerable<ProductBrand>>> GetBrands()
    {
        return Ok(await _repo.GetProductBrandsAsync());
    }


}