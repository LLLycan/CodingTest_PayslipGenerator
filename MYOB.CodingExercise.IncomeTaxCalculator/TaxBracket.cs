using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercise.IncomeTaxCalculator
{
    /// <summary>
    /// Define Tax Bracket class for multi-band tax rate purpose
    /// </summary>
    public class TaxBracket
    {
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
        public decimal TaxSurplus { get; set; }
        public decimal TaxRate { get; set; }

        public TaxBracket(decimal min, decimal max, decimal surplus, decimal rate)
        {
            MinSalary = min;
            MaxSalary = max;
            TaxSurplus = surplus;
            TaxRate = rate;
        }
    }
}
