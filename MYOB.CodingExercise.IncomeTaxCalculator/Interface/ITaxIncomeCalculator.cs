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
        /// <summary>
        /// Given annual salary and tax bracket, return income tax
        /// </summary>
        /// <param name="annualSalary">annual salary</param>
        /// <param name="taxBracket">tax bracket object</param>
        /// <returns>income tax</returns>
        decimal CalculateIncomeTax(decimal annualSalary, TaxBracket taxBracket);

        /// <summary>
        /// Given annual salary, get tax bracket
        /// </summary>
        /// <param name="annualSalary">annual salary</param>
        /// <returns>tax bracket object</returns>
        TaxBracket GetTaxBracket(decimal salary);
    }
}
