using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercise.PayslipEntity.Extension
{
    /// <summary>
    /// Extension: each results in the system should be rounded to Integer value
    /// </summary>
    public static class RoundedToInt
    {
        public static int Round(double number)
        {
            return (int)Math.Round(number, MidpointRounding.AwayFromZero);
        }
    }
}
