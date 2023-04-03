namespace Api.Controllers;

public class BasketView
{
    public required string Id { get; set; }
    public required List<BasketItemView> Items { get; set; }
}