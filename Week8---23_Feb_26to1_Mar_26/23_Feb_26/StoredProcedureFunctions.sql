create database ProcFunDb;

use ProcFunDb;

<-- add two number and print-->
create function sum()
returns int as
begin
declare @a int,@b int,@s int
set @A=10
set @B=20
set @s=@a+@B
return @s
end

select dbo.sum()

-- creating a procedure
Create procedure MySum(@A int,@B int, @C int=0, @D int = 0,@E int = 0)
As
	Begin
		Print @A+@B+@C+@D+@E
	End

Execute MySum 10,20
Execute MySum 10,20,30
Execute MySum 10,20,30,40
Execute MySum 10,20,30,40,50

-- creating a function that returns product of two numbers.
create function multiplys(@num1 int,@num2 int)
returns int
as
begin
declare @result int
set @result=@num1*@num2
return @result
end

select dbo.multiplys(3,4)

alter procedure callingfunct(@firstnum1 int,
@secnum2 int)
as
begin
declare @setval int
set @setval=dbo.multiplys(@firstnum1,@secnum2)
print @setval
end

exec callingfunct @firstnum1=3,@secnum2=4

CREATE TABLE Employee
(
EmpID int PRIMARY KEY,
 FirstName varchar(50)NULL,
 LastName varchar(50)NULL,
 Salary int NULL,
Address varchar(100) NULL,
)

--Insert Data
Insert into Employee(EmpID,FirstName,LastName,Salary,Address)Values(1,'Mohan','Chauahn',22000,'Delhi');
Insert into Employee(EmpID,FirstName,LastName,Salary,Address)Values(2,'Asif','Khan',15000,'Delhi');
Insert into Employee(EmpID,FirstName,LastName,Salary,Address)Values(3,'Bhuvnesh','Shakya',19000,'Noida');
Insert into Employee(EmpID,FirstName,LastName,Salary,Address)Values(4,'Deepak','Kumar',19000,'Noida');
Insert into Employee(EmpID,FirstName,LastName,Salary,Address)Values(5,'Deepika','Kumari',25000,'Noida');

--See created table
Select*from Employee 

Create function fnGetEmpFullName
(
 @FirstName varchar(50),
 @LastName varchar(50)
)
returns varchar(101)
As
Begin return (Select @FirstName +' '+ @LastName);
end

--Calling the above created function
Select dbo.fnGetEmpFullName(FirstName,LastName)as Name, Salary from Employee 

<--Inline Table-Valued Function
<--User defined inline table-valued function returns a table variable
<-- as a result of actions perform by function. The value of table
<-- variable should be derived from a single SELECT statement.
-->
--Create function to get employees
Create function fnGetEmployee()
returns Table
As
return (Select*from Employee)

--Now call the above created function
Select * from fnGetEmployee()

<--Multi-Statement Table-Valued Function
<--User defined multi-statement table-valued function returns a table
<-- variable as a result of actions perform by function. In this a table
<-- variable must be explicitly declared and defined whose value can be
<-- derived from a multiple sql statements.

--Create function for EmpID,FirstName and Salary of Employee
Create function fnGetMulEmployee2()
returns @Emp Table
(
EmpID int,
FirstName varchar(50),
Salary int
)
As
begin

Insert into @Emp Select e.EmpID, e.FirstName, e.Salary from Employee e 
return
end

Create function fnGetMulEmployeeIU()
returns @Emp Table
(
EmpID int,
FirstName varchar(50),
Salary int
)
As
begin

Insert into @Emp Select e.EmpID, e.FirstName, e.Salary from Employee e 
update @Emp set Salary=25000 where EmpID=1;
return
end
select*from employee
