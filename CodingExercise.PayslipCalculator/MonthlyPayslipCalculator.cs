using CodingExercise.PayslipCalculator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingExercise.PayslipEntity.Core;

namespace CodingExercise.PayslipCalculator
{
    /// <summary>
    /// Derived payslip calculator class for monthly based
    /// </summary>
    public class MonthlyPayslipCalculator : IPayslipCalculator
    {
        public int CalculateGrossIncome(int annualSalary)
        {
            throw new NotImplementedException();
        }

        public int CalculateIncomeTax(int annualSalary)
        {
            throw new NotImplementedException();
        }

        public int CalculateNetIncome(int netIncome, int incomeTax)
        {
            throw new NotImplementedException();
        }

        public int CalculateSuper(int grossIncome, int superRate)
        {
            throw new NotImplementedException();
        }

        public Payslip GeneratePaySlip(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
