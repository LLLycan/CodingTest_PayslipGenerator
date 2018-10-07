using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingExercise.PayslipCalculator;
using CodingExercise.PayslipCalculator.Interface;
using CodingExercise.PayslipCalculator.Factory;
using CodingExercise.PayslipEntity.Core;
using System.Collections.Generic;

namespace CodingExercise.Test.PayslipTest
{
    /// <summary>
    /// Test area based on calculation of payslip and payslip result handler
    /// </summary>
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
        public void Given_A_PayslipCalculatorType_Should_Create_Correct_Instance()
        {
            // Arrange
            var payslipType = PayslipFactory.GetPayslipType("MonthlyPayslipCalculator");
            // Assert
            Assert.IsInstanceOfType(payslipType, typeof(IPayslipCalculator));
        }

        [TestMethod]
        public void Given_An_Invalid_PayslipCalculatorType_Should_Throw_Exception()
        {
            try
            {
                // Arrange
                var incomeTaxType = PayslipFactory.GetPayslipType("WeeklyPayslipCalculator");
            }
            catch (Exception e)
            {
                // Assert
                Assert.AreEqual("Cannot find correct payslip calculation type.", e.Message);
            }
        }

        [TestMethod]
        [DataRow(60050, 5004)]
        [DataRow(77000, 6417)]
        public void Given_An_Annualsalary_Return_Monthly_GrossIncome(double annualSalary, int expectedResult)
        {
            // Act
            var actualResult = _monthlyPayslipCalc.CalculateGrossIncome((decimal)annualSalary);        
            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [DataRow(60050, 922)]
        [DataRow(120000, 2669)]
        public void Given_Annualsalary_And_IncomeTaxCalculatorType_Return_Monthly_IncomeTax(double annualSalary, int expectedResult)
        {
            // Act
            var actualResult = _monthlyPayslipCalc.CalculateIncomeTax((decimal)annualSalary);
            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [DataRow(5004, 922, 4082)]
        [DataRow(10000, 2669, 7331)]
        public void Given_GrossIncome_And_IncomeTax_Return_NetIncome(double grossIncome, double incomeTax, int expectedResult)
        {
            // Act
            var actualResult = _monthlyPayslipCalc.CalculateNetIncome((decimal)grossIncome, (decimal)incomeTax);
            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [DataRow(5004, 9, 450)]
        [DataRow(10000, 10, 1000)]
        [DataRow(7230, 9, 651)]
        public void Given_GrossIncome_And_SuperRate_Return_Super(double grossIncome, double superRate, int expectedResult)
        {
            // Arrange
            var actualResult = _monthlyPayslipCalc.CalculateSuper((decimal)grossIncome, (decimal)superRate);
            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Given_An_EmployeesList_Return_PayslipList()
        {
            // Arrange
            var employees = new List<Employee>()
            {
                new Employee {
                    FirstName = "David",
                    LastName = "Rudd",
                    AnnualSalary = 60050,
                    SuperRate = 9,
                    PayPeriod = "01 March-31 March"
                }
            };
            // Expected
            var payslips = new List<Payslip>
            {
                new Payslip{
                    Name = "David Rudd",
                    PayPeriod = "01 March-31 March",
                    GrossIncome = 5004,
                    IncomeTax = 922,
                    NetIncome = 4082,
                    Super = 450
                }
            };
            // Act
            var actualResult = _monthlyPayslipCalc.GeneratePaySlip(employees);
            // Assert
            Assert.AreEqual(payslips[0].Name, actualResult[0].Name);
            Assert.AreEqual(payslips[0].PayPeriod, actualResult[0].PayPeriod);
            Assert.AreEqual(payslips[0].GrossIncome, actualResult[0].GrossIncome);
            Assert.AreEqual(payslips[0].IncomeTax, actualResult[0].IncomeTax);
            Assert.AreEqual(payslips[0].NetIncome, actualResult[0].NetIncome);
            Assert.AreEqual(payslips[0].Super, actualResult[0].Super);
        }
    }
}
