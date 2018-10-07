using CodingExercise.PayslipEntity.Core;
using System.Collections.Generic;

namespace CodingExercise.PayslipCalculator.Interface
{
    /// <summary>
    /// Interface for payslip calculator
    /// </summary>
    public interface IPayslipCalculator
    {
        /// <summary>
        /// Given a employee list, generate payslip list
        /// </summary>
        /// <param name="employee">Employee List</param>
        /// <returns>Payslip List</returns>
        List<Payslip> GeneratePaySlip(List<Employee> employee);

        /// <summary>
        /// Given annual salary, calculate gross income
        /// </summary>
        /// <param name="annualSalary">Annual Salary</param>
        /// <returns>Gross Income</returns>
        int CalculateGrossIncome(decimal annualSalary);

        /// <summary>
        /// Given annual salary, calculate income tax
        /// </summary>
        /// <param name="annualSalary">Annual Salary</param>
        /// <returns>Income Tax</returns>
        int CalculateIncomeTax(decimal annualSalary);

        /// <summary>
        /// Given gross income and income tax, calculate net income
        /// </summary>
        /// <param name="annualSalary">Annual Salary</param>
        /// <param name="incomeTax">Income Tax</param>
        /// <returns>Net Income</returns>
        int CalculateNetIncome(decimal grossIncome, decimal incomeTax);

        /// <summary>
        /// Given gross income and super rate, calculate superannration
        /// </summary>
        /// <param name="grossIncome">Gross Income</param>
        /// <param name="superRate">Super Rate</param>
        /// <returns>Super</returns>
        int CalculateSuper(decimal grossIncome, decimal superRate);
    }
}
