using Api.Swagger.EnricherSystem.CreateOwnEnrichers;
using Infrastructure.Repositories.Exceptions;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Api.Swagger.Enrichers.EntityNotFoundExceptionView;

public class EntityNotFoundDetailAttribute : BaseAttribute, ISchemaEnricher
{
    public required string EntityName { get; set; }
    public required string RepositoryName { get; set; }
    
    public void Enrich(OpenApiSchema schema)
    {
        schema.Example = new OpenApiString(new EntityNotFoundException(EntityName).Message);
    }
}