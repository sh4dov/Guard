using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Guardian.UT
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
    }
}