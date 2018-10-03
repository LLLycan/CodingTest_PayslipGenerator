using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingExercise.PayslipCalculator;
using CodingExercise.PayslipCalculator.Interface;
using CodingExercise.PayslipCalculator.Factory;

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

        [TestMethod]
        public void Given_A_Validate_PayslipCalculatorType_Should_Create_Correct_TypeOfInstance()
        {
            // Arrange
            var incomeTaxType = PayslipFactory.GetIncomeTaxType("MonthlyPayslipCalculator");

            // Assert
            Assert.IsInstanceOfType(incomeTaxType, typeof(IPayslipCalculator));
        }

        [TestMethod]
        public void Given_An_Invalidate_PayslipCalculatorType_Should_Throw_Exception()
        {
            try
            {
                // Arrange
                var incomeTaxType = PayslipFactory.GetIncomeTaxType("WeeklyPayslipCalculator");
            }
            catch (Exception e)
            {
                // Assert
                Assert.AreEqual("Cannot find validated payslip calculation type.", e.Message);
            }
        }
    }
}
