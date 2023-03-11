using Domain.Exceptions;

namespace Infrastructure.Repositories.Exceptions;

public class EntityNotFoundException : NotFoundException
{
    public Type Entity { get; }
    public Type Repository { get; }

    public EntityNotFoundException(Type entity, Type repository) : base($"There is no specified {entity.Name} in {repository.Name}")
    {
        Entity = entity;
        Repository = repository;
    }
}