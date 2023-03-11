using System.Linq.Expressions;

namespace Infrastructure.PropertySystem;

public class BadPropertyExpressionException : Exception
{
    public BadPropertyExpressionException(Expression badExpression) 
        : base($"{badExpression} is a bad expression, a good expression must be a property expression")
    {
        
    }
}