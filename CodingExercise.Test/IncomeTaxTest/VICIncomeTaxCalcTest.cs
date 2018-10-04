using System;
using CodingExercise.IncomeTaxCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingExercise.IncomeTaxCalculator.Factory;
using CodingExercise.IncomeTaxCalculator.Interface;
using CodingExercise.Utilities;

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
        [DataRow(1100.49, 1100)]
        [DataRow(2555.51, 2556)]
        [DataRow(12580.25, 12580)]
        public void Non_Integer_Number_Should_RoundedUp_Or_RoundedDown(double number, int expectedResult)
        {
            // Act
            var actualResult = NumberUtils.Round(number);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [DataRow(18200, 0)]
        [DataRow(18201, 0)]
        [DataRow(37000, 3572)]
        [DataRow(37001, 3572)]
        [DataRow(87000, 19822)]
        [DataRow(87001, 19822)]
        [DataRow(180000, 54232)]
        [DataRow(180001, 54232)]
        [DataRow(60050, 11063)]
        [DataRow(120000, 32032)]
        public void Given_AnnualSalary_Return_Annually_IncomeTax(int annualSalary, int expectedResult)
        {
            // Act
            var actualResult = _vicTaxCalc.CalculateIncomeTax(annualSalary);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [DataRow(18200, 0)]
        [DataRow(18201, 0)]
        [DataRow(37000, 298)]
        [DataRow(37001, 298)]
        [DataRow(87000, 1652)]
        [DataRow(87001, 1652)]
        [DataRow(180000, 4519)]
        [DataRow(180001, 4519)]
        [DataRow(60050, 922)]
        [DataRow(120000, 2669)]
        public void Given_AnnualSalary_Return_Monthly_IncomeTax(int annualSalary, int expectedResult)
        {
            // Act
            var actualResult = _vicTaxCalc.CalculateIncomeTax(annualSalary).ToMonthly();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Given_A_Validate_IncomeTaxCalculatorType_Should_Create_Correct_TypeOfInstance()
        {
            // Arrange
            var incomeTaxType = IncomeTaxFactory.GetIncomeTaxType("VICIncomeTaxCalculator");

            // Assert
            Assert.IsInstanceOfType(incomeTaxType, typeof(ITaxIncomeCalculator));
        }

        [TestMethod]
        public void Given_An_Invalidate_IncomeTaxCalculatorType_Should_Throw_Exception()
        {
            try
            {
                // Arrange
                var incomeTaxType = IncomeTaxFactory.GetIncomeTaxType("NSWIncomeTaxCalculator");
            }
            catch (Exception e)
            {
                // Assert
                Assert.AreEqual("Cannot find validated income tax calculation type.", e.Message);
            }           
        }
    }
}
