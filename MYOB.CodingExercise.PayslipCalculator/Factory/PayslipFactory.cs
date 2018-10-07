using CodingExercise.PayslipCalculator.Interface;
using System;
using System.Linq;
using System.Reflection;

namespace CodingExercise.PayslipCalculator.Factory
{
    /// <summary>
    /// Factory & Reflection for create instance based on payslip calculator type
    /// </summary>
    public class PayslipFactory
    {
        /// <summary>
        /// Given a PayslipCalculatorType string, create relevant Payslip Calculator instance
        /// </summary>
        /// <param name="type">Type of PayslipCalculator</param>
        /// <returns>Payslip Calculator Instance</returns>
        public static IPayslipCalculator GetPayslipType(string type)
        {
            try
            {
                Assembly currentAssembly = Assembly.GetExecutingAssembly();
                var currentType = currentAssembly.GetTypes().SingleOrDefault(t => t.Name == type);
                return (IPayslipCalculator)Activator.CreateInstance(currentType);
            }
            catch (Exception)
            {
                throw new Exception("Cannot find correct payslip calculation type.");
            }
        }
    }
}
