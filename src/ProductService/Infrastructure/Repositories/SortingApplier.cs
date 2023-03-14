using System.Linq.Expressions;
using Infrastructure.PropertySystem;
using Infrastructure.SortingSystem.Models;

namespace Infrastructure.Repositories;

public class SortingApplier<TEntity>
{
    private readonly IPropertyLambdaBuilder<TEntity, object> _lambdaBuilder;

    public SortingApplier(IPropertyLambdaBuilder<TEntity, object> lambdaBuilder)
    {
        _lambdaBuilder = lambdaBuilder;
    }
    
    public IQueryable<TEntity> ApplySorting(IQueryable<TEntity> query, ISortingInfoProvider<TEntity> sortingInfoProvider)
    {
        Expression<Func<TEntity, object>> primaryPropertyLambda =
            _lambdaBuilder.Build(sortingInfoProvider.PrimarySorting.PropertyName);
        
        IOrderedQueryable<TEntity> orderedQueryable = 
            ApplyOrderBy(query, primaryPropertyLambda, sortingInfoProvider.PrimarySorting.SortingSide);

        foreach (var secondarySortingInfo in sortingInfoProvider.SecondarySortings)
        {
            Expression<Func<TEntity, object>> secondaryPropertyLambda =
                _lambdaBuilder.Build(secondarySortingInfo.PropertyName);
            
            orderedQueryable = ApplyThenBy(orderedQueryable, secondaryPropertyLambda, secondarySortingInfo.SortingSide);
        }

        return orderedQueryable;
    }

    private IOrderedQueryable<TEntity> ApplyOrderBy(IQueryable<TEntity> query, 
        Expression<Func<TEntity, object>> propertyLambda, SortingSide sortingSide)
    {
        return sortingSide == SortingSide.Asc 
            ? query.OrderBy(propertyLambda) 
            : query.OrderByDescending(propertyLambda);
    }
    
    private IOrderedQueryable<TEntity> ApplyThenBy(IOrderedQueryable<TEntity> query, 
        Expression<Func<TEntity, object>> propertyLambda, SortingSide sortingSide)
    {
        return sortingSide == SortingSide.Asc 
            ? query.ThenBy(propertyLambda)
            : query.ThenByDescending(propertyLambda);
    }
}