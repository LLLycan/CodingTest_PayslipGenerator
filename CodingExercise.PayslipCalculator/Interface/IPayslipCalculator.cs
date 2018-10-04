using CodingExercise.PayslipEntity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercise.PayslipCalculator.Interface
{
    /// <summary>
    /// Interface for payslip calculator with future extension like monthly,weekly...
    /// </summary>
    public interface IPayslipCalculator
    {
        List<Payslip> GeneratePaySlip(List<Employee> employee, string incomeTaxCalculateType);

        int CalculateGrossIncome(int annualSalary);

        int CalculateIncomeTax(int annualSalary, string incomeTaxCalculateType);

        int CalculateNetIncome(int grossIncome, int incomeTax);

        int CalculateSuper(int grossIncome, int superRate);
    }
}
