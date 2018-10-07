using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercise.PayslipEntity.Core
{
    /// <summary>
    /// Payslip output
    /// </summary>
    public class Payslip
    {
        public string Name { get; set; }
        public int GrossIncome { get; set; }
        public int IncomeTax { get; set; }
        public int NetIncome { get; set; }
        public int Super { get; set; }
        public string PayPeriod { get; set; }
    }
}
