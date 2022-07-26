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

--UC5-Retrieve salary data from particular employee
SELECT salary FROM employee_payroll
WHERE name = 'Vaibhav'

--UC5-Retrieve Names from the selected date to present date
select name FROM employee_payroll
WHERE startdate BETWEEN CAST('2019-01-01' AS DATE) AND GETDATE()

--UC6--
--Alter table to add gender column
ALTER TABLE employee_payroll
add  gender char 

--update the gender 
update  employee_payroll
set gender = 'M'


update  employee_payroll
set gender = 'F'
where Name = 'Sai''Minu'

--add field gender field after name field
select id,name,gender,startdate,salary from employee_payroll


--UC7--
--Sum of salary of employee groupby Male & Female employee
select SUM(salary) FROM employee_payroll where gender = 'M' GROUP BY gender
select SUM(salary) FROM employee_payroll where gender = 'F' GROUP BY gender

--Average salary of employee groupby Male & Female employee
select AVG(salary) FROM employee_payroll where gender = 'M' GROUP BY gender
select AVG(salary) FROM employee_payroll where gender = 'F' GROUP BY gender


--Min salary of employee groupby Male & Female employee
select MIN(salary) FROM employee_payroll where gender = 'M' GROUP BY gender
select MIN(salary) FROM employee_payroll where gender = 'F' GROUP BY gender


--Max salary of employee groupby Male & Female employee
select MAX(salary) FROM employee_payroll where gender = 'M' GROUP BY gender
select MAX(salary) FROM employee_payroll where gender = 'F' GROUP BY gender


--Number of employee groupby Male &Female employee
select COUNT(salary) FROM employee_payroll where gender = 'M' GROUP BY gender
select COUNT(salary) FROM employee_payroll where gender = 'F' GROUP BY gender