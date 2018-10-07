using CodingExercise.FileHandler.Interface;
using CodingExercise.PayslipEntity.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;

namespace CodingExercise.FileHandler
{
    /// <summary>
    /// Sealed class only for .csv File I/O
    /// </summary>
    public sealed class CsvFileProcessor : IFileProcessor
    {
        public string outputPath = ConfigurationManager.AppSettings["FileOutputPath"];

        /// <summary>
        /// Given a .csv file path, read and return employee list
        /// </summary>
        /// <param name="path">file path</param>
        /// <returns>Employee List</returns>
        public List<Employee> Read(string path)
        {
            var employees = new List<Employee>();
            string[] csvData = null;         
            if (string.IsNullOrEmpty(path) || !File.Exists(path)) // Validate file path
            {
                throw new FileNotFoundException();
            }
            else
            {
                csvData = File.ReadAllLines(path);
                foreach (var line in csvData)
                {
                    employees.Add(Map(line.Split(',')));
                }
            }
            return employees;
        }

        /// <summary>
        /// For each data line from .csv, mapping to single Employee object
        /// </summary>
        /// <param name="strs">string array of data line</param>
        /// <returns>Employee Object</returns>
        public Employee Map(string[] strs)
        {
            try
            {
                if (int.Parse(strs[2]) < 0)
                {
                    throw new InvalidDataException();
                }
                return new Employee
                {
                    FirstName = strs[0],
                    LastName = strs[1],
                    AnnualSalary = int.Parse(strs[2]),
                    SuperRate = int.Parse(Regex.Match((strs[3]), "[0-9]*\\.*[0-9]*").Value),
                    PayPeriod = strs[4]
                };
            }
            catch (Exception)
            {
                throw new InvalidDataException();
            }
        }

        /// <summary>
        /// Given a payslip list, write into a .csv file
        /// </summary>
        /// <param name="payslips">Payslip List</param>
        public void Write(List<Payslip> payslips)
        {
            using (StreamWriter outputFile = new StreamWriter(outputPath))
            {
                foreach (var p in payslips)
                {
                    outputFile.WriteLine($"{p.Name},{p.PayPeriod},{p.GrossIncome},{p.IncomeTax},{p.NetIncome},{p.Super}");
                }
            }
        }
    }
}
