using System.Linq.Expressions;

namespace Guardian.ExpressionNameStrategies
{
    internal sealed class ConstantExpressionNameStrategy : ExpressionNameStrategyBase<ConstantExpression>
    {
        protected override string GetName(ConstantExpression expression)
        {
            return expression.ToString();
        }
    }
}