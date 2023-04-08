using Domain.Entities;
using Domain.Primitives;
using Infrastructure.EntityFramework.Models;

namespace Infrastructure.EntityFramework;

public class DataMapper
{
    public Product MapProduct(ProductData productData)
    {
        return new Product(
            id: new Guid(productData.Id),
            name: new Name(productData.Name),
            description: new Description(productData.Description),
            price: new Price(productData.Price),
            pictureUrl: new Uri(productData.PictureUrl),
            productType: new Name(productData.ProductType.Name),
            brand: new Name(productData.Brand.Name));
    }

    public List<Product> MapProduct(IEnumerable<ProductData> productDatas)
    {
        return productDatas.Select(MapProduct).ToList();
    }

    public ProductData MapProduct(Product product, ProductTypeData productTypeData, BrandData brandData)
    {
        return new ProductData()
        {
            Id = product.Id.ToString(),
            Name = product.Name.Value,
            Description = product.Description.Value,
            Price = product.Price.Value,
            PictureUrl = product.PictureUrl.ToString(),
            ProductType = productTypeData,
            Brand = brandData,
        };
    }

    public Name MapBrand(BrandData brandData)
    {
        return new Name(brandData.Name);
    }

    public List<Name> MapBrand(IEnumerable<BrandData> brandDatas)
    {
        return brandDatas.Select(MapBrand).ToList();
    }

    public BrandData MapBrand(Guid id, Name name)
    {
        return new BrandData()
        {
            Id = id.ToString(),
            Name = name.Value
        };
    }

    public Name MapProductType(ProductTypeData productTypeData)
    {
        return new Name(productTypeData.Name);
    }

    public List<Name> MapProductType(IEnumerable<ProductTypeData> productTypeDatas)
    {
        return productTypeDatas.Select(MapProductType).ToList();
    }

    public ProductTypeData MapProductType(Guid id, Name name)
    {
        return new ProductTypeData()
        {
            Id = id.ToString(),
            Name = name.Value
        };
    }
}