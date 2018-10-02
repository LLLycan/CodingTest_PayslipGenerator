using System;
using CodingExercise.IncomeTaxCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingExercise.Test.IncomeTaxTest
{
    [TestClass]
    public class VICIncomeTaxCalcTest
    {
        VICIncomeTaxCalculator _vicTaxCalc;

        [TestInitialize]
        public void Initialize()
        {
            _vicTaxCalc = new VICIncomeTaxCalculator();
        }

        [TestMethod]
        public void Non_Integer_Number_Should_RoundedUp_Or_RoundedDown()
        {
            // Arrange
            var firstExpected = 1100;
            var secondExpected = 2556;
            var thirdExpected = 12580;
            
            // Act
            var firstResult = _vicTaxCalc.Round(1100.49);
            var secondResult = _vicTaxCalc.Round(2555.51);
            var thirdResult = _vicTaxCalc.Round(12580.25);

            // Assert
            Assert.AreEqual(firstExpected, firstResult);
            Assert.AreEqual(secondExpected, secondResult);
            Assert.AreEqual(thirdExpected, thirdResult);
        }

        [TestMethod]
        public void Given_AnnualSalary_Return_Monthly_IncomeTax()
        {
            // Act
            var firstResult = _vicTaxCalc.CalculateIncomeTax(18200);
            var secondResult = _vicTaxCalc.CalculateIncomeTax(18201);
            var thirdResult = _vicTaxCalc.CalculateIncomeTax(37000);
            var fourthResult = _vicTaxCalc.CalculateIncomeTax(37001);
            var fivethResult = _vicTaxCalc.CalculateIncomeTax(87000);
            var sixthResult = _vicTaxCalc.CalculateIncomeTax(87001);
            var seventhResult = _vicTaxCalc.CalculateIncomeTax(180000);
            var eighthResult = _vicTaxCalc.CalculateIncomeTax(180001);
            var ninethResult = _vicTaxCalc.CalculateIncomeTax(60050);
            var tenthResult = _vicTaxCalc.CalculateIncomeTax(120000);

            // Assert
            Assert.AreEqual(firstResult, 0);
            Assert.AreEqual(secondResult, 0);
            Assert.AreEqual(thirdResult, 298);
            Assert.AreEqual(fourthResult, 298);
            Assert.AreEqual(fivethResult, 1652);
            Assert.AreEqual(sixthResult, 1652);
            Assert.AreEqual(seventhResult, 4519);
            Assert.AreEqual(eighthResult, 4519);
            Assert.AreEqual(ninethResult, 922);
            Assert.AreEqual(tenthResult, 2669);
        }
    }
}
