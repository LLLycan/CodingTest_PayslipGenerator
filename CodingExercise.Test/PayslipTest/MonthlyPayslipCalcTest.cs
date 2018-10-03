using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingExercise.PayslipCalculator;

namespace CodingExercise.Test.PayslipTest
{
    [TestClass]
    public class MonthlyPayslipCalcTest
    {
        MonthlyPayslipCalculator _monthlyPayslipCalc;

        [TestInitialize]
        public void Initialize()
        {
            _monthlyPayslipCalc = new MonthlyPayslipCalculator();
        }

        [TestMethod]
        public void Given_An_Annualsalary_Return_Monthly_GrossIncome()
        {
            // Arrange
            var annualSalary = 60500;

            // Act
            var monthlyGrossIncome = _monthlyPayslipCalc.CalculateGrossIncome(annualSalary);

            // Assert
            Assert.AreEqual(5004, monthlyGrossIncome);
        }
    }
}
