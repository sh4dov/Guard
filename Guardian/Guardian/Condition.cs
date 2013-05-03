using System;
using System.Linq.Expressions;
using Guardian.ExpressionNameStrategies;

namespace Guardian
{
    public sealed class Condition
    {
        private readonly ExpressionNameStrategy _expressionNameStrategy = new ExpressionNameStrategy();

        internal Condition()
        {
        }

        public void IsNotNull(Expression<Func<object>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(Resource.ArgumentCannotBeNull, GetName(() => expression));
            }

            var argumentName = GetName(expression);

            var func = expression.Compile();
            var result = func();

            if (result == null)
            {
                throw new ArgumentNullException(Resource.ArgumentCannotBeNull, argumentName);
            }
        }

        internal string GetName(Expression<Func<object>> expression)
        {
            if (_expressionNameStrategy.CanHandle(expression.Body))
            {
                return _expressionNameStrategy.GetName(expression.Body);
            }

            throw new InvalidOperationException(Resource.InvalidParameterType);
        }
    }
}