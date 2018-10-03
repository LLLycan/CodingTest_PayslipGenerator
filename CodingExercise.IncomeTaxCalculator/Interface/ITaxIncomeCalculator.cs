using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercise.IncomeTaxCalculator.Interface
{
    /// <summary>
    /// Interface for calculator income tax based on annual salary
    /// </summary>
    public interface ITaxIncomeCalculator
    {
        int CalculateIncomeTax(int annualSalary);
    }
}
