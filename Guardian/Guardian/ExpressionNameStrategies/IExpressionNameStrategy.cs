using System.Linq.Expressions;

namespace Guardian.ExpressionNameStrategies
{
    internal interface IExpressionNameStrategy
    {
        bool CanHandle(Expression expression);

        string GetName(Expression expression);
    }
}