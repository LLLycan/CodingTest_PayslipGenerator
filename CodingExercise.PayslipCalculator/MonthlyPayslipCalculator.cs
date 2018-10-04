using CodingExercise.PayslipCalculator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingExercise.PayslipEntity.Core;
using CodingExercise.IncomeTaxCalculator.Factory;
using CodingExercise.Utilities;

namespace CodingExercise.PayslipCalculator
{
    /// <summary>
    /// Derived payslip calculator class for monthly based
    /// </summary>
    public class MonthlyPayslipCalculator : IPayslipCalculator
    {
        public int CalculateGrossIncome(int annualSalary)
        {
            return NumberUtils.Round(annualSalary.ToMonthly());
        }

        public int CalculateIncomeTax(int annualSalary, string incomeTaxCalculateType)
        {
            var incomeTaxCalcType = IncomeTaxFactory.GetIncomeTaxType(incomeTaxCalculateType);

            return NumberUtils.Round(incomeTaxCalcType.CalculateIncomeTax(annualSalary).ToMonthly());
        }

        public int CalculateNetIncome(int grossIncome, int incomeTax)
        {
            return grossIncome - incomeTax;
        }

        public int CalculateSuper(int grossIncome, int superRate)
        {
            return NumberUtils.Round((double)grossIncome * superRate / 100);
        }

        public List<Payslip> GeneratePaySlip(List<Employee> employees, string incomeTaxCalculateType)
        {
            var payslips = new List<Payslip>();

            foreach (var employee in employees)
            {
                var _fullName = employee.FirstName + " " + employee.LastName;
                var _grossIncome = CalculateGrossIncome(employee.AnnualSalary);
                var _incomeTax = CalculateIncomeTax(employee.AnnualSalary, incomeTaxCalculateType);
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
    }
}
