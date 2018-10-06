using CodingExercise.FileHandler.Factory;
using CodingExercise.PayslipCalculator.Factory;
using System;
using System.Configuration;
using System.IO;

namespace CodingExercise.PayslipGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var file = FileProcessorFactory.GetFileProcessorType(ConfigurationManager.AppSettings["FileProcessor"]);
                var calculator = PayslipFactory.GetPayslipType(ConfigurationManager.AppSettings["PayslipCalculator"]);
                var payslip = calculator.GeneratePaySlip(file.Read(ConfigurationManager.AppSettings["FilePath"]));

                file.Write(payslip);

                Console.WriteLine("Payslip created in: ~/Demo Data/Output/payslip.csv");
                Console.ReadLine();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not exists! Please provide a valid file path.");
            }
            catch (InvalidDataException)
            {
                Console.WriteLine("Invalid file data format! Please provide a valid data file.");
            }
            catch (Exception)
            {
                Console.WriteLine("Unknown error! Please try later.");
            }
        }
    }
}
