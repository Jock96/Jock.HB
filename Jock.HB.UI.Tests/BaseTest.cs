using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jock.HB.UI.Tests
{
    [TestClass]
    public class BaseTest
    {
        [TestMethod]
        public void BaseSumTest()
        {
            var firstNumbet = 1;
            var secondNumber = 2;

            var actualResult = firstNumbet + secondNumber;
            var expectedResult = 3;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
