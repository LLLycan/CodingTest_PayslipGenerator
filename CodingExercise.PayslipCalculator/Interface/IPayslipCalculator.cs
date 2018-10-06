using CodingExercise.PayslipEntity.Core;
using System.Collections.Generic;

namespace CodingExercise.PayslipCalculator.Interface
{
    /// <summary>
    /// Interface for payslip calculator
    /// </summary>
    public interface IPayslipCalculator
    {
        List<Payslip> GeneratePaySlip(List<Employee> employee);

        int CalculateGrossIncome(decimal annualSalary);

        int CalculateIncomeTax(decimal annualSalary);

        int CalculateNetIncome(decimal grossIncome, decimal incomeTax);

        int CalculateSuper(decimal grossIncome, decimal superRate);
    }
}
