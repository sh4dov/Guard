using System;
using System.Linq.Expressions;
using ObjectSupporter;

namespace Cerberus
{
    public sealed class Condition
    {
        internal Condition()
        {
        }

        public void IsNotNull(Expression<Func<object>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(Resource.ArgumentCannotBeNull, ObjectSupport.GetName(() => expression));
            }

            var argumentName = ObjectSupport.GetName(expression);

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
                throw new ArgumentNullException(Resource.ArgumentCannotBeNull, ObjectSupport.GetName(() => expression));
            }

            var expressionName = ObjectSupport.GetName(expression);
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