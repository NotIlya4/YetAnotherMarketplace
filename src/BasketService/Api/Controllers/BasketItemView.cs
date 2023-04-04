namespace Api.Controllers;

public class BasketItemView
{
    public required string ProductId { get; init; }
    public required int Quantity { get; init; }
}