using CodingExercise.IncomeTaxCalculator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercise.IncomeTaxCalculator.Factory
{
    /// <summary>
    /// Factory & Reflection for create instance based on income tax calculator type
    /// </summary>
    public class IncomeTaxFactory
    {
        public static ITaxIncomeCalculator GetIncomeTaxType(string type)
        {
            try
            {
                Assembly currentAssembly = Assembly.GetExecutingAssembly();

                var currentType = currentAssembly.GetTypes().SingleOrDefault(t => t.Name == type);

                return (ITaxIncomeCalculator)Activator.CreateInstance(currentType);
            }
            catch (Exception)
            {
                throw new Exception("Cannot find validated income tax calculation type.");
            }
        }
    }
}
