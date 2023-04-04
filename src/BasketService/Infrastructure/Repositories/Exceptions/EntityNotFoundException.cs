namespace Infrastructure.Repositories;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string entityName) : base($"Specified {entityName} not found")
    {
        
    }
}