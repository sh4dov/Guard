using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cerberus.UT
{
    [TestClass]
    public class GuardTest
    {
        [TestMethod]
        public void ThatPropertyIsNotNull()
        {
            Assert.IsNotNull(Guard.That);
        }

        [TestMethod]
        public void ArgumentPropertyIsNotNull()
        {
            Assert.IsNotNull(Guard.That.Argument);
        }

        [TestMethod]
        public void IsNotNullDoesNotThrowExceptionIfArgumentIsNotNull()
        {
            object argument = new object();
            Guard.That.Argument.IsNotNull(() => argument);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsNotNullThrowExceptionIfArgumentIsNull()
        {
            object argument = null;
            Guard.That.Argument.IsNotNull(() => argument);
        }

        [TestMethod]
        public void ThatPropertyAlwaysReturnTheSameInstance()
        {
            var instance1 = Guard.That;
            var instance2 = Guard.That;

            Assert.IsTrue(ReferenceEquals(instance1, instance2));
        }

        [TestMethod]
        public void ArgumentPropertyAlwaysReturnTheSameInstance()
        {
            var instance1 = Guard.That.Argument;
            var instance2 = Guard.That.Argument;

            Assert.IsTrue(ReferenceEquals(instance1, instance2));
        }

        [TestMethod]
        public void CollectionPropertyAlwaysReturnTheSameInstance()
        {
            var instance1 = Guard.That.Collection;
            var instance2 = Guard.That.Collection;

            Assert.IsTrue(ReferenceEquals(instance1, instance2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentIsNotNullShouldThrowExceptionWhenArgumentIsNull()
        {
            object argument = null;

            Guard.ArgumentIsNotNull(() => argument);
        }

        [TestMethod]
        public void ArgumentIsNotNullShouldNotThrowExceptionWhenArgumentIsNotNull()
        {
            object argument = new object();

            Guard.ArgumentIsNotNull(() => argument);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ArgumentMeetConditionShouldThrowExceptionWhenConditionIsNotMeet()
        {
            int i1 = 1;
            int i2 = 2;

            Guard.ArgumentMeetCondition(() => i1 == i2);
        }

        [TestMethod]
        public void ArgumentMeetConditionShouldNotThrowExceptionWhenConditionIsMeet()
        {
            int i1 = 1;
            int i2 = 1;

            Guard.ArgumentMeetCondition(() => i1 == i2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CollectionIsNotNullOrEmptyThrowExceptionWhenCollectionIsNull()
        {
            IList list = null;

            Guard.CollectionIsNotNullOrEmpty(() => list);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CollectionIsNotNullOrEmptyThrowExceptionWhenCollectionIsEmpty()
        {
            var list = new List<int>();

            Guard.CollectionIsNotNullOrEmpty(() => list);
        }

        [TestMethod]
        public void CollectionIsNotNullOrEmptyShouldNotThrowExceptionWhenCollectionIsNotEmptyAndNotNull()
        {
            var list = new List<int> { 1 };

            Guard.CollectionIsNotNullOrEmpty(() => list);
        }
    }
}