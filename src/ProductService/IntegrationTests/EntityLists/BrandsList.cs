using Domain.Primitives;
using Infrastructure.EntityFramework.Models;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.EntityLists;

public class BrandsList
{
    public Name Apple { get; }
    public BrandData AppleData { get; }
    
    public Name McDonalds { get; }
    public BrandData McDonaldsData { get; }

    public IReadOnlyList<Name> Brands { get; }
    public IReadOnlyList<BrandData> BrandDatas { get; }
    public JArray BrandsJArray { get; }

    public BrandsList()
    {
        string appleId = "2d15e347-cf3d-4d8c-bdd7-c65f22e653f4";
        string appleName = "Apple";
        Apple = new Name(appleName);
        AppleData = new BrandData() { Id = appleId, Name = appleName };

        string mcDonaldsId = "aa7fe749-2e4b-45c4-b3f7-49c6f30d7d10";
        string mcDonaldsName = "McDonald's";
        McDonalds = new Name(mcDonaldsName);
        McDonaldsData = new BrandData() { Id = mcDonaldsId, Name = mcDonaldsName };

        Brands = new List<Name>()
        {
            Apple,
            McDonalds
        };

        BrandDatas = new List<BrandData>()
        {
            AppleData,
            McDonaldsData
        };

        BrandsJArray = new JArray()
        {
            appleName,
            mcDonaldsName
        };
    }
}