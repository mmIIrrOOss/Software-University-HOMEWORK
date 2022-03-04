CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL)

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	AddressText NVARCHAR(100) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL)



CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(30),
	LastName NVARCHAR(30) NOT NULL,
	JobTitle NVARCHAR(60) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
	HireDate DATE NOT NULL,
	Salary DECIMAL(7,2) NOT NULL,
	AdressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

INSERT INTO Towns([Name])
	VALUES 
		('Sofia'),
		('Plovdiv'),
		('Varna'),
		('Burgas')

SELECT * FROM Towns

INSERT INTO Departments([Name])
	VALUES 
	('Engineering'),
	('Sales'),
	('Marketing'),
	('Software Development'),
	('Quality Assurance')

SELECT * FROM Departments 

SELECT * FROM Employees 

INSERT INTO Employees(FirstName,MiddleName,LastName,JobTitle,DepartmentId,HireDate
,Salary)
	VALUES 
		('Ivan','Ivanov','Ivanov', '.NET Developer',(SELECT TOP 1 Id FROM Departments WHERE [Name] = 'Software Development'),'02/01/2013',3500.00),
		('Petar','Petrov','Petrov', 'Senior Engineer',(SELECT TOP 1 Id FROM Departments WHERE [Name] = 'Engineering'),'03/02/2004',4000.00),
		('Maria','Petrova','Ivanova', 'Intern',(SELECT TOP 1 Id FROM Departments WHERE [Name] = 'Quality Assurance'),'08/28/2016',525.25),
		('Georgi','Teziev',' Ivanov', 'CEO',(SELECT TOP 1 Id FROM Departments WHERE [Name] = 'Sales'),'12/09/2007',3000.00),
		('Peter',' Pan','Pan','Intern',(SELECT TOP 1 Id FROM Departments WHERE [Name] = 'Marketing'),'08/28/2016',599.88)

SELECT * FROM Towns 

SELECT * FROM Departments 

SELECT * FROM Employees 


SELECT * FROM Towns 
ORDER BY [Name] ASC


SELECT * FROM Departments 
ORDER BY [Name] ASC

SELECT * FROM Employees e 
ORDER BY e.Salary DESC

SELECT [Name] FROM Towns 
ORDER BY [Name] ASC

SELECT [Name] FROM Departments 
ORDER BY [Name] ASC

SELECT FirstName,MiddleName,LastName,JobTitle,Salary FROM Employees e 
ORDER BY e.Salary DESC

UPDATE Employees
SET Salary += Salary * 0.1

SELECT Salary FROM Employees e
