using Domain.Primitives;

namespace Domain.Entities;

public record struct BasketItem
{
    public Guid ProductId { get; private set; }
    public Quantity Quantity { get; private set; }

    public BasketItem(Guid productId, Quantity quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }
};