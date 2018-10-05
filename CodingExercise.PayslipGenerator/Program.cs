using CodingExercise.FileHandler;
using CodingExercise.PayslipCalculator.Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodingExercise.PayslipGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PayslipForm());
            //try
            //{
            //    Console.WriteLine("Ready to processing file...");
            //    Console.ReadLine();
            //}
            //catch (FileNotFoundException)
            //{
            //    // Show message of File not exist
            //    Console.WriteLine("File not exists! Please provide a valid file path.");
            //}
            //catch (InvalidDataException)
            //{
            //    // Show message of dataset format invalid
            //    Console.WriteLine("Invalid file data format! Please provide a valid data file.");
            //}
            //catch (Exception)
            //{
            //    // Show message of unknow error
            //    Console.WriteLine("Unknown error! Please try later.");
            //}
            //Console.ReadKey();
        }
    }
}
