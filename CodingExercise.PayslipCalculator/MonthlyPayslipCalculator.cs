using CodingExercise.PayslipCalculator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingExercise.PayslipEntity.Core;
using CodingExercise.IncomeTaxCalculator.Factory;
using CodingExercise.IncomeTaxCalculator;

namespace CodingExercise.PayslipCalculator
{
    /// <summary>
    /// Derived payslip calculator class for monthly based
    /// </summary>
    public class MonthlyPayslipCalculator : IPayslipCalculator
    {
        TaxIncomeCalculator taxCalculator = new TaxIncomeCalculator();

        public int CalculateGrossIncome(decimal annualSalary)
        {
            return Round(annualSalary / 12);
        }

        public int CalculateIncomeTax(decimal annualSalary)
        {
            //var incomeTaxCalcType = IncomeTaxFactory.GetIncomeTaxType(incomeTaxCalculateType);

            var taxBracket = taxCalculator.GetTaxBracket(annualSalary);

            var incomeTax = taxCalculator.CalculateIncomeTax(annualSalary, taxBracket);

            return Round(incomeTax);
        }

        public int CalculateNetIncome(decimal grossIncome, decimal incomeTax)
        {
            return Round(grossIncome - incomeTax);
        }

        public int CalculateSuper(decimal grossIncome, decimal superRate)
        {
            return Round((decimal)grossIncome * superRate / 100);
        }

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

        // rounded up/down
        public int Round(decimal number)
        {
            return (int)Math.Round(number, MidpointRounding.AwayFromZero);
        }
    }
}
