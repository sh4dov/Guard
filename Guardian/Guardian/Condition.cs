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
                throw new ArgumentNullException(argumentName, Resource.ArgumentCannotBeNull);
            }
        }

        public void MeetCondition(Expression<Func<bool>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(Resource.ArgumentCannotBeNull, GetName(() => expression));
            }

            var expressionName = GetName(expression);
            string argumentName = GetLeftParameterName(expression.Body as BinaryExpression);

            var func = expression.Compile();
            var result = func();

            if (!result)
            {
                throw new ArgumentException(string.Format(Resource.ArgumentDoesNotMeetCondition, expressionName), argumentName);
            }
        }

        internal string GetName<T>(Expression<Func<T>> expression)
        {
            return GetName(expression.Body);
        }

        private string GetLeftParameterName(BinaryExpression expression)
        {
            if (expression == null)
            {
                return null;
            }

            return GetName(expression.Left);
        }

        private string GetName(Expression expression)
        {
            if (_expressionNameStrategy.CanHandle(expression))
            {
                return _expressionNameStrategy.GetName(expression);
            }

            throw new InvalidOperationException(Resource.InvalidParameterType);
        }
    }
}