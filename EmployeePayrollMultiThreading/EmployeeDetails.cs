using System;

namespace EmployeePayrollMultiThreading
{
    public class EmployeeDetails
    {
        public EmployeeDetails(string name, decimal basic_pay, DateTime StartDate , string gender, string phone, string address, string department, double deductions, double taxable_pay, double income_tax, double net_pay )
        {
            //this.Id = id;
            this.Name = name;
            this.basic_pay = basic_pay;
            this.StartDate = StartDate;
            this.Gender = gender;
            this.Phone = phone;
            this.Address = address;
            this.Department = department;
            this.Deductions = deductions;
            this.taxable_pay = taxable_pay;
            this.income_tax = income_tax;
           
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal basic_pay { get; set; }
        public DateTime StartDate  { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public double Deductions { get; set; }
        public double taxable_pay { get; set; }
        public double income_tax { get; set; }
        public double net_pay { get; set; }
       
    }
}
