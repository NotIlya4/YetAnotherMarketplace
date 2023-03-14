using Domain.Exceptions;

namespace Infrastructure.Repositories.Exceptions;

public class EntityNotFoundException : NotFoundException
{
    public EntityNotFoundException(string entityName, string repositoryName) : base($"There is no specified {entityName} in {repositoryName}")
    {
        
    }
}