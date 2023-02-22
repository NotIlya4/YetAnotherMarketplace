namespace Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.Dispatchers.DispatcherDependencies;

internal interface IMapperInstanceProvider
{
    public object GetMapperInstanceByType(Type mapperInstanceType);
}