using System;
using System.Linq.Expressions;
using Guardian.ExpressionNameStrategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Guardian.UT.ExpressionNameStrategies
{
    [TestClass]
    public class MemberExpressionNameStrategyTest
    {
        private MemberExpressionNameStrategy _strategy;

        [TestInitialize]
        public void Setup()
        {
            _strategy = new MemberExpressionNameStrategy();
        }

        [TestMethod]
        public void ShouldHandleMemberExpression()
        {
            object argument = null;
            Expression<Func<object>> expression = () => argument;

            var actual = _strategy.CanHandle(expression.Body);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void ShouldReturnNullWhenGetNotSupportedExpressionType()
        {
            Expression<Func<object>> expression = () => null;

            var name = _strategy.GetName(expression);

            Assert.IsNull(name);
        }
    }
}