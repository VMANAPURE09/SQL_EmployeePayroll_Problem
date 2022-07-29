using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmployeePayrollProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome tpo Employee Payroll Problem");
            //To Display the data in database
            ReadDataFromDataBase();

            //Retrieve the employee payroll from  database
            RetrieveEmployeePayrollFromDataBase();

            //Update the Base Pay for employee Terissa
            UpdateBasePay();
        }
        //Method to Read all the data in the database
        public static void ReadDataFromDataBase()
        {
            string SQL = "select * from employee_payroll";
            string connectingstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_payroll_service;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingstring);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            try
            {

                SqlDataReader reader = cmd.ExecuteReader();
                List<EmployeePayroll> employeePayroll = new List<EmployeePayroll>();
                while (reader.Read())
                {
                    var employee = new EmployeePayroll();
                    employee.id = reader.GetInt32(0);
                    employee.name = reader.GetString(1);
                    employee.salary = reader.GetInt32(2);
                    employee.startdate = reader.GetDateTime(3);
                    employee.gender = reader.GetString(4);
                    employee.phone = reader.GetInt64(5);
                    employee.address = reader.GetString(6);
                    employee.BasicPay = reader.GetDouble(7);
                    employee.Deductions = reader.GetDouble(8);
                    employee.TaxablePay = reader.GetDouble(9);
                    employee.IncomeTax = reader.GetDouble(10);
                    employee.NetPay = reader.GetDouble(11);
                    employee.DepartmentID = reader.GetInt32(12);
                    employeePayroll.Add(employee);
                }
                reader.Close();
                foreach (var emp in employeePayroll)
                {
                    Console.WriteLine("\nID :" + emp.id +
                        "\nName :" + emp.name +
                        "\nSalary :" + emp.salary +
                        "\nStart Date : " + emp.startdate +
                        "\nGender :" + emp.gender +
                        "\nPhone :" + emp.phone +
                        "\nAddress :" + emp.address +
                        "\nBasic Pay :" + emp.BasicPay +
                        "\nDeductions :" + emp.Deductions +
                        "\nTaxable Pay :" + emp.TaxablePay +
                        "\nIncome Tax :" + emp.TaxablePay +
                        "\nNet Pay :" + emp.NetPay +
                        "\nDepartment ID :" + emp.DepartmentID);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception :" + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        //UC2-Retrieve the employee payroll from  database
        public static void RetrieveEmployeePayrollFromDataBase()
        {
            string SQL = "exec GetEmployeeDetails";
            string connectingstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_payroll_service;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingstring);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            try
            {

                SqlDataReader reader = cmd.ExecuteReader();
                List<EmployeePayroll> employeePayroll = new List<EmployeePayroll>();
                while (reader.Read())
                {
                    var employee = new EmployeePayroll();
                    employee.id = reader.GetInt32(0);
                    employee.name = reader.GetString(1);
                    employee.salary = reader.GetInt32(2);
                    employee.startdate = reader.GetDateTime(3);
                    employee.gender = reader.GetString(4);
                    employee.phone = reader.GetInt64(5);
                    employee.address = reader.GetString(6);
                    employee.BasicPay = reader.GetDouble(7);
                    employee.Deductions = reader.GetDouble(8);
                    employee.TaxablePay = reader.GetDouble(9);
                    employee.IncomeTax = reader.GetDouble(10);
                    employee.NetPay = reader.GetDouble(11);
                    employee.DepartmentID = reader.GetInt32(12);
                    employeePayroll.Add(employee);
                }
                reader.Close();
                foreach (var emp in employeePayroll)
                {
                    Console.WriteLine("\nID :" + emp.id +
                        "\nName :" + emp.name +
                        "\nSalary :" + emp.salary +
                        "\nStart Date : " + emp.startdate +
                        "\nGender :" + emp.gender +
                        "\nPhone :" + emp.phone +
                        "\nAddress :" + emp.address +
                        "\nBasic Pay :" + emp.BasicPay +
                        "\nDeductions :" + emp.Deductions +
                        "\nTaxable Pay :" + emp.TaxablePay +
                        "\nIncome Tax :" + emp.TaxablePay +
                        "\nNet Pay :" + emp.NetPay +
                        "\nDepartment ID :" + emp.DepartmentID);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception :" + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        //UC3-Update the Base Pay for employee Terissa
        public static void UpdateBasePay()
        {
            var SQL = @$"UPDATE employee_payroll SET BasicPay = 3000000, Deductions = 800000, TaxablePay= 200000, IncomeTax = 600000, NetPay = 2000000 WHERE name = 'Terissa'";
            string connectingString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_payroll_service;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            int reader = cmd.ExecuteNonQuery();
            Console.WriteLine(reader);
            Console.WriteLine("Updated the Basic Pay Successfully");
            Console.ReadKey();
        }
    }
}
