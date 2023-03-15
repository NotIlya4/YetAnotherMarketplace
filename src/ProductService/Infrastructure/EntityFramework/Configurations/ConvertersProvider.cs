using Domain.Entities;
using Domain.Primitives;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.EntityFramework.Configurations;

public static class ConvertersProvider
{
    public static ValueConverter<Guid, string> GetGuidConverter()
    {
        return new ValueConverter<Guid, string>(
            guid => guid.ToString(),
            str => Guid.Parse(str));
    }

    public static ValueConverter<Name, string> GetNameConverter()
    {
        return new ValueConverter<Name, string>(
            hs => hs.ToString(),
            str => new Name(str));
    }
    
    public static ValueConverter<Description, string> GetDescriptionConverter()
    {
        return new ValueConverter<Description, string>(
            hs => hs.ToString(),
            str => new Description(str));
    }

    public static ValueConverter<Uri, string> GetUriConverter()
    {
        return new ValueConverter<Uri, string>(
            uri => uri.ToString(),
            str => new Uri(str));
    }

    public static ValueConverter<Price, decimal> GetPriceConverter()
    {
        return new ValueConverter<Price, decimal>(
            price => price.Value,
            dec => new Price(dec));
    }
}