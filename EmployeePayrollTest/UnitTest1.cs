using System;
using System.Collections.Generic;
using EmployeePayrollMultiThreading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeePayrollTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Given10Employee_WhenAddedToList_ShouldMatchEmployeeEntries()
        {
            List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();

            employeeDetails.Add(new EmployeeDetails(name: "Bruce", basic_pay: 100000, StartDate: new DateTime(2019, 08, 01), gender: "M", phone: "9999999999", address: "XYZ", department: "Mechanical", deductions: 1000, taxable_pay: 20, income_tax: 100, net_pay: 90000));
            employeeDetails.Add(new EmployeeDetails(name: "Wayne", basic_pay: 100000, StartDate: new DateTime(2019, 06, 01), gender: "M", phone: "9999999999", address: "XYZ", department: "Civil", deductions: 1000, taxable_pay: 20, income_tax: 100, net_pay: 90000));
            employeeDetails.Add(new EmployeeDetails(name: "Peter", basic_pay: 100000, StartDate: new DateTime(2020, 08, 01), gender: "M", phone: "9999999999", address: "XYZ", department: "Electrical", deductions: 1000, taxable_pay: 20, income_tax: 100, net_pay: 90000));
            employeeDetails.Add(new EmployeeDetails(name: "Parker", basic_pay: 100000, StartDate: new DateTime(2020, 04, 01), gender: "M", phone: "9999999999", address: "XYZ", department: "CS", deductions: 1000, taxable_pay: 20, income_tax: 100, net_pay: 90000));
            employeeDetails.Add(new EmployeeDetails(name: "Tony", basic_pay: 100000, StartDate: new DateTime(2018, 08, 01), gender: "M", phone: "9999999999", address: "XYZ", department: "Electronics", deductions: 1000, taxable_pay: 20, income_tax: 100, net_pay: 90000));
            employeeDetails.Add(new EmployeeDetails(name: "Stark", basic_pay: 100000, StartDate: new DateTime(2018, 10, 12), gender: "M", phone: "9999999999", address: "XYZ", department: "IT", deductions: 1000, taxable_pay: 20, income_tax: 100, net_pay: 90000));

            //UC1 duration without thread
            EmployeePayrollOperation employeePayrollOperations = new EmployeePayrollOperation();

            DateTime startDateTime = DateTime.Now;
            employeePayrollOperations.addEmployeeToPayroll(employeeDetails);
            DateTime stopDateTime = DateTime.Now;
            Console.WriteLine("Duration without thread: " + (stopDateTime - startDateTime));

            //UC2 duration with thread 
            DateTime startDateTimeThread = DateTime.Now;
            employeePayrollOperations.addEmployeeToPayrollWithThread(employeeDetails);
            DateTime endDateTimeThread = DateTime.Now;
            Console.WriteLine("Duration with thread: " + (startDateTimeThread - endDateTimeThread ) );

        }
    }
}