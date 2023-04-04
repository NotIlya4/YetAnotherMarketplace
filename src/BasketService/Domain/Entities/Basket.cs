namespace Domain.Entities;

public record Basket : IEntityComparable<Basket>
{
    public Guid Id { get; private set; }
    public List<BasketItem> Items { get; private set; }

    public Basket(Guid id, List<BasketItem> items)
    {
        Id = id;
        Items = items;
    }
    
    public bool EqualId(Basket? entity)
    {
        if (entity is null)
        {
            return false;
        }

        return Id.Equals(entity.Id);
    }
}