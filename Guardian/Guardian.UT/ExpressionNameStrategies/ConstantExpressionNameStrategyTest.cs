using System;
using System.Linq.Expressions;
using Guardian.ExpressionNameStrategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Guardian.UT.ExpressionNameStrategies
{
    [TestClass]
    public class ConstantExpressionNameStrategyTest
    {
        private ConstantExpressionNameStrategy _strategy;

        [TestInitialize]
        public void Setup()
        {
            _strategy = new ConstantExpressionNameStrategy();
        }

        [TestMethod]
        public void ShouldHandleConstantExpression()
        {
            Expression<Func<object>> expression = () => null;

            var actual = _strategy.CanHandle(expression.Body);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void ShouldReturnNullWhenGetNotSupportedExpressionType()
        {
            object argument = null;
            Expression<Func<object>> expression = () => argument;

            var name = _strategy.GetName(expression);

            Assert.IsNull(name);
        }
    }
}