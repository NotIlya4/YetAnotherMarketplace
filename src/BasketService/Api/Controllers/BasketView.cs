namespace Api.Controllers;

public class BasketView
{
    public required string Id { get; init; }
    public required List<BasketItemView> Items { get; init; }
}