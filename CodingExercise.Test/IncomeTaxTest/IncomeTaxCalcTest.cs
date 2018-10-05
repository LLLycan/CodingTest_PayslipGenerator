using System;
using CodingExercise.IncomeTaxCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingExercise.IncomeTaxCalculator.Factory;
using CodingExercise.IncomeTaxCalculator.Interface;
using CodingExercise.Utilities;

namespace CodingExercise.Test.IncomeTaxTest
{
    [TestClass]
    public class IncomeTaxCalcTest
    {
        TaxIncomeCalculator _taxCalc;

        [TestInitialize]
        public void Initialize()
        {
            _taxCalc = new TaxIncomeCalculator();
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
            // Arrange 
            var taxBracket = _taxCalc.GetTaxBracket(annualSalary);

            // Act
            var actualResult = _taxCalc.CalculateIncomeTax(annualSalary, taxBracket);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        //[TestMethod]
        //public void Given_A_Validate_IncomeTaxCalculatorType_Should_Create_Correct_TypeOfInstance()
        //{
        //    // Arrange
        //    var incomeTaxType = IncomeTaxFactory.GetIncomeTaxType("VICIncomeTaxCalculator");

        //    // Assert
        //    Assert.IsInstanceOfType(incomeTaxType, typeof(ITaxIncomeCalculator));
        //}

        //[TestMethod]
        //public void Given_An_Invalidate_IncomeTaxCalculatorType_Should_Throw_Exception()
        //{
        //    try
        //    {
        //        // Arrange
        //        var incomeTaxType = IncomeTaxFactory.GetIncomeTaxType("NSWIncomeTaxCalculator");
        //    }
        //    catch (Exception e)
        //    {
        //        // Assert
        //        Assert.AreEqual("Cannot find validated income tax calculation type.", e.Message);
        //    }           
        //}
    }
}
