using CodingExercise.IncomeTaxCalculator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingExercise.IncomeTaxCalculator
{
    /// <summary>
    /// Tax Calculation are different based on annual salary and tax bracket
    /// </summary>
    public class TaxIncomeCalculator : ITaxIncomeCalculator
    {
        // define current tax brackets list
        private readonly List<TaxBracket> _taxBrackets = new List<TaxBracket>();

        // const max salary limits for different tax brackets
        private const decimal _firstBandMinSalary = 0;
        private const decimal _secondBandMinSalary = 18201;
        private const decimal _thirdBandMinSalary = 37001;
        private const decimal _fourthBandMinSalary = 87001;
        private const decimal _fivethBandMinSalary = 180001;

        // const tax surplus for different tax brackets
        private const decimal _firstBandSurplusTax = 0;
        private const decimal _secondBandSurplusTax = 0;
        private const decimal _thirdBandSurplusTax = 3572;
        private const decimal _fourthBandSurplusTax = 19822;
        private const decimal _fivethBandSurplusTax = 54232;

        // const tax rates for different tax brackets
        private const decimal _firstBandTaxRate = 0;
        private const decimal _secondBandTaxRate = 19;
        private const decimal _thirdBandTaxRate = 32.5M;
        private const decimal _fourthBandTaxRate = 37;
        private const decimal _fivethBandTaxRate = 45;

        // binding tax nracket to tax calculator constructor
        public TaxIncomeCalculator()
        {
            _taxBrackets.Add(new TaxBracket(_firstBandMinSalary, _secondBandMinSalary - 1, _firstBandSurplusTax, _firstBandTaxRate));
            _taxBrackets.Add(new TaxBracket(_secondBandMinSalary, _thirdBandMinSalary - 1, _secondBandSurplusTax, _secondBandTaxRate));
            _taxBrackets.Add(new TaxBracket(_thirdBandMinSalary, _fourthBandMinSalary - 1, _thirdBandSurplusTax, _thirdBandTaxRate));
            _taxBrackets.Add(new TaxBracket(_fourthBandMinSalary, _fivethBandMinSalary - 1, _fourthBandSurplusTax, _fourthBandTaxRate));
            _taxBrackets.Add(new TaxBracket(_fivethBandMinSalary, decimal.MaxValue, _fivethBandSurplusTax, _fivethBandTaxRate));
        }

        /// <summary>
        /// Given annual salary, get tax bracket
        /// </summary>
        /// <param name="annualSalary">annual salary</param>
        /// <returns>tax bracket object</returns>
        public TaxBracket GetTaxBracket(decimal annualSalary)
        {
            TaxBracket taxBracket = _taxBrackets.SingleOrDefault(x => annualSalary >= x.MinSalary && annualSalary <= x.MaxSalary);
            return taxBracket;
        }

        /// <summary>
        /// Given annual salary and tax bracket, return income tax
        /// </summary>
        /// <param name="annualSalary">annual salary</param>
        /// <param name="taxBracket">tax bracket</param>
        /// <returns>income tax</returns>
        public decimal CalculateIncomeTax(decimal annualSalary, TaxBracket taxBracket)
        {
            var incomeTax = (taxBracket.TaxSurplus + (annualSalary - taxBracket.MinSalary - 1) * (taxBracket.TaxRate / 100));
            return Round(incomeTax);
        }

        /// <summary>
        /// Rounded up & down for a decimal number
        /// </summary>
        /// <param name="number">number</param>
        /// <returns>int type number</returns>
        public int Round(decimal number)
        {
            return (int)Math.Round(number, MidpointRounding.AwayFromZero);
        }
    }
}
