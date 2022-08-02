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

            //Update the Base Pay for employee Terissa using prepared statement
            UpdateBasePayPreparedSTatement("Terissa");

            //Retrieve employees joined in particular date range
            RetrieveEmployeeFromParticularDateRange();

            //Retrieve Sum of Male Employee Salary
            SUMofMaleEmployeeSalary();

            //Retrieve Sum of Male Employee Salary
            SUMofFemaleEmployeeSalary();

            //Retrieve Average Salary of Male Employee
            AVGofMaleEmployeeSalary();

            //Retrieve Average Salary of Female Employee
            AVGofFemaleEmployeeSalary();

            //Retrieve Minimum Salary of Male Employee 
            MINofMaleEmployeeSalary();

            //Retrieve Minimum Salary of Female Employee 
            MINofFemaleEmployeeSalary();

            //Retrieve Maximum Salary of Male Employee 
            MAXofMaleEmployeeSalary();

            //Retrieve Maximum Salary of Female Employee 
            MAXofFemaleEmployeeSalary();

            //Retrieve Number (Count) of Male Employee 
            COUNTofMaleEmployee();

            //Retrieve Number (Count) of Female Employee 
            COUNTofFemaleEmployee();

            //UC7:Add New Employee to the Payroll
            AddNewEmployeeToAddressBook("Sharan");

            //UC8:Add Payroll details of newly added Employee to the Payroll
            AddNewPayrollDetailsofNewlyAddedEmployeeToAddressBook("Sharan");
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

        //UC4:Update the Base Pay for employee Terissa using prepared statement
        public static void UpdateBasePayPreparedSTatement(string EmployeeName)
        {
            EmployeePayroll emp = new EmployeePayroll()
            {
                name = EmployeeName,
                BasicPay = 3000000,
                Deductions = 1000000,
                TaxablePay = 400000,
                IncomeTax = 600000,
                NetPay = 200000
            };
            var SQL = @$"UPDATE employee_payroll SET BasicPay = '{emp.BasicPay}', Deductions = '{emp.Deductions}', TaxablePay= '{emp.TaxablePay}', IncomeTax = '{emp.IncomeTax}', NetPay = '{emp.NetPay}' WHERE name = '{emp.name}'";
            string connectingString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_payroll_service;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            int reader = cmd.ExecuteNonQuery();
            Console.WriteLine(reader);
            Console.WriteLine("Updated the Basic Pay Successfully");
            Console.ReadKey();
        }

        //UC5:Retrieve employees joined in particular date range
        public static void RetrieveEmployeeFromParticularDateRange()
        {
            var SQL = @$"select name FROM employee_payroll WHERE startdate BETWEEN CAST('2019-01-01' AS DATE) AND GETDATE()";
            string connectingString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_payroll_service;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Employee Name {0}", reader["name"]);
                }
                reader.Close();
            };
            Console.WriteLine("\nRetrieve data Successfully");
            Console.ReadKey();
        }

        //UC6:Find SUM, AVG,MIN, MAX,Number of Male & Female Employee
        //Retrieve Sum of Male Employee Salary
        public static void SUMofMaleEmployeeSalary()
        {
            var SQL = @$"select SUM(salary) FROM employee_payroll where gender = 'M' GROUP BY gender";
            string connectingString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_payroll_service;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();

            int reader = (int)cmd.ExecuteScalar();
            Console.WriteLine("Sum of Male Employee Salary is : " + reader); ;
            Console.ReadKey();
        }
        //Retrieve Sum of Female Employee Salary
        public static void SUMofFemaleEmployeeSalary()
        {
            var SQL = @$"select SUM(salary) FROM employee_payroll where gender = 'F' GROUP BY gender";
            string connectingString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_payroll_service;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();

            int reader = (int)cmd.ExecuteScalar();
            Console.WriteLine("Sum of Female Employee Salary is : " + reader);
            Console.ReadKey();
        }
        //Retrieve Average Salary of Male Employee
        public static void AVGofMaleEmployeeSalary()
        {
            var SQL = @$"select AVG(salary) FROM employee_payroll where gender = 'M' GROUP BY gender";
            string connectingString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_payroll_service;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();

            int reader = (int)cmd.ExecuteScalar();
            Console.WriteLine("Average Salary of Male Employee is : " + reader); ;
            Console.ReadKey();
        }
        //Retrieve Average Salary of Female Employee
        public static void AVGofFemaleEmployeeSalary()
        {
            var SQL = @$"select AVG(salary) FROM employee_payroll where gender = 'F' GROUP BY gender";
            string connectingString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_payroll_service;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();

            int reader = (int)cmd.ExecuteScalar();
            Console.WriteLine("Average Salary of Female Employee is : " + reader);
            Console.ReadKey();
        }
        //Retrieve Minimum Salary of Male Employee 
        public static void MINofMaleEmployeeSalary()
        {
            var SQL = @$"select MIN(salary) FROM employee_payroll where gender = 'M' GROUP BY gender";
            string connectingString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_payroll_service;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();

            int reader = (int)cmd.ExecuteScalar();
            Console.WriteLine("Minimum Salary of Male Employee is : " + reader); ;
            Console.ReadKey();
        }
        //Retrieve Minimum Salary of Female Employee 
        public static void MINofFemaleEmployeeSalary()
        {
            var SQL = @$"select MIN(salary) FROM employee_payroll where gender = 'F' GROUP BY gender";
            string connectingString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_payroll_service;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();

            int reader = (int)cmd.ExecuteScalar();
            Console.WriteLine("Minimum Salary of Female Employee is : " + reader);
            Console.ReadKey();
        }
        //Retrieve Maximum Salary of Male Employee 
        public static void MAXofMaleEmployeeSalary()
        {
            var SQL = @$"select MAX(salary) FROM employee_payroll where gender = 'M' GROUP BY gender";
            string connectingString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_payroll_service;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();

            int reader = (int)cmd.ExecuteScalar();
            Console.WriteLine("Maximum Salary of Male Employee is : " + reader); ;
            Console.ReadKey();
        }
        //Retrieve Maximum Salary of Female Employee 
        public static void MAXofFemaleEmployeeSalary()
        {
            var SQL = @$"select MAX(salary) FROM employee_payroll where gender = 'F' GROUP BY gender";
            string connectingString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_payroll_service;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();

            int reader = (int)cmd.ExecuteScalar();
            Console.WriteLine("Maximum Salary of Female Employee is : " + reader);
            Console.ReadKey();
        }
        //Retrieve Number (Count) of Male Employee 
        public static void COUNTofMaleEmployee()
        {
            var SQL = @$"select COUNT(salary) FROM employee_payroll where gender = 'M' GROUP BY gender";
            string connectingString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_payroll_service;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();

            int reader = (int)cmd.ExecuteScalar();
            Console.WriteLine("Number (Count) of Male Employee is : " + reader); ;
            Console.ReadKey();
        }
        //Retrieve Number (Count) of Female Employee 
        public static void COUNTofFemaleEmployee()
        {
            var SQL = @$"select COUNT(salary) FROM employee_payroll where gender = 'F' GROUP BY gender";
            string connectingString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_payroll_service;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();

            int reader = (int)cmd.ExecuteScalar();
            Console.WriteLine("Number (Count) of Female Employee : " + reader);
            Console.ReadKey();
        }

        //UC7: Add New Employee to the Payroll
        public static void AddNewEmployeeToAddressBook(string EmployeeName)
        {
            EmployeePayroll emp = new EmployeePayroll()
            {
                name = EmployeeName,
                salary = 300000,
                address = "Mumbai"

            };
            var SQL = @$"INSERT INTO employee_payroll (name, salary,startdate,address) Values ('{emp.name}','{emp.salary}','2017-04-12','{emp.address}')";
            string connectingString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_payroll_service;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            int reader = cmd.ExecuteNonQuery();
            Console.WriteLine(reader);
            Console.WriteLine("Employee added Successfully");
            Console.ReadKey();
        }

        //UC8:Add Payroll details of newly added Employee to the Payroll
        public static void AddNewPayrollDetailsofNewlyAddedEmployeeToAddressBook(string EmployeeName)
        {
            EmployeePayroll emp = new EmployeePayroll()
            {
                name = EmployeeName,

            };
            var SQL = @$"update employee_payroll set  gender = 'M', phone = 9642531895, departmentID = 2, BasicPay = 45000, Deductions = 9000, TaxablePay = 1000, IncomeTax = 1000, NetPay= 34000 where name = '{emp.name}'";
            string connectingString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_payroll_service;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            int reader = cmd.ExecuteNonQuery();
            Console.WriteLine(reader);
            Console.WriteLine("Updated the payroll details Successfully");
            Console.ReadKey();
        }
    }
}
    