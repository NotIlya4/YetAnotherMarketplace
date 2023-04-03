using System.Text.Json;
using Domain.Entities;

namespace Infrastructure.Repositories;

public class BasketSerializer
{
    public string Serialize(Basket basket)
    {
        return JsonSerializer.Serialize(basket);
    }

    public Basket Deserialize(string basket)
    {
        return JsonSerializer.Deserialize<Basket>(basket) ?? throw new BasketSerializerException("Failed to deserialize basket");
    }
}