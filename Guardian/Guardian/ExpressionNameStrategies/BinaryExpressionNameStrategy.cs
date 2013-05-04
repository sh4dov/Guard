using System.Linq.Expressions;

namespace Guardian.ExpressionNameStrategies
{
    internal sealed class BinaryExpressionNameStrategy : ExpressionNameStrategyBase<BinaryExpression>
    {
        protected override string GetName(BinaryExpression expression)
        {
            return expression.ToString();
        }
    }
}