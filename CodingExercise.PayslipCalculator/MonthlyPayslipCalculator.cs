using CodingExercise.PayslipCalculator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingExercise.PayslipEntity.Core;
using CodingExercise.PayslipEntity.Extension;
using CodingExercise.IncomeTaxCalculator.Factory;

namespace CodingExercise.PayslipCalculator
{
    /// <summary>
    /// Derived payslip calculator class for monthly based
    /// </summary>
    public class MonthlyPayslipCalculator : IPayslipCalculator
    {
        public int CalculateGrossIncome(int annualSalary)
        {
            return RoundedToInt.Round(annualSalary / 12d);
        }

        public int CalculateIncomeTax(int annualSalary, string incomeTaxCalculateType)
        {
            var incomeTaxCalcType = IncomeTaxFactory.GetIncomeTaxType(incomeTaxCalculateType);

            return RoundedToInt.Round(incomeTaxCalcType.CalculateIncomeTax(annualSalary) / 12d);
        }

        public int CalculateNetIncome(int grossIncome, int incomeTax)
        {
            return grossIncome - incomeTax;
        }

        public int CalculateSuper(int grossIncome, int superRate)
        {
            return RoundedToInt.Round((double)grossIncome * superRate / 100);
        }

        public Payslip GeneratePaySlip(Employee employee, string incomeTaxCalculateType)
        {
            Payslip payslip = new Payslip();

            payslip.Name = employee.FirstName + " " + employee.LastName;

            payslip.PayPeriod = employee.PayPeriod;

            payslip.GrossIncome = CalculateGrossIncome(employee.AnnualSalary);

            payslip.IncomeTax = CalculateIncomeTax(employee.AnnualSalary, incomeTaxCalculateType);

            payslip.NetIncome = CalculateNetIncome(payslip.GrossIncome, payslip.IncomeTax);

            payslip.Super = CalculateSuper(payslip.GrossIncome, employee.SuperRate);

            return payslip;
        }
    }
}
