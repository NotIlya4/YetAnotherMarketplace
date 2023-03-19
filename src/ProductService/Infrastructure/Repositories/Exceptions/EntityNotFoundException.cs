using Domain.Exceptions;

namespace Infrastructure.Repositories.Exceptions;

public class EntityNotFoundException : NotFoundException
{
    public EntityNotFoundException(string entityName) : base($"Specified {entityName} wasn't found")
    {
        
    }
}