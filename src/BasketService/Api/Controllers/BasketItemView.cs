namespace Api.Controllers;

public class BasketItemView
{
    public required string Id { get; set; }
    public required string ProductId { get; set; }
    public required int Quantity { get; set; }
}