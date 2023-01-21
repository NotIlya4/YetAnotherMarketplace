using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/Products")]
public class ProductsController : ControllerBase
{
    private readonly StoreContext _dbContext;

    public ProductsController(StoreContext _dbContext)
    {
        this._dbContext = _dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var prods = await _dbContext.Products.ToListAsync();

        return Ok(prods);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id) 
    {
        var prod = await _dbContext.Products.FindAsync(id);

        if (prod is null) {
            return BadRequest();
        }

        return Ok(prod);
    }
}