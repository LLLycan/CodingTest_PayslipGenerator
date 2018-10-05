using CodingExercise.IncomeTaxCalculator.Interface;
using CodingExercise.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercise.IncomeTaxCalculator
{
    /// <summary>
    /// Tax Calculation are different based on annual salary and Tax Bracket
    /// </summary>
    public class TaxIncomeCalculator : ITaxIncomeCalculator
    {
        // Add const variable to define current tax brackets, also for further maintain purpose
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

        // binding to tax calculator constructor
        public TaxIncomeCalculator()
        {
            _taxBrackets.Add(new TaxBracket(_firstBandMinSalary, _secondBandMinSalary - 1, _firstBandSurplusTax, _firstBandTaxRate));
            _taxBrackets.Add(new TaxBracket(_secondBandMinSalary, _thirdBandMinSalary - 1, _secondBandSurplusTax, _secondBandTaxRate));
            _taxBrackets.Add(new TaxBracket(_thirdBandMinSalary, _fourthBandMinSalary - 1, _thirdBandSurplusTax, _thirdBandTaxRate));
            _taxBrackets.Add(new TaxBracket(_fourthBandMinSalary, _fivethBandMinSalary - 1, _fourthBandSurplusTax, _fourthBandTaxRate));
            _taxBrackets.Add(new TaxBracket(_fivethBandMinSalary, decimal.MaxValue, _fivethBandSurplusTax, _fivethBandTaxRate));
        }

        // get relevant tax bracket based on annual salary
        public TaxBracket GetTaxBracket(int annualSalary)
        {
            TaxBracket taxBracket = _taxBrackets.SingleOrDefault(x => annualSalary >= x.MinSalary && annualSalary <= x.MaxSalary);

            return taxBracket;
        }

        // calculate income tax based on salary and tax bracket
        public int CalculateIncomeTax(int annualSalary, TaxBracket taxBracket)
        {
            var incomeTax = (taxBracket.TaxSurplus + (annualSalary - taxBracket.MinSalary - 1) * (taxBracket.TaxRate / 100)) / 12;
            return Round(incomeTax);
        }

        // rounded up/down
        public int Round(decimal number)
        {
            return (int)Math.Round(number, MidpointRounding.AwayFromZero);
        }
    }
}
