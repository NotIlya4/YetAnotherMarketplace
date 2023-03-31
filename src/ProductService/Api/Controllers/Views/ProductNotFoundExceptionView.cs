using Api.Swagger.Enrichers.EntityNotFoundExceptionView;
using Domain.Entities;
using Infrastructure.Repositories.ProductRepository;

namespace Api.Controllers.Views;

public class ProductNotFoundExceptionView
{
    [EntityNotFoundTitle]
    public required string Title { get; set; }
    [EntityNotFoundDetail(EntityName = nameof(Product),RepositoryName = nameof(ProductsRepository))]
    public required string Detail { get; set; }
}