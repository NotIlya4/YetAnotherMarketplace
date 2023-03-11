using System.Linq.Expressions;

namespace Infrastructure.SortingSystem.Core;

public interface IPropertySortingInfoProvider<TEntity>
{
    Expression<Func<TEntity, object>> PropertyLambda { get; }
    SortingSide SortingSide { get; }
}