using System.Linq.Expressions;

namespace Guardian.ExpressionNameStrategies
{
    internal sealed class MemberExpressionNameStrategy : ExpressionNameStrategyBase<MemberExpression>
    {
        protected override string GetName(MemberExpression expression)
        {
            return expression.Member.Name;
        }
    }
}