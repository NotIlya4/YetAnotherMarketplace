using Api.Swagger.Enrichers.EntityNotFoundExceptionView;
using Domain.Entities;
using Infrastructure.Repositories.BrandRepository;

namespace Api.Controllers.Views;

public class BrandNotFoundExceptionView
{
    [EntityNotFoundTitle]
    public required string Title { get; set; }
    [EntityNotFoundDetail(EntityName = nameof(Brand), RepositoryName = nameof(BrandsRepository))]
    public required string Detail { get; set; }
}