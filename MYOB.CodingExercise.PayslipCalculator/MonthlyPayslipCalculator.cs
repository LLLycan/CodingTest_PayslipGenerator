using CodingExercise.IncomeTaxCalculator;
using CodingExercise.PayslipCalculator.Interface;
using CodingExercise.PayslipEntity.Core;
using System;
using System.Collections.Generic;

namespace CodingExercise.PayslipCalculator
{
    /// <summary>
    /// Derived payslip calculator class for monthly based
    /// </summary>
    public class MonthlyPayslipCalculator : IPayslipCalculator
    {
        TaxIncomeCalculator taxCalculator = new TaxIncomeCalculator();

        /// <summary>
        /// Given annual salary, calculate monthly gross income
        /// </summary>
        /// <param name="annualSalary">Annual Salary</param>
        /// <returns>Monthly Gross Income</returns>
        public int CalculateGrossIncome(decimal annualSalary)
        {
            return Round(annualSalary / 12);
        }

        /// <summary>
        /// Given annual salary, calculate monthly income tax
        /// </summary>
        /// <param name="annualSalary">Annual Salary</param>
        /// <returns>Monthly Income Tax</returns>
        public int CalculateIncomeTax(decimal annualSalary)
        {
            var taxBracket = taxCalculator.GetTaxBracket(annualSalary);
            var incomeTax = taxCalculator.CalculateIncomeTax(annualSalary, taxBracket) / 12;
            return Round(incomeTax);
        }

        /// <summary>
        /// Given gross income and income tax, calculate monthly net income
        /// </summary>
        /// <param name="annualSalary">Annual Salary</param>
        /// <param name="incomeTax">Income Tax</param>
        /// <returns>Monthly Net Income</returns>
        public int CalculateNetIncome(decimal grossIncome, decimal incomeTax)
        {
            return Round(grossIncome - incomeTax);
        }

        /// <summary>
        /// Given gross income and super rate, calculate monthly superannration
        /// </summary>
        /// <param name="grossIncome">Gross Income</param>
        /// <param name="superRate">Super Rate</param>
        /// <returns>Monthly Super</returns>
        public int CalculateSuper(decimal grossIncome, decimal superRate)
        {
            return Round(grossIncome * superRate / 100);
        }

        /// <summary>
        /// Given a employee list, generate monthly payslip list
        /// </summary>
        /// <param name="employee">Employee List</param>
        /// <returns>Monthly Payslip List</returns>
        public List<Payslip> GeneratePaySlip(List<Employee> employees)
        {
            var payslips = new List<Payslip>();
            foreach (var employee in employees)
            {
                var _fullName = employee.FirstName + " " + employee.LastName;
                var _grossIncome = CalculateGrossIncome(employee.AnnualSalary);
                var _incomeTax = CalculateIncomeTax(employee.AnnualSalary);
                var _netIncome = CalculateNetIncome(_grossIncome, _incomeTax);
                var _super = CalculateSuper(_grossIncome, employee.SuperRate);
                payslips.Add(new Payslip {
                    Name = _fullName,
                    PayPeriod = employee.PayPeriod,
                    GrossIncome = _grossIncome,
                    IncomeTax = _incomeTax,
                    NetIncome = _netIncome,
                    Super = _super
                });
            }
            return payslips;
        }

        /// <summary>
        /// Rounded up & down for a decimal number
        /// </summary>
        /// <param name="number">number</param>
        /// <returns>int type number</returns>
        public int Round(decimal number)
        {
            return (int)Math.Round(number, MidpointRounding.AwayFromZero);
        }
    }
}
