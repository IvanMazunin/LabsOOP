using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab9;
namespace UnitTestProject9
{
    [TestClass]
    public class UnitTest1
    {
        public class Tests
        {
            [SetUp]
            public void Setup()
            {
            }

            [Test]
            public void TestMoneyArrayConstructorRandom()
            {
                MoneyArray banks = new MoneyArray(10, 1, 15);
                Assert.IsNotNull(banks);
            }
        }
    }
}

