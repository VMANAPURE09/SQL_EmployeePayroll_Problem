--UC1-Welcome to Employee Payroll Problem 
Create Database Employee_payroll_service

--go to the databse
use Employee_payroll_service

--UC2-Creating the Table
Create Table employee_payroll(
id int primary key identity not null,
name varchar(20) not null,
salary int not null,
startdate date not null)

--to select all / display the table
select * from employee_payroll