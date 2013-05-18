using System;
using System.Collections;
using System.Linq.Expressions;

namespace Cerberus
{
    public static partial class Guard
    {
        public static void ArgumentIsNotNull(Expression<Func<object>> expression)
        {
            That.Argument.IsNotNull(expression);
        }

        public static void ArgumentMeetCondition(Expression<Func<bool>> expression)
        {
            That.Argument.MeetCondition(expression);
        }

        public static void CollectionIsNotNullOrEmpty(Expression<Func<IList>> expression)
        {
            That.Collection.IsNotNullOrEmpty(expression);
        }
    }
}