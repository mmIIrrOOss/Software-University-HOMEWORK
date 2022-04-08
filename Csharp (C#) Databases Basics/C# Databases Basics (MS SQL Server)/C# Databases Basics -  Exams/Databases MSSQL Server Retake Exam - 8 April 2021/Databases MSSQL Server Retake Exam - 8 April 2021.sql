--CREATE DATABASE [Service]
--USE [Service]

--Section 1. DDL 
CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	Password VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	Birthdate DATETIME2,
	Age INT CHECK(Age >= 14 AND Age <= 110) NOT NULL,
	Email VARCHAR(50) NOT NULL,
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATETIME2,
	Age INT CHECK(Age >= 18 AND Age <= 110),
	DepartmentId INT REFERENCES Departments(Id) NOT NULL,
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT REFERENCES Departments(Id) NOT NULL,
)

CREATE TABLE [Status]
(
	Id INT PRIMARY KEY IDENTITY,
	[Label] VARCHAR(30) NOT NULL,
)

CREATE TABLE Reports
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT REFERENCES Categories(Id) NOT NULL,
	StatusId INT REFERENCES [Status](Id) NOT NULL,
	OpenDate DATETIME2 NOT NULL,
	CloseDate DATETIME2,
	[Description] VARCHAR(200) NOT NULL,
	UserId INT REFERENCES Users(Id) NOT NULL,
	EmployeeId INT REFERENCES Employees(Id),
)

--Section 2. DML 
--02.Insert

INSERT INTO Employees(FirstName,LastName,Birthdate,DepartmentId) VALUES
('Marlo', 'O''Malley', '1958-9-21',	1),
('Niki', 'Stanaghan', '1969-11-26',	4),
('Ayrton', 'Senna', '1960-03-21', 9),
('Ronnie', 'Peterson', '1944-02-14', 9),
('Giovanna', 'Amati', '1959-07-20',	5)

INSERT INTO Reports(CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)VALUES
(1,	1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
(6,	3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5,	2),
(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11',	1, 1)

--03.Update

UPDATE Reports
	SET CloseDate = GETDATE()
	WHERE CloseDate IS NULL

--04.Delete

DELETE Reports
	WHERE StatusId = 4


--Section 3. Querying 
--05.Unassigned Reports

SELECT [Description],FORMAT (OpenDate,'dd-MM-yyyy')
	FROM Reports
	WHERE EmployeeId IS NULL
	ORDER BY OpenDate,[Description]

--06.Reports & Categories
SELECT r.[Description], c.[Name]
	FROM Reports AS r
	JOIN Categories AS c ON c.Id = r.CategoryId
	ORDER BY r.[Description],c.[Name]

--07.Most Reported Category

SELECT TOP(5) c.[Name],COUNT(r.Id) AS ReportsNumber
	FROM Categories AS c
	LEFT JOIN Reports AS r ON r.CategoryId = c.Id
	GROUP BY c.[Name]
	ORDER BY ReportsNumber DESC,c.[Name]


--08.Birthday Report

SELECT u.Username,c.[Name]
	FROM Reports AS r
	JOIN Users AS u ON r.UserId = u.Id
	JOIN Categories AS c ON c.Id = r.CategoryId
	WHERE DAY(u.Birthdate) = DAY(r.OpenDate)
	ORDER BY u.Username,c.[Name]

--09.Users per Employee 

SELECT CONCAT(em.FirstName,' ',em.LastName) AS FullName,COUNT(r.UserId) AS UsersCount
	FROM Reports AS r
	RIGHT JOIN Employees AS em ON em.Id = r.EmployeeId
	LEFT JOIN Users AS u ON u.Id = r.UserId
	GROUP BY em.FirstName,em.LastName
	ORDER BY UsersCount DESC,FullName

--10.Full Info

SELECT 
	 ISNULL(e.FirstName +' ' + e.LastName,'None') AS Employee
	,ISNULL(d.[Name],'None') AS Department
	,ISNULL(c.[Name],'None') AS Category
	,ISNULL(r.[Description],'None') AS Description
	,ISNULL(FORMAT(r.OpenDate,'dd.MM.yyyy'),'None') AS OpenDate
	,ISNULL(s.[Label],'None') AS [Status]
	,ISNULL(u.[Name],'None') AS [User]
	FROM Reports AS r
	LEFT JOIN Employees AS e ON e.Id = r.EmployeeId
	LEFT JOIN Categories AS c ON c.Id = r.CategoryId
	LEFT JOIN Departments AS d ON d.Id = e.DepartmentId
	LEFT JOIN [Status] AS s ON s.Id = r.StatusId
	LEFT JOIN Users AS u ON u.Id = r.UserId
	ORDER BY e.FirstName DESC,e.LastName DESC,d.[Name],c.[Name],r.[Description],r.OpenDate,s.[Label],u.[Name]

--Section 4. Programmability
--11.Hours to Complete

CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS 
BEGIN
	IF (@StartDate IS NULL OR @EndDate IS NULL)
		RETURN 0

	RETURN DATEDIFF(HOUR,@StartDate,@EndDate)
END

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports

--12.Assign Employee

CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
	DECLARE @RepoDepId INT = (
								SELECT c.DepartmentId  
								FROM Reports AS r
								JOIN Categories AS c ON c.Id = r.CategoryId
								WHERE r.Id = @ReportId
						   )
	DECLARE @EmployeeDepId INT = (SELECT DepartmentId FROM Employees WHERE Id = @EmployeeId)

	IF @RepoDepId != @EmployeeDepId
		RAISERROR('Employee doesn''t belong to the appropriate department!',16,1)

	UPDATE Reports
		SET EmployeeId = @EmployeeId
		WHERE Id = @ReportId
END

EXEC usp_AssignEmployeeToReport 17,2
SELECT Id, CategoryId, EmployeeId
  FROM Reports
 WHERE Id = 2