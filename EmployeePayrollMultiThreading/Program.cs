namespace EmployeePayrollMultiThreading
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll using MultiThreading !");
            EmployeePayrollOperation employeePayrollOperations = new EmployeePayrollOperation();
            employeePayrollOperations.ConnectionString();
        }
    }
}