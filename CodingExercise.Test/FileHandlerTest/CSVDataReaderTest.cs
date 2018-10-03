using System;
using System.IO;
using CodingExercise.FileHandler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingExercise.Test.FileHandlerTest
{
    [TestClass]
    public class CSVDataReaderTest
    {
        CSVFileReader _fileReader;

        [TestInitialize]
        public void Initialize()
        {
            _fileReader = new CSVFileReader();
        }

        [TestMethod]
        public void Given_An_Invalidated_FilePath_Throw_FileNotFoundException()
        {
            try
            {
                // Arrange
                string path = @"..\..\..\payslip.csv";

                // Act
                var result = _fileReader.Read(path);
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
            string path = @"..\..\..\employees.csv";

            // Act
            var result = _fileReader.Read(path);

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
                string path = @"..\..\..\employees.txt";

                // Act
                var result = _fileReader.Read(path);
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
            var result = _fileReader.Map(csvLine);

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
                var result = _fileReader.Map(csvLine);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is InvalidDataException);
            }
        }
    }
}
