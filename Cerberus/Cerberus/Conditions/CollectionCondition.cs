using System;
using System.Collections.Generic;
using System.Linq;
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

        public void IsNotNullOrEmpty<T>(Expression<Func<IEnumerable<T>>> expression)
        {
            _argumentCondition.IsNotNull(expression);

            var argumentName = ObjectSupport.GetName(expression);

            var func = expression.Compile();
            var result = func();

            if (!result.Any())
            {
                throw new ArgumentException(Resources.CollectionCannotBeEmpty, argumentName);
            }
        }
    }
}