using System;
using System.Collections.Generic;

namespace Cerberus.Sample
{
    internal class Program
    {
        private static void Main()
        {
            TestArgument(new object());
            TestArgument(null);
            TestCondition(1);
            TestCondition(2);
            TestCollection(new List<int> { 1, 2, 3 });
            TestCollection(new List<int>());
        }

        private static void TestCondition(int evenValue)
        {
            try
            {
                Guard.That.Argument.MeetCondition(() => evenValue % 2 == 0);
                Console.WriteLine("Argument {0} meet condition.", evenValue);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Ups argument {0} not meet condition, exception caught: {1}", evenValue, ex.Message);
            }
        }

        private static void TestCollection(IEnumerable<int> list)
        {
            try
            {
                Guard.That.Collection.IsNotNullOrEmpty(() => list);
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

            Console.WriteLine("We need that the obj value is not null.");
        }
    }
}