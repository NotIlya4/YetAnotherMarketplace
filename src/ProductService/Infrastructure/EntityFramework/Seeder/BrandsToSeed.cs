using Infrastructure.EntityFramework.Models;

namespace Infrastructure.EntityFramework.Seeder;

public class BrandsToSeed
{
    public BrandData Apple { get; }
    public BrandData Converse { get; }
    public BrandData Fitwear { get; }
    public BrandData Flexpants { get; }
    public BrandData Gildan { get; }
    public BrandData Hanes { get; }
    public List<BrandData> BrandDatas { get; }

    public BrandsToSeed()
    {
        Apple = MakeBrand("aa60cc27-7469-4cf4-ac87-d410fd991a1e", "Apple");
        Converse = MakeBrand("2603e472-887d-4690-abed-8e50d558f3ad", "Converse");
        Fitwear = MakeBrand("da87950b-2534-4518-b45f-9d53079dbdba", "Fitwear");
        Flexpants = MakeBrand("bd553db5-0678-4ee3-8a99-b6d5d2934e19", "Flexpants");
        Gildan = MakeBrand("3f478299-8639-4bb3-b401-d546f76a71db", "Gildan");
        Hanes = MakeBrand("c37cf461-a730-4e73-b02b-f41777ae7e26", "Hanes");
        BrandDatas = new List<BrandData>() { Apple, Converse, Fitwear, Flexpants, Gildan, Hanes };
    }

    private BrandData MakeBrand(string id, string name)
    {
        return new BrandData() { Id = id, Name = name };
    }
}