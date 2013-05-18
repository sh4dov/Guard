using System;
using System.Collections;
using System.Collections.Generic;

namespace Cerberus.Sample
{
    internal class Program
    {
        private static void Main()
        {
            TestArgument(new object());
            TestArgument(null);
            TestCollection(new List<int> { 1, 2, 3 });
            TestCollection(new List<int>());
        }

        private static void TestCollection(IList list)
        {
            try
            {
                Guard.CollectionIsNotNullOrEmpty(() => list);
                Console.WriteLine("Collection was not empty.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Ups collection should not be empty, exception caught: {0}", ex.Message);
            }
        }

        private static void TestArgument(object obj)
        {
            try
            {
                SampleMethod(obj);
                Console.WriteLine("This argument was OK.");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Ups argument should not be null, exception caught: {0}", ex.Message);
            }
        }

        private static void SampleMethod(object obj)
        {
            Guard.That.Argument.IsNotNull(() => obj);

            Console.WriteLine("We need that obj is not a null.");
        }
    }
}