using CodingExercise.IncomeTaxCalculator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercise.IncomeTaxCalculator
{
    /// <summary>
    /// Derived income tax calculation class for VIC based
    /// </summary>
    public class VICIncomeTaxCalculator : ITaxIncomeCalculator
    {
        /// <summary>
        /// Calculation different based on annual salary
        /// </summary>
        public int CalculateIncomeTax(int annualSalary)
        {
            int incomeTax = 0;

            if (annualSalary <= 18200 && annualSalary > 0)
            {
                incomeTax = 0;
            }

            else if (annualSalary >= 18201 && annualSalary <= 37000)
            {
                incomeTax = Round(((annualSalary - 18200) * 0.19) / 12);
            }

            else if (annualSalary >= 37001 && annualSalary <= 87000)
            {
                incomeTax = Round((3572 + ((annualSalary - 37000) * 0.325)) / 12);
            }

            else if (annualSalary >= 87001 && annualSalary <= 180000)
            {
                incomeTax = Round((19822 + ((annualSalary - 87000) * 0.37)) / 12);
            }

            else if (annualSalary >= 180001)
            {
                incomeTax = Round((54232 + ((annualSalary - 180000) * 0.45)) / 12);
            }

            return incomeTax;
        }

        /// <summary>
        /// Calculation results should be rounded to Integer value
        /// </summary>
        public int Round(double number)
        {
            return (int)Math.Round(number, MidpointRounding.AwayFromZero);
        }
    }
}
