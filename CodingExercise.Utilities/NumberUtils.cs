using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercise.Utilities
{
    /// <summary>
    /// Project Utilities with handle number problems
    /// </summary>
    public static class NumberUtils
    {
        public static int Round(double number)
        {
            return (int)Math.Round(number, MidpointRounding.AwayFromZero);
        }

        public static int ToMonthly(this int number)
        {
            return (int)Math.Round(number / 12d, 0);
        }

        public static int ToWeekly(this int number)
        {
            return (int)Math.Round(number / 52d, 0);
        }
    }
}
