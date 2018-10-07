# MYOB Coding Exercise

# Author: Yuxuan Li (yli89@outlook.com)

# Description: 
This is a C# based coding exercise solution for calculate employee monthly payslip from .csv file

# Requirement: 
1. Reading a .csv employee details file, output monthly payslip as .csv file.
2. The calculation details will be the following:
	• pay period = per calendar month
	• gross income = annual salary / 12 months
	• income tax = based on the tax table provided below
	• net income = gross income - income tax
	• super = gross income x super rate
3. Notes: All calculation results should be rounded to the whole dollar. If >= 50 cents round up to the next dollar
increment, otherwise round down.
4. Input: first name, last name, annual salary, super rate (%), payment start date, such as 'David,Rudd,60050,9%,01 March – 31 March'
   Ouput: name, pay period, gross income, income tax, net income, super, such as 'David Rudd,01 March – 31 March,5004,922,4082,450'

# Assumptions:
1. There are different kinds of data file type (.csv, .txt, .sql, .json...) may need to implement in the future. 
   For solution extensibility I created file processor interface & factory, which easy to add new data file
   processor type and logic. Currently use derived CsvFileProcessor.cs as main data file processor.
2. Considering the income tax calculation formula and parameters specified in the requirement, and the potential 
   for future extension. So I defined tax bracket and created income tax calculator interface. Currenlty using 
   derived TaxIncomeCalculator.cs as mian tax calculation method which easy to grab correct tax bracket and 
   calculate income tax based on salary.
3. There are different kinds of payslip calculation type (monthly, weekly, fortnightly...) may need to implement
   in the future. For considering extensibility I also created payslip calculator interface & factory, which easy
   to add new payslip method. Currently using derived MonthlyPayslipCalculator.cs as main payslip calculate method.
4. For solution scalability, using configurable value for FileProcessorType, PayslipType and Input & Output path.

# Testing:
1. Testing Area: 
All test cases are based on three core component of FileProcessor, IncomeTax and Payslip, testing class are 
CsvFileProcessorTest.cs, IncomeTaxCalcTest.cs and MonthlyPayslipCalcTest.cs
2. TDD Methodology: 
Tried using TDD in this coding exercise. Simple create entities class & interface first, then write test case based on core business logic, run & fail. Based 
on failed test case result, back to solution and implement method & logic, run again. Repeat doing this, until 
test cases pass.
3. Unit Testing: 
Based on few existing logic, review and found issue, then fixed issue and then write test case to test & enhance
until all logic running properly.

# Project Running Instruction:
1. Download from Yuxuan Li's github repositorie: https://github.com/LLLycan/CodingTest_PayslipGenerator
2. Demo sample input file in:'~/Demo Data/Input/employees.csv', and output file in:'~/Demo Data/Output/payslip.csv'
3. UnZip project, and open with Visual Studio
4. Choose 'MYOB.CodingExercise.App' and set as startup project
5. Clean, build and run solution
