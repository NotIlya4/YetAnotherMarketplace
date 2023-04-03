using Domain.Entities;
using Infrastructure.Mappers.BasketEntity;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/baskets")]
public class BasketsController : ControllerBase
{
    public IBasketRepository BasketRepository { get; }
    public BasketViewMapper Mapper { get; }

    public BasketsController(IBasketRepository basketRepository, BasketViewMapper mapper)
    {
        BasketRepository = basketRepository;
        Mapper = mapper;
    }

    [HttpGet]
    [Route("id/{id}")]
    public async Task<ActionResult<BasketView>> GetBasket(string id)
    {
        Basket basket = await BasketRepository.GetBasket(new Guid(id));

        return Ok(basket);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> InsertBasket(BasketView basketView)
    {
        await BasketRepository.Insert(Mapper.Map(basketView));

        return NoContent();
    }

    [HttpDelete]
    [Route("id/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteBasket(string id)
    {
        await BasketRepository.Delete(new Guid(id));

        return NoContent();
    }
}