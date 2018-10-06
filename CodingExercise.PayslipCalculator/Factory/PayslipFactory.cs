﻿using CodingExercise.PayslipCalculator.Interface;
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
                throw new Exception("Cannot find validated payslip calculation type.");
            }
        }
    }
}
