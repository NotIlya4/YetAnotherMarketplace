using Domain.Primitives;
using Infrastructure.Repositories.Primitives;
using Infrastructure.Services.ProductService.Dtos;

namespace Infrastructure.Services.ProductService;

public interface IProductService
{
    public Task<GetProductDto> GetProductById(Guid productId);
    public Task<GetProductDto> GetProductByName(NotNullString productName);
    public Task<List<GetProductDto>> GetProducts(Pagination pagination);
    public Task<GetProductDto> CreateNewProduct(CreateProductDto createProductDto);
}