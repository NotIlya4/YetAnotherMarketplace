using Infrastructure.ProductService.Dtos;

namespace Infrastructure.ProductService;

public interface IProductService
{
    public Task<GetProductDto> GetProductById(string id);
    public Task<GetProductDto> GetProductByName(string name);
    public Task<List<GetProductDto>> GetProducts();
    public Task<GetProductDto> CreateNewProduct(CreateProductDto createProductDto);
}