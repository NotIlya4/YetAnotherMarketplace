using Api.Controllers;
using Domain.Entities;
using Domain.Primitives;

namespace Infrastructure.Mappers.BasketEntity;

public class BasketViewMapper
{
    public Basket Map(BasketView basketView)
    {
        return new Basket(
            id: new Guid(basketView.Id),
            items: Map(basketView.Items));
    }

    public BasketItem Map(BasketItemView basketItemView)
    {
        return new BasketItem(
            id: new Guid(basketItemView.Id),
            productId: new Guid(basketItemView.ProductId),
            quantity: new Quantity(basketItemView.Quantity));
    }

    public List<BasketItem> Map(IEnumerable<BasketItemView> basketItemViews)
    {
        return basketItemViews.Select(Map).ToList();
    }

    public BasketView Map(Basket basket)
    {
        return new BasketView()
        {
            Id = basket.Id.ToString(),
            Items = basket.Items.Select(Map).ToList()
        };
    }

    public BasketItemView Map(BasketItem basketItem)
    {
        return new BasketItemView()
        {
            Id = basketItem.Id.ToString(),
            ProductId = basketItem.ProductId.ToString(),
            Quantity = basketItem.Quantity.Value
        };
    }

    public List<BasketItemView> Map(IEnumerable<BasketItem> basketItems)
    {
        return basketItems.Select(Map).ToList();
    }
}