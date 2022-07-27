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

--Alter the Table
ALTER TABLE employee_payroll
add phone bigint , address varchar(25) default 'Nagpur', department varchar(20) 

select * from employee_payroll

--UC8-updating the phone, address and department field 
update employee_payroll
set phone = 9764510067, address = 'Nagpur', department = 'Chemical' where name = 'Vaibhav'

update employee_payroll
set phone = 92115363496, address = 'Godia', department = 'Electronics' where name = 'Sanjay'

update employee_payroll
set phone = 8760054592, address = 'Bangalore', department = 'Civil' where name = 'Subham'

update employee_payroll
set phone = 9865327452, address = 'Chitradurga', department = 'Computer Science' where name = 'Minu'

update employee_payroll
set phone = 8762265775, address = 'Humpi', department = 'Electrical' where name = 'Sai'

--Altering the column deparment to not null
ALTER table employee_payroll
alter column department varchar(20) not null

--Altering the column address to not null
ALTER table employee_payroll
alter column address varchar(25)  not null

--insert the data into employee_payroll table
insert into employee_payroll values ('Akash',20000,'2019-12-15','M',8742516384,'Kurkumb','Production')

--UC9--
--Altering the table by adding additional information regarding salaryies of employee
ALTER TABLE employee_payroll
add BasicPay float, Deductions float, TaxablePay float, IncomeTax float, NetPay float

--updating the BasicPay, Deduction, TaxablePay, IncomeTax & NetPay  
update employee_payroll
set BasicPay = 30000, Deductions = 2000, TaxablePay = 1000, IncomeTax = 500, NetPay= 21500 where name = 'Vaibhav'

update employee_payroll
set BasicPay = 40000, Deductions = 1000, TaxablePay = 1000, IncomeTax = 200, NetPay= 18000 where name = 'Sanjay'

update employee_payroll
set BasicPay = 35000, Deductions = 2500, TaxablePay = 1500, IncomeTax = 500, NetPay= 30000 where name = 'Subham'

update employee_payroll
set BasicPay = 15000, Deductions = 500, TaxablePay = 500, IncomeTax = 100, NetPay= 13500 where name = 'Minu'

update employee_payroll
set BasicPay = 18000, Deductions = 1000, TaxablePay = 500, IncomeTax = 100, NetPay= 16000 where name = 'Sai'

update employee_payroll
set BasicPay = 20000, Deductions = 1000, TaxablePay = 1000, IncomeTax = 200, NetPay= 18000  where name = 'Akash'

select * from employee_payroll

--UC10--
--Insert employee details
insert into employee_payroll values ('Terissa', 35000, '2018-05-06', 'F',98263579510,'Mumbai','Sales',35000, 2500, 1500, 500, 31000),
('Terissa', 35000, '2018-05-06', 'F',98263579510,'Mumbai','Marketing',35000, 2500, 1500, 500, 31000)

