using Domain.Entities;
using StackExchange.Redis;

namespace Infrastructure.Repositories;

public class BasketRepository : IBasketRepository
{
    public BasketSerializer BasketSerializer { get; }
    private IDatabase Db { get; }

    public BasketRepository(IConnectionMultiplexer redis, BasketSerializer basketSerializer)
    {
        BasketSerializer = basketSerializer;
        Db = redis.GetDatabase();
    }
    
    public async Task<Basket> GetBasket(Guid id)
    {
        string? data = await Db.StringGetAsync(id.ToString());

        if (data is null)
        {
            throw new EntityNotFoundException(nameof(Basket));
        }

        return BasketSerializer.Deserialize(data);
    }

    public async Task Insert(Basket basket)
    {
        bool result = await Db.StringSetAsync(
            basket.Id.ToString(), 
            BasketSerializer.Serialize(basket),
            TimeSpan.FromDays(30));

        if (!result)
        {
            throw new BasketRepositoryException("Failed to create the basket");
        }
    }

    public async Task Delete(Guid id)
    {
        bool result = await Db.KeyDeleteAsync(id.ToString());

        if (!result)
        {
            throw new BasketRepositoryException("Failed to delete the basket");
        }
    }
}