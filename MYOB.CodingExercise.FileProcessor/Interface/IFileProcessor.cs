using CodingExercise.PayslipEntity.Core;
using System.Collections.Generic;

namespace CodingExercise.FileHandler.Interface
{
    /// <summary>
    /// Interface for access & read data from a file which might be .csv, .txt, .json
    /// </summary>
    public interface IFileProcessor
    {
        /// <summary>
        /// Given a file path, read and return employee list
        /// </summary>
        /// <param name="path">file path</param>
        /// <returns>Employee List</returns>
        List<Employee> Read(string path);

        /// <summary>
        /// Given a payslip list, write into a file
        /// </summary>
        /// <param name="payslips">Payslip List</param>
        void Write(List<Payslip> payslips);
    }
}
