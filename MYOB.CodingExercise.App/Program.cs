using CodingExercise.FileHandler.Factory;
using CodingExercise.PayslipCalculator.Factory;
using System;
using System.Configuration;
using System.IO;

namespace CodingExercise.PayslipGenerator
{
    /// <summary>
    /// Application implementation and exception messaging
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var fileProcessor = FileProcessorFactory.GetFileProcessorType(ConfigurationManager.AppSettings["FileProcessor"]);
                var payslipCalculator = PayslipFactory.GetPayslipType(ConfigurationManager.AppSettings["PayslipCalculator"]);
                var payslipList = payslipCalculator.GeneratePaySlip(fileProcessor.Read(ConfigurationManager.AppSettings["FileInputPath"]));
                fileProcessor.Write(payslipList);
                Console.WriteLine("Success! Payslip in: ~/Demo Data/Output/payslip.csv");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File Path Invalidated");
            }
            catch (InvalidDataException)
            {
                Console.WriteLine("Invalid file data format");
            }
            catch (Exception)
            {
                Console.WriteLine("Unknown error.Try later");
            }
            Console.ReadLine();
        }
    }
}
