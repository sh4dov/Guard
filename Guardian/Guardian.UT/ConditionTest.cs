using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Guardian.UT
{
    [TestClass]
    public class ConditionTest
    {
        private Condition _condition;

        [TestInitialize]
        public void Setup()
        {
            _condition = new Condition();
        }

        [TestMethod]
        public void ConditionDoesNotHavePublicConstructor()
        {
            var defaultConstructor = TypeHelper.GetDefaultConstructor<Condition>(BindingFlags.Public);

            Assert.IsNull(defaultConstructor);
        }

        [TestMethod]
        public void IsNotNullDoesNotThrowExceptionWhenArgumentIsNotNull()
        {
            var argument = new object();
            _condition.IsNotNull(() => argument);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExpressionInIsNotNullShouldNotBeNull()
        {
            _condition.IsNotNull(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionWhenArgumentsValueIsNull()
        {
            object argument = null;
            _condition.IsNotNull(() => argument);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionWhenArgumentIsNull()
        {
            _condition.IsNotNull(() => null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AllowMethodCondition()
        {
            _condition.IsNotNull(() => ReturnNull());
        }

        [TestMethod]
        public void ShouldExtractArgumentNameFromExpression()
        {
            var argument = new object();

            var name = _condition.GetName(() => argument);

            Assert.AreEqual("argument", name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionIfPredicateIsNotMet()
        {
            int i = 0;
            var j = 1;
            _condition.MeetCondition(() => i == j);
        }

        [TestMethod]
        public void ShouldNotThrowExceptionIfPredicateIsMet()
        {
            int i = 1;
            var j = 1;
            _condition.MeetCondition(() => i == j);
        }

        private object ReturnNull()
        {
            return null;
        }
    }
}