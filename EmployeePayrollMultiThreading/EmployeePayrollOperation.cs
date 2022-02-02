using System.Data.SqlClient;
using System.Data;

namespace EmployeePayrollMultiThreading
{
    public class EmployeePayrollOperation
    {
        public static string connectionString = @"Data Source = localhost\SQLEXPRESS; Initial Catalog = payroll_service; Integrated Security = True";
        SqlConnection connection = new SqlConnection(connectionString);

        public bool ConnectionString()
        {
            try
            {
                this.connection.Open();
                using (this.connection)
                {
                        Console.WriteLine($"connection : {connectionString} established successfully at {DateTime.Now} \n ");
                }
                this.connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return true;
        }

        public List<EmployeeDetails> employeeDetailsList = new List<EmployeeDetails>();
        public void addEmployeeToPayroll(List<EmployeeDetails> employeeDetailsList) 
        {
            employeeDetailsList.ForEach(empData =>
            {
                Console.WriteLine("Employee being added " + empData.Name);
                this.addEmployeePayroll(empData);
                Console.WriteLine("Employee added " + empData.Name);
                
            });
        }
        public void addEmployeePayroll(EmployeeDetails emp)
        {
            employeeDetailsList.Add(emp);
        }

        public bool addEmployeeToDatabase(EmployeeDetails employeeDetails)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("dbo.spemployeedetails", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Name", employeeDetails.Name);
                    command.Parameters.AddWithValue("basic_pay", employeeDetails.basic_pay);
                    command.Parameters.AddWithValue("StartDate", employeeDetails.StartDate);
                    command.Parameters.AddWithValue("Gender", employeeDetails.Gender);
                    command.Parameters.AddWithValue("Phone", employeeDetails.Phone);
                    command.Parameters.AddWithValue("address", employeeDetails.Address);
                    command.Parameters.AddWithValue("Department", employeeDetails.Department);
                    command.Parameters.AddWithValue("Deductions", employeeDetails.Deductions);
                    command.Parameters.AddWithValue("taxable_pay", employeeDetails.taxable_pay);
                    command.Parameters.AddWithValue("income_tax", employeeDetails.income_tax);
                    command.Parameters.AddWithValue("net_pay", employeeDetails.net_pay);

                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                        return true;
                            return false;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return true;
        }
    }
}
