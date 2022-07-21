using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary;

namespace Tests
{
    [TestClass]
    public class CubicEquationTest
    {
        [TestMethod]
        public void TestDeltaGreaterThen0()
        {
            // Delta > 0
            var a = new CubicEquation(1, 2, 3, 4);

            Assert.AreEqual("x1=-1.6506291914393882, x2=-0.17468540428030588 + 1.5468688872313963i, x3=-0.17468540428030588 - 1.5468688872313963i", a.ToString());
        }

        [TestMethod]
        public void TestDeltaLessThen0()
        {
            // Delta < 0
            var a = new CubicEquation(2, 9, 13, 6);

            Assert.AreEqual("x1=-1, x2=-2, x3=-1.5", a.ToString());
        }

        [TestMethod]
        public void TestDeltaEqualTo0()
        {
            // Delta == 0
            var a = new CubicEquation(1, 0, 0, 0);

            Assert.AreEqual("x1=0, x2=-0, x3=-0", a.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldThrowError()
        {
            var a = new CubicEquation(0, 1, 1, 1);
        }
    }
}
