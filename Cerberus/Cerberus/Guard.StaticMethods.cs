using System;
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
    }
}