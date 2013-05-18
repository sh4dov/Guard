using System;
using System.Linq.Expressions;
using Cerberus.Properties;
using ObjectSupporter;

namespace Cerberus.Conditions
{
    public sealed class ArgumentCondition
    {
        internal ArgumentCondition()
        {
        }

        public void IsNotNull(Expression<Func<object>> expression)
        {
            IsNotNull<object>(expression);
        }

        public void IsNotNull<T>(Expression<Func<T>> expression)
        {
            if (expression == null)
            {
                IsNotNull(() => expression);
            }

            var argumentName = ObjectSupport.GetName(expression);

            var func = expression.Compile();
            var result = func();

            if (result == null)
            {
                throw new ArgumentNullException(argumentName, Resources.ArgumentCannotBeNull);
            }
        }

        public void MeetCondition(Expression<Func<bool>> expression)
        {
            if (expression == null)
            {
                IsNotNull(() => expression);
            }

            var expressionName = ObjectSupport.GetName(expression);
            string argumentName = GetLeftParameterName(expression.Body as BinaryExpression);

            var func = expression.Compile();
            var result = func();

            if (!result)
            {
                throw new ArgumentException(string.Format(Resources.ArgumentDoesNotMeetCondition, expressionName), argumentName);
            }
        }

        internal string GetName<T>(Expression<Func<T>> expression)
        {
            return ObjectSupport.GetName(expression.Body);
        }

        private string GetLeftParameterName(BinaryExpression expression)
        {
            if (expression == null)
            {
                return null;
            }

            return ObjectSupport.GetName(expression.Left);
        }
    }
}