using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercise.PayslipEntity.Core
{
    /// <summary>
    /// Employee details
    /// </summary>
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AnnualSalary { get; set; }
        public int SuperRate { get; set; }
        public string PayPeriod { get; set; }
    }
}
