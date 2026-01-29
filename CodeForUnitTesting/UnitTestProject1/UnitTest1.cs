using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CalculatorService;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Calculator calObj = null;

        public UnitTest1()
        {
            calObj = new Calculator();
        }

        [TestMethod]
        public void TestMethod1()
        {
            int numTest1 = 100;
            int numtest2 = 200;

            int actual = 0;
            int expected = 300;
            actual = calObj.AddMe(numTest1, numtest2);
            Assert.AreEqual(expected, actual);
        }

       
    }
}
