using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Guardian.UT
{
    [TestClass]
    public class GuardTypeTest
    {
        [TestMethod]
        public void GuardTypeDoesNotHavePublicConstructor()
        {
            var defaultConstructor = TypeHelper.GetDefaultConstructor<GuardType>(BindingFlags.Public);

            Assert.IsNull(defaultConstructor);
        }
    }
}