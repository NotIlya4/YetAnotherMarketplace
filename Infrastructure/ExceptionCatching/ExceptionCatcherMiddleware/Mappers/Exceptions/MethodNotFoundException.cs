namespace Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.Exceptions;

internal class MethodNotFoundException : Exception
{
    public Type SourceType { get; }
    
    public MethodNotFoundException(Type sourceType) : base($"Method not found in {sourceType.FullName}")
    {
        SourceType = sourceType;
    }
}