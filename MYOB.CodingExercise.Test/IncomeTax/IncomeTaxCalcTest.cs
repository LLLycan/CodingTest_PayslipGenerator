using CodingExercise.IncomeTaxCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingExercise.Test.IncomeTaxTest
{
    /// <summary>
    /// Test area based on calculation related to income tax
    /// </summary>
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
            var actualResult = _taxCalc.Round((decimal)number);
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
        public void Given_An_AnnualSalary_Return_Monthly_IncomeTax(int annualSalary, int expectedResult)
        {
            // Arrange 
            var taxBracket = _taxCalc.GetTaxBracket(annualSalary);
            // Act
            var actualResult = _taxCalc.Round(_taxCalc.CalculateIncomeTax(annualSalary, taxBracket) / 12);
            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [DataRow(18200, 0)]
        [DataRow(18201, 0)]
        [DataRow(37000, 0)]
        [DataRow(37001, 3572)]
        [DataRow(87000, 3572)]
        [DataRow(87001, 19822)]
        [DataRow(180000, 19822)]
        [DataRow(180001, 54232)]
        public void Given_An_AnnualSalary_Return_Correct_TaxBracketSurplus(int annualSalary, int expectedResult)
        {
            // Arrange
            var taxBracket = _taxCalc.GetTaxBracket(annualSalary);
            // Act 
            var actualResult = (int)taxBracket.TaxSurplus;
            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
