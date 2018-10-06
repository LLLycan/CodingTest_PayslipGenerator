using CodingExercise.PayslipEntity.Core;
using System.Collections.Generic;

namespace CodingExercise.FileHandler.Interface
{
    /// <summary>
    /// Interface for access & read data from a file which might be .csv, .txt, .json
    /// </summary>
    public interface IFileProcessor
    {
        List<Employee> Read(string path);

        void Write(List<Payslip> payslips);
    }
}
