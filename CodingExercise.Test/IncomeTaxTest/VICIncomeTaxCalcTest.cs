using System;
using CodingExercise.IncomeTaxCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingExercise.PayslipEntity.Extension;
using CodingExercise.IncomeTaxCalculator.Factory;
using CodingExercise.IncomeTaxCalculator.Interface;

namespace CodingExercise.Test.IncomeTaxTest
{
    [TestClass]
    public class VICIncomeTaxCalcTest
    {
        VICIncomeTaxCalculator _vicTaxCalc;

        [TestInitialize]
        public void Initialize()
        {
            _vicTaxCalc = new VICIncomeTaxCalculator();
        }

        [TestMethod]
        public void Non_Integer_Number_Should_RoundedUp_Or_RoundedDown()
        {
            // Arrange
            var firstExpected = 1100;
            var secondExpected = 2556;
            var thirdExpected = 12580;
            
            // Act
            var firstResult = RoundedToInt.Round(1100.49);
            var secondResult = RoundedToInt.Round(2555.51);
            var thirdResult = RoundedToInt.Round(12580.25);

            // Assert
            Assert.AreEqual(firstExpected, firstResult);
            Assert.AreEqual(secondExpected, secondResult);
            Assert.AreEqual(thirdExpected, thirdResult);
        }

        [TestMethod]
        public void Given_AnnualSalary_Return_Annually_IncomeTax()
        {
            // Act
            var firstResult = RoundedToInt.Round(_vicTaxCalc.CalculateIncomeTax(18200));
            var secondResult = RoundedToInt.Round(_vicTaxCalc.CalculateIncomeTax(18201));
            var thirdResult = RoundedToInt.Round(_vicTaxCalc.CalculateIncomeTax(37000));
            var fourthResult = RoundedToInt.Round(_vicTaxCalc.CalculateIncomeTax(37001));
            var fivethResult = RoundedToInt.Round(_vicTaxCalc.CalculateIncomeTax(87000));
            var sixthResult = RoundedToInt.Round(_vicTaxCalc.CalculateIncomeTax(87001));
            var seventhResult = RoundedToInt.Round(_vicTaxCalc.CalculateIncomeTax(180000));
            var eighthResult = RoundedToInt.Round(_vicTaxCalc.CalculateIncomeTax(180001));
            var ninethResult = RoundedToInt.Round(_vicTaxCalc.CalculateIncomeTax(60050));
            var tenthResult = RoundedToInt.Round(_vicTaxCalc.CalculateIncomeTax(120000));

            // Assert
            Assert.AreEqual(firstResult, 0);
            Assert.AreEqual(secondResult, 0);
            Assert.AreEqual(thirdResult, 3572);
            Assert.AreEqual(fourthResult, 3572);
            Assert.AreEqual(fivethResult, 19822);
            Assert.AreEqual(sixthResult, 19822);
            Assert.AreEqual(seventhResult, 54232);
            Assert.AreEqual(eighthResult, 54232);
            Assert.AreEqual(ninethResult, 11063);
            Assert.AreEqual(tenthResult, 32032);
        }

        [TestMethod]
        public void Given_AnnualSalary_Return_Monthly_IncomeTax()
        {
            // Act
            var firstResult = RoundedToInt.Round(_vicTaxCalc.CalculateIncomeTax(18200) / 12);
            var secondResult = RoundedToInt.Round(_vicTaxCalc.CalculateIncomeTax(18201) / 12);
            var thirdResult = RoundedToInt.Round(_vicTaxCalc.CalculateIncomeTax(37000) / 12);
            var fourthResult = RoundedToInt.Round(_vicTaxCalc.CalculateIncomeTax(37001) / 12);
            var fivethResult = RoundedToInt.Round(_vicTaxCalc.CalculateIncomeTax(87000) / 12);
            var sixthResult = RoundedToInt.Round(_vicTaxCalc.CalculateIncomeTax(87001) / 12);
            var seventhResult = RoundedToInt.Round(_vicTaxCalc.CalculateIncomeTax(180000) / 12);
            var eighthResult = RoundedToInt.Round(_vicTaxCalc.CalculateIncomeTax(180001) / 12);
            var ninethResult = RoundedToInt.Round(_vicTaxCalc.CalculateIncomeTax(60050) / 12);
            var tenthResult = RoundedToInt.Round(_vicTaxCalc.CalculateIncomeTax(120000) / 12);

            // Assert
            Assert.AreEqual(firstResult, 0);
            Assert.AreEqual(secondResult, 0);
            Assert.AreEqual(thirdResult, 298);
            Assert.AreEqual(fourthResult, 298);
            Assert.AreEqual(fivethResult, 1652);
            Assert.AreEqual(sixthResult, 1652);
            Assert.AreEqual(seventhResult, 4519);
            Assert.AreEqual(eighthResult, 4519);
            Assert.AreEqual(ninethResult, 922);
            Assert.AreEqual(tenthResult, 2669);
        }

        [TestMethod]
        public void Given_A_Validate_IncomeTaxCalculatorType_Should_Create_Correct_TypeOfInstance()
        {
            // Arrange
            var incomeTaxType = IncomeTaxFactory.GetIncomeTaxType("VICIncomeTaxCalculator");

            // Assert
            Assert.IsInstanceOfType(incomeTaxType, typeof(ITaxIncomeCalculator));
        }

        [TestMethod]
        public void Given_An_Invalidate_IncomeTaxCalculatorType_Should_Throw_Exception()
        {
            try
            {
                // Arrange
                var incomeTaxType = IncomeTaxFactory.GetIncomeTaxType("NSWIncomeTaxCalculator");
            }
            catch (Exception e)
            {
                // Assert
                Assert.AreEqual("Cannot find validated income tax calculation type.", e.Message);
            }           
        }
    }
}
