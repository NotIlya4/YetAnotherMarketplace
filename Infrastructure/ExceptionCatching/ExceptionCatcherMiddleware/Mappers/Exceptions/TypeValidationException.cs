namespace Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.Exceptions;

internal class TypeValidationException : Exception
{
    public TypeValidationException(Type typeThatFailedValidation, string msg) : base($"Type validation failed in {typeThatFailedValidation.FullName} due to: {msg}")
    {
        
    }
}