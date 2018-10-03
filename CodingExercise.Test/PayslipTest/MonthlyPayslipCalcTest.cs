using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingExercise.PayslipCalculator;
using CodingExercise.PayslipCalculator.Interface;
using CodingExercise.PayslipCalculator.Factory;
using CodingExercise.PayslipEntity.Core;

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
        [DataRow(60050, 5004)]
        [DataRow(77000, 6417)]
        public void Given_An_Annualsalary_Return_Monthly_GrossIncome(int annualSalary, int expectedResult)
        {
            // Act
            var actualResult = _monthlyPayslipCalc.CalculateGrossIncome(annualSalary);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [DataRow(60050, "VICIncomeTaxCalculator", 922)]
        [DataRow(120000, "VICIncomeTaxCalculator", 2669)]
        public void Given_Annualsalary_And_IncomeTaxCalculatorType_Return_Monthly_IncomeTax(int annualSalary, string incomeTaxType, int expectedResult)
        {
            // Act
            var actualResult = _monthlyPayslipCalc.CalculateIncomeTax(annualSalary, incomeTaxType);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [DataRow(5004, 922, 4082)]
        [DataRow(10000, 2669, 7331)]
        public void Given_GrossIncome_And_IncomeTax_Return_NetIncome(int grossIncome, int incomeTax, int expectedResult)
        {
            // Act
            var actualResult = _monthlyPayslipCalc.CalculateNetIncome(grossIncome, incomeTax);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [DataRow(5004, 9, 450)]
        [DataRow(10000, 10, 1000)]
        [DataRow(7230, 9, 651)]
        public void Given_GrossIncome_And_SuperRate_Return_Super(int grossIncome, int superRate, int expectedResult)
        {
            // Arrange
            var actualResult = _monthlyPayslipCalc.CalculateSuper(grossIncome, superRate);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Given_A_Validate_PayslipCalculatorType_Should_Create_Correct_TypeOfInstance()
        {
            // Arrange
            var payslipType = PayslipFactory.GetPayslipType("MonthlyPayslipCalculator");

            // Assert
            Assert.IsInstanceOfType(payslipType, typeof(IPayslipCalculator));
        }

        [TestMethod]
        public void Given_An_Invalidate_PayslipCalculatorType_Should_Throw_Exception()
        {
            try
            {
                // Arrange
                var incomeTaxType = PayslipFactory.GetPayslipType("WeeklyPayslipCalculator");
            }
            catch (Exception e)
            {
                // Assert
                Assert.AreEqual("Cannot find validated payslip calculation type.", e.Message);
            }
        }

        [TestMethod]
        public void Given_An_EmployeeObj_And_IncomeTaxCalculateType_Return_PayslipObj()
        {
            // Arrange
            var employee = new Employee
            {
                FirstName = "David",
                LastName = "Rudd",
                AnnualSalary = 60050,
                SuperRate = 9,
                PayPeriod = "01 March-31 March"
            };
            var incomeTaxCalculateType = "VICIncomeTaxCalculator";

            // Expected
            var payslip = new Payslip
            {
                Name = "David Rudd",
                PayPeriod = "01 March-31 March",
                GrossIncome = 5004,
                IncomeTax = 922,
                NetIncome = 4082,
                Super = 450
            };

            // Act
            var actualResult = _monthlyPayslipCalc.GeneratePaySlip(employee,incomeTaxCalculateType);

            // Assert
            Assert.AreEqual(payslip.Name, actualResult.Name);
            Assert.AreEqual(payslip.PayPeriod, actualResult.PayPeriod);
            Assert.AreEqual(payslip.GrossIncome, actualResult.GrossIncome);
            Assert.AreEqual(payslip.IncomeTax, actualResult.IncomeTax);
            Assert.AreEqual(payslip.NetIncome, actualResult.NetIncome);
            Assert.AreEqual(payslip.Super, actualResult.Super);
        }
    }
}
