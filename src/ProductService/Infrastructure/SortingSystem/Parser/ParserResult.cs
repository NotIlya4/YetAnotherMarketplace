using Infrastructure.PropertySystem;
using Infrastructure.SortingSystem.Core;

namespace Infrastructure.SortingSystem.Parser;

public struct ParserResult<TEntity>
{
    public Property<TEntity> Property { get; }
    public SortingSide SortingSide { get; }

    public ParserResult(Property<TEntity> property, SortingSide sortingSide)
    {
        Property = property;
        SortingSide = sortingSide;
    }
}