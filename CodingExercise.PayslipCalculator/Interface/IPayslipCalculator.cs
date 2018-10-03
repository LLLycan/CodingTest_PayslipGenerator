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
        Payslip GeneratePaySlip(Employee employee);

        int CalculateGrossIncome(int annualSalary);

        int CalculateIncomeTax(int annualSalary);

        int CalculateNetIncome(int netIncome, int incomeTax);

        int CalculateSuper(int grossIncome, int superRate);
    }
}
