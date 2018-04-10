using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCalculate1()
        {
            string left = "9";
            string right = "1";
            string mathOperator = "+";
            string expected = "10";

            var calc = new Calculator.Calculator(left, right, mathOperator);

            calc.Calculate();

            var result = calc.getResult();

            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void TestCalculate2()
        {
            string left = "1";
            string right = "-7";
            string mathOperator = "+";
            string expected = "-6";

            var calc = new Calculator.Calculator(left, right, mathOperator);

            calc.Calculate();

            var result = calc.getResult();

            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void TestCalculate3()
        {
            string left = "8";
            string right = "8";
            string mathOperator = "*";
            string expected = "64";

            var calc = new Calculator.Calculator(left, right, mathOperator);

            calc.Calculate();

            var result = calc.getResult();

            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void TestCalculate4()
        {
            string left = "12";
            string right = "3";
            string mathOperator = "/";
            string expected = "4";

            var calc = new Calculator.Calculator(left, right, mathOperator);

            calc.Calculate();

            var result = calc.getResult();

            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void TestCalculate5()
        {
            string left = "";
            string right = "423";
            string mathOperator = "+";
            string expected = "Left Value must be numeric";

            var calc = new Calculator.Calculator(left, right, mathOperator);

            calc.Calculate();

            var result = calc.getResult();

            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void TestCalculate6()
        {
            string left = "foo";
            string right = "423";
            string mathOperator = "+";
            string expected = "Left Value must be numeric";

            var calc = new Calculator.Calculator(left, right, mathOperator);
            calc.Calculate();

            var result = calc.getResult();

            Assert.AreEqual(expected, result);

        }




    }
}
