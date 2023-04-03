using Domain.Primitives;

namespace Domain.Entities;

public class BasketItem
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Quantity Quantity { get; set; }

    public BasketItem(Guid id, Guid productId, Quantity quantity)
    {
        Id = id;
        ProductId = productId;
        Quantity = quantity;
    }
}