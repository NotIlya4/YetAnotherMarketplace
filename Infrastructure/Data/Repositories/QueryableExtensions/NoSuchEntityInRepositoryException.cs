namespace Infrastructure.Data.Repositories.QueryableExtensions;

public class NoSuchEntityInRepositoryException : Exception
{
    public Type Entity { get; }
    public Type Repository { get; }

    public NoSuchEntityInRepositoryException(Type entity, Type repository) : base($"There is no specified {entity.Name} in {repository.Name}")
    {
        Entity = entity;
        Repository = repository;
    }
}