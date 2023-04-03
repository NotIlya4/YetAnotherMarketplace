using Domain.Entities;

namespace Infrastructure.Repositories;

public interface IBasketRepository
{
    Task<Basket> GetBasket(Guid id);
    Task Insert(Basket basket);
    Task Delete(Guid id);
}