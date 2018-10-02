using CodingExercise.FileHandler.Interface;
using CodingExercise.PayslipEntity.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodingExercise.FileHandler
{
    /// <summary>
    /// Sealed class only for .csv File I/O
    /// </summary>
    public sealed class CSVFileReader : IFileReader
    {
        /// <summary>
        /// Given a file path, read & return as Employee list
        /// </summary>
        public List<Employee> Read(string path)
        {
            var employees = new List<Employee>();

            string[] csvData = null;


            if (string.IsNullOrEmpty(path))
            {
                throw new FileNotFoundException();
            }
            else if (Path.GetExtension(path) != ".csv")
            {
                throw new InvalidDataException();
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
        /// For each line from .csv, mapping to single Employee object
        /// </summary>
        public Employee Map(string[] strs)
        {
            try
            {
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
    }
}
