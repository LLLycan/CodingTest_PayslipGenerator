using System;
using System.Collections.Generic;
using System.IO;
using CodingExercise.FileHandler;
using CodingExercise.FileHandler.Factory;
using CodingExercise.FileHandler.Interface;
using CodingExercise.PayslipCalculator;
using CodingExercise.PayslipEntity.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingExercise.Test.FileHandlerTest
{
    [TestClass]
    public class CSVFileProcessorTest
    {
        CsvFileProcessor _fileProcessor;
        MonthlyPayslipCalculator _payslipCalc;

        [TestInitialize]
        public void Initialize()
        {
            _fileProcessor = new CsvFileProcessor();
            _payslipCalc = new MonthlyPayslipCalculator();
        }

        [TestMethod]
        public void Given_A_FileProcessorType_Should_Create_Correct_Instance()
        {
            // Arrange
            var fileProcessorType = FileProcessorFactory.GetFileProcessorType("CsvFileProcessor");

            // Assert
            Assert.IsInstanceOfType(fileProcessorType, typeof(IFileProcessor));
        }

        [TestMethod]
        public void Given_An_Invalidated_FilePath_Throw_FileNotFoundException()
        {
            try
            {
                // Arrange
                string path = @"..\..\..\Demo Data\input\employees_wrong.csv";

                // Act
                var result = _fileProcessor.Read(path);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is FileNotFoundException);
            }
        }

        [TestMethod]
        public void Given_A_Validated_File_Return_Correct_Object()
        {
            // Arrange
            string path = @"..\..\..\Demo Data\input\employees.csv";

            // Act
            var result = _fileProcessor.Read(path);

            // Assert
            Assert.AreEqual(result[0].FirstName, "David");
            Assert.AreEqual(result[0].LastName, "Rudd");
            Assert.AreEqual(result[0].AnnualSalary, 60050);
            Assert.AreEqual(result[0].SuperRate, 9);
            Assert.AreEqual(result[0].PayPeriod, "01 March-31 March");
        }

        [TestMethod]
        public void Given_A_NonCSVFile_Throw_InvalidDataException()
        {
            try
            {
                // Arrange
                string path = @"..\..\..\Demo Data\input\employees.txt";

                // Act
                var result = _fileProcessor.Read(path);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is InvalidDataException);
            }
        }

        [TestMethod]
        public void Given_A_Validated_CsvLine_Can_Return_Correct_Object()
        {
            // Arrange
            string[] csvLine = new string[] { "David", "Rudd", "60050", "9%", "01 March-31 March" };

            // Act
            var result = _fileProcessor.Map(csvLine);

            // Assert
            Assert.AreEqual(result.FirstName, "David");
            Assert.AreEqual(result.LastName, "Rudd");
            Assert.AreEqual(result.AnnualSalary, 60050);
            Assert.AreEqual(result.SuperRate, 9);
            Assert.AreEqual(result.PayPeriod, "01 March-31 March");
        }

        [TestMethod]
        public void Given_An_Invalidated_CsvLine_Throw_InvalidDataException()
        {
            try
            {
                // Arrange
                string[] csvLine = new string[] { "David", "Rudd", "60050#", "9x%", "01 March-31 March" };

                // Act
                var result = _fileProcessor.Map(csvLine);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is InvalidDataException);
            }
        }

        [TestMethod]
        public void Given_A_List_Of_Payslips_Should_Be_WriteAsCSV()
        {
            // Arrange
            var payslips = new List<Payslip>
            {
                new Payslip{
                    Name = "David Rudd",
                    PayPeriod = "01 March-31 March",
                    GrossIncome = 5004,
                    IncomeTax = 922,
                    NetIncome = 4082,
                    Super = 450
                }
            };

            _fileProcessor.Write(payslips);

            var result = _fileProcessor.Read(@"..\..\..\Demo Data\output\payslip.csv");

            // Assert
            Assert.AreEqual(result[0].FirstName, "David Rudd");
        }
    }
}
