namespace Domain.Entities;

public class Basket
{
    public Guid Id { get; set; }
    public List<BasketItem> Items { get; set; }

    public Basket(Guid id, List<BasketItem> items)
    {
        Items = items;
        Id = id;
    }
}