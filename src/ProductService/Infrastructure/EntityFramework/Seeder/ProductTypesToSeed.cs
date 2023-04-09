using Infrastructure.EntityFramework.Models;

namespace Infrastructure.EntityFramework.Seeder;

public class ProductTypesToSeed
{
    public ProductTypeData Pants { get; }
    public ProductTypeData Shoes { get; }
    public ProductTypeData TShirt { get; }
    public ProductTypeData Watches { get; }
    public List<ProductTypeData> ProductTypeDatas { get; }

    public ProductTypesToSeed()
    {
        Pants = MakeProductType("9483fe08-61f5-43e5-97e0-2e438a7ef007", "Pants");
        Shoes = MakeProductType("dd44985f-3d5c-4059-952c-4fe84a73dbf1", "Shoes");
        TShirt = MakeProductType("8f428602-fe56-490d-a553-665c1bec8464", "T-Shirt");
        Watches = MakeProductType("dcf374e1-7e5e-482a-8819-64bb43d12bd5", "Watches");
        ProductTypeDatas = new List<ProductTypeData>() { Pants, Shoes, TShirt, Watches };
    }

    private ProductTypeData MakeProductType(string id, string name)
    {
        return new ProductTypeData() { Id = id, Name = name };
    }
}