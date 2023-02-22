using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.Dispatchers.DispatcherDependencies;
using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.Exceptions;

namespace Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.Dispatchers.MappersReflection;

internal class ReflectionBundlesManager : IReflectionBundlesProvider
{
    private readonly Dictionary<Type, ReflectionBundle> _dictionary = new();

    public ReflectionBundlesManager(ReflectionBundle defaultReflectionBundle)
    {
        if (defaultReflectionBundle.ExceptionTypeThatMapperMaps != typeof(Exception))
        {
            throw new BadTypeException("defaultMapperType's exception must be Exception");
        }
        
        Set(defaultReflectionBundle);
    }

    public void Set(ReflectionBundle reflectionBundle)
    {
        _dictionary[reflectionBundle.ExceptionTypeThatMapperMaps] = reflectionBundle;
    }

    public ReflectionBundle? Get(Type exceptionType)
    {
        return _dictionary.GetValueOrDefault(exceptionType);
    }

    public ReflectionBundle GetDefault()
    {
        ReflectionBundle? defaultMapperType = Get(typeof(Exception));

        if (defaultMapperType is null)
        {
            throw new Exception("Mapper type with Exception didn't find");
        }

        return defaultMapperType;
    }

    public ICollection<ReflectionBundle> GetAllMapperTypes()
    {
        return _dictionary.Values;
    }

    public void CompileAllMappersMethods()
    {
        foreach (ReflectionBundle mapperType in _dictionary.Values)
        {
            CompiledMapperMethod compiledMapperMethod = mapperType.CompiledMapperMethod;
        }
    }
}