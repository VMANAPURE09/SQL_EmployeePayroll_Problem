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

--UC3-Inserting the data in to table
INSERT INTO employee_payroll values ('Vaibhav',30000,'2019-07-27'),('Sanjay',40000,'2019-02-10'),('Subham',35000,'2019-11-04'),('Minu',15000,'2020-06-20'),('Sai',18000,'2019-08-01');

--UC4-to select all / display the table
select * from employee_payroll 