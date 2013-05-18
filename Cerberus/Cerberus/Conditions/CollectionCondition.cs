using System;
using System.Collections;
using System.Linq.Expressions;
using Cerberus.Properties;
using ObjectSupporter;

namespace Cerberus.Conditions
{
    public sealed class CollectionCondition
    {
        private readonly ArgumentCondition _argumentCondition;

        internal CollectionCondition(ArgumentCondition argumentCondition)
        {
            _argumentCondition = argumentCondition;
        }

        public void IsNotNullOrEmpty(Expression<Func<IList>> expression)
        {
            _argumentCondition.IsNotNull(expression);

            var argumentName = ObjectSupport.GetName(expression);

            var func = expression.Compile();
            var result = func();

            if (result.Count == 0)
            {
                throw new ArgumentException(Resources.CollectionCannotBeEmpty, argumentName);
            }
        }
    }
}