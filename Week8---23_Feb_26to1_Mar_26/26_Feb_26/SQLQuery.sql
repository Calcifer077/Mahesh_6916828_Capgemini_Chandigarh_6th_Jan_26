create database EmployeeDB;

use EmployeeDB;

set ANSI_NULLS ON
go

set QUOTED_IDENTIFIER ON

go

CREATE TABLE [dbo].[Adress](
	[AdressID] [int] IDENTITY(1,1) NOT NULL,
	[Street] [varchar](256) NULL,
	[City] [varchar](100) NULL,
	[State] [varchar](100) NULL,
	[PostalCode] [varchar](20) NULL
)

CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[AdressID] [int] NULL,
)

insert into Adress (Street, City, State, PostalCode)
values ('1234 Elm Street', 'Springfield', 'Illinois', 62704),
('5678 Oak Street', 'Decatur', 'Alabama', 35601),
('123 Patia', 'BBSR', 'India', 755019),
('123 Paita', 'BBSR', 'India', 755019);

insert into Employee (FirstName, LastName, Email, AdressID)
values ('John', 'Doe', 'johndoe@gmail.com', 1),
('John', 'Doe', 'johndoe@gmail.com', 2),
('Ramesh', 'Sharma', 'ramesh@gmail.com', 3),
('Ramesh', 'Verma', 'verma@gmail.com', 4);

select * from Adress;
select * from Employee;

create or alter procedure [dbo].[CreateEmployeeWithAddress]
@Firstname varchar(100),
@LastName varchar(100),
@Email varchar(100),
@Street varchar(255),
@City varchar(100),
@State varchar(100),
@PostalCode varchar(20)
as 
begin
declare @AdressId INT;
Insert into Adress (Street, City, State, PostalCode)
values (@Street, @City, @State, @PostalCode);
set @AdressId = SCOPE_IDENTITY();
Insert into Employee (FirstName, LastName, Email, AdressID)
values (@Firstname, @LastName, @Email, @AdressId);
end;

create or alter procedure [dbo].[GetAllEmployees]
as
begin
select e.EmployeeID, e.FirstName, e.Lastname, e.Email, a.Street, a.City, a.State, a.PostalCode
from Employee e
inner join Adress a on e.AdressID = a.AdressID
end;
-----------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[DeleteEmployee]
@EmployeeID INT
AS
BEGIN
DECLARE @AddressID INT

BEGIN TRANSACTION
SELECT @AddressID = AdressID from Employee where EmployeeID = @EmployeeID

DELETE FROM Employee WHERE EmployeeID = @EmployeeID

DELETE FROM Adress WHERE AdressID = @AddressID
COMMIT TRANSACTION

END

-----------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------
create or alter procedure [dbo].[UpdateEmployeeWithAdress]
@EmployeeID INT,
@FirstName varchar(100),
@LastName varchar(100),
@Email varchar(100),
@Street varchar(100),
@City varchar(100),
@State varchar(100),
@PostalCode varchar(20),
@AdressID int
as 
begin
update Adress
set Street = @Street, City = @City, State = @State, PostalCode = @PostalCode
where AdressID = @AdressID
update Employee
set FirstName = @FirstName, LastName = @LastName, Email = @Email, AdressID = @AdressID
where EmployeeID = @EmployeeID
end;

CREATE PROCEDURE [dbo].[GetEmployeeByID]
@EmployeeID INT

AS 
BEGIN

SELECT e.EmployeeID, e.FirstName, e.LastName, e.Email, a.Street, a.City, 
a.State, a.PostalCode
From Employee e
INNER JOIN
Adress a on e.AdressID = a.AdressID
WHERE e.EmployeeID = @EmployeeID
END


Execute dbo.GetEmployeeByID 1;
Execute dbo.GetAllEmployees;
Execute dbo.CreateEmployeeWithAddress 'Mahesh', 'Parth', 'ww@gmail.com ', 'CU', 'Mohali', 'Punjab', '140413';
Execute dbo.UpdateEmployeeWithAdress 5, 'Parth', 'Atal', 'ww@gmail.com', 'CU', 'Mohali', 'Punjab', '140413', 5; 
Execute dbo.DeleteEmployee 5;