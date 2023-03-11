using System.Linq.Expressions;

namespace Infrastructure.PropertySystem;

public interface IPropertyLambdaBuilder<TClass, TReturn>
{
    public Expression<Func<TClass, TReturn>> Build(PropertyName<TClass> propertyName);
}