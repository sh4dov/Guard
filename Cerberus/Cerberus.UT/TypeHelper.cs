using System;
using System.Reflection;

namespace Cerberus.UT
{
    internal static class TypeHelper
    {
        public static ConstructorInfo GetDefaultConstructor<T>(BindingFlags bindingFlags)
        {
            Type type = typeof(T);

            return type.GetConstructor(bindingFlags | BindingFlags.Instance, null, new Type[0], null);
        }
    }
}