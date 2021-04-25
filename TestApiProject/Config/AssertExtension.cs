using System;
using NUnit.Framework;

namespace TestApiProject.Tests.Config
{
    public class AssertExtension
    {
        public void AreEqual(Object expected, Object actual)
        {
            Console.WriteLine($"\t\t-> Expected: {expected}");
            Console.WriteLine($"\t\t-> Actual: {actual}");
            Assert.AreEqual(expected, actual);
        }
    }
}
