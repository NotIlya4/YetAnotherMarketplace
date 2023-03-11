using System.Linq.Expressions;

namespace Infrastructure.PropertySystem;

public readonly struct Property<TClass>
{
    public Expression<Func<TClass, object>> Lambda { get; }
    public PropertyName<TClass> Name { get; }

    public Property(string rawPropertyName) : this(new PropertyName<TClass>(rawPropertyName))
    {
        
    }

    public Property(PropertyName<TClass> propertyName)
    {
        Lambda = PropertyReflections.BuildPropertyLambdaFromName<TClass, object>(propertyName);
        Name = propertyName;
    }
}