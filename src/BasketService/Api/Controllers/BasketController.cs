using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/basket")]
public class BasketController : ControllerBase
{
    public IBasketRepository BasketRepository { get; }

    public BasketController(IBasketRepository basketRepository)
    {
        BasketRepository = basketRepository;
    }

    [HttpGet]
    [Route("id/{id}")]
    public async Task<ActionResult<BasketView>> GetBasket(string id)
    {
        Basket basket = await BasketRepository.GetBasket(new Guid(id));

        return Ok(basket);
    }
}