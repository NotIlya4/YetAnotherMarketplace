using System.Text.Json;
using Domain.Entities;
using Newtonsoft.Json.Linq;

namespace Infrastructure.Repositories;

public class BasketSerializer
{
    public string Serialize(Basket basket)
    {
        return JObject.FromObject(basket).ToString();
    }

    public Basket Deserialize(string basket)
    {
        return JObject.Parse(basket).ToObject<Basket>();
    }
}