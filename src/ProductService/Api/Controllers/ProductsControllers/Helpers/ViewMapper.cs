using Api.Controllers.ProductsControllers.Views;
using Domain.Entities;
using Domain.Primitives;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.ProductService;

namespace Api.Controllers.ProductsControllers.Helpers;

public class ViewMapper
{
    public Product MapProduct(ProductView productData)
    {
        return new Product(
            id: productData.Id,
            name: new Name(productData.Name),
            description: new Description(productData.Description),
            price: new Price(productData.Price),
            pictureUrl: productData.PictureUrl,
            productType: new Name(productData.ProductType),
            brand: new Name(productData.Brand));
    }

    public List<Product> MapProduct(IEnumerable<ProductView> productViews)
    {
        return productViews.Select(MapProduct).ToList();
    }

    public ProductView MapProduct(Product product)
    {
        return new ProductView()
        {
            Id = product.Id,
            Name = product.Name.Value,
            Description = product.Description.Value,
            Price = product.Price.Value,
            PictureUrl = product.PictureUrl,
            ProductType = product.ProductType.Value,
            Brand = product.Brand.Value
        };
    }
    
    public List<ProductView> MapProduct(IEnumerable<Product> products)
    {
        return products.Select(MapProduct).ToList();
    }

    public CreateProductCommand MapCreateProductCommand(CreateProductCommandView view)
    {
        return new CreateProductCommand()
        {
            Name = new Name(view.Name),
            Description = new Description(view.Description),
            Price = new Price(view.Price),
            PictureUrl = view.PictureUrl,
            ProductType = new Name(view.ProductType),
            Brand = new Name(view.Brand)
        };
    }

    public ProductStrictFilter MapProductStrictFilter(ProductStrictFilterView view)
    {
        return new ProductStrictFilter(
            productPropertyName: view.PropertyName,
            expectedValue: view.Value);
    }
}