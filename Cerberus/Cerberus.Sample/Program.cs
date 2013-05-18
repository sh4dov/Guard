using System;

namespace Cerberus.Sample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Test(new object());
            Test(null);
        }

        private static void Test(object obj)
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