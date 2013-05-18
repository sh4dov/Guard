using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Cerberus.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cerberus.UT.Conditions
{
    [TestClass]
    public class CollectionConditionTest
    {
        private CollectionCondition _condition;

        [TestInitialize]
        public void Setup()
        {
            _condition = new CollectionCondition(new ArgumentCondition());
        }

        [TestMethod]
        public void DoesNotHavePublicConstructor()
        {
            var defaultConstructor = TypeHelper.GetDefaultConstructor<CollectionCondition>(BindingFlags.Public);

            Assert.IsNull(defaultConstructor);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExpressionInIsNotNullOrEmptyShouldNotBeNull()
        {
            _condition.IsNotNullOrEmpty<object>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionWhenArgumentsValueIsNull()
        {
            IEnumerable<object> argument = null;

            _condition.IsNotNullOrEmpty(() => argument);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenArgumentsValueIsEmpty()
        {
            var argument = new List<int>();

            _condition.IsNotNullOrEmpty(() => argument);
        }

        [TestMethod]
        public void DoesNotThrowExceptionWhenArgumentsValueIsNotEmpty()
        {
            var argument = new List<int> { 1 };

            _condition.IsNotNullOrEmpty(() => argument);
        }
    }
}