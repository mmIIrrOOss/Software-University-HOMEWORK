USE SoftUni2

--01.Employees with Salary Above 35000
GO
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT FirstName,LastName 
	FROM Employees
	WHERE Salary>35000
END
GO

GO
EXEC usp_GetEmployeesSalaryAbove35000
GO

--02.Employees with Salary Above Number
GO
CREATE PROC usp_GetEmployeesSalaryAboveNumber(@minSalary DECIMAL(18,4))
AS
BEGIN 
	SELECT FirstName,LastName 
	FROM Employees
	WHERE Salary>=@minSalary
END
GO

GO
EXEC usp_GetEmployeesSalaryAboveNumber 48100
GO

--03.Town Names Starting With
GO
CREATE PROC usp_GetTownsStartingWith(@searchedString NVARCHAR(50))
AS
BEGIN
     DECLARE @stringCount int = LEN(@searchedString)
SELECT [Name] FROM Towns
WHERE LEFT([Name],@stringCount) = @searchedString
END
GO

GO
EXEC usp_GetTownsStartingWith 'B'
GO

--04.Employees from Town
GO
CREATE PROC usp_GetEmployeesFromTown(@townName NVARCHAR(50))
AS
BEGIN
	SELECT e.FirstName,e.LastName FROM Employees AS e
	INNER JOIN Addresses AS a
	ON e.AddressID = a.AddressID
	INNER JOIN Towns AS t
	ON a.TownID = t.TownID 
	WHERE t.[Name] = @townName
END
GO

GO
EXEC usp_GetEmployeesFromTown 'Sofia'
GO

--05.Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4)) 
RETURNS VARCHAR(10) AS 
BEGIN 
	DECLARE @SalaryLevel VARCHAR(10)
	IF(@Salary < 30000)
	BEGIN 
	 SET @SalaryLevel = 'Low'
	END
	ELSE IF(@Salary >= 30000 AND @Salary <= 50000)
	BEGIN
	 SET @SalaryLevel = 'Average'
	END
	ELSE 
	BEGIN 
	 SET @SalaryLevel = 'High'
	END
RETURN @SalaryLevel
END

--06.Employees by Salary Level

CREATE PROC usp_EmployeesBySalaryLevel(@SalaryLevel VARCHAR(10))
AS SELECT FirstName,LastName 
     FROM Employees 
    WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel

--09.Define Function
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50)) 
RETURNS BIT
AS
BEGIN
DECLARE @currentIndex int = 1;

WHILE(@currentIndex <= LEN(@word))
	BEGIN

	DECLARE @currentLetter varchar(1) = SUBSTRING(@word, @currentIndex, 1);

	IF(CHARINDEX(@currentLetter, @setOfLetters)) = 0
	BEGIN
	RETURN 0;
	END

	SET @currentIndex += 1;
	END

RETURN 1;
END

--10.* Delete Employees and Departments
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS

DECLARE @empIDsToBeDeleted TABLE
(
Id int
)

INSERT INTO @empIDsToBeDeleted
SELECT e.EmployeeID
FROM Employees AS e
WHERE e.DepartmentID = @departmentId

ALTER TABLE Departments
ALTER COLUMN ManagerID int NULL

DELETE FROM EmployeesProjects
WHERE EmployeeID IN (SELECT Id FROM @empIDsToBeDeleted)

UPDATE Employees
SET ManagerID = NULL
WHERE ManagerID IN (SELECT Id FROM @empIDsToBeDeleted)

UPDATE Departments
SET ManagerID = NULL
WHERE ManagerID IN (SELECT Id FROM @empIDsToBeDeleted)

DELETE FROM Employees
WHERE EmployeeID IN (SELECT Id FROM @empIDsToBeDeleted)

DELETE FROM Departments
WHERE DepartmentID = @departmentId 

SELECT COUNT(*) AS [Employees Count] FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE e.DepartmentID = @departmentId

--Queries for Bank Database
USE [Bank]

--11.Find Full Name

CREATE PROC usp_GetHoldersFullName AS
SELECT FirstName + ' ' + LastName AS [Full Name] 
  FROM AccountHolders

EXEC usp_GetHoldersFullName

--12.People with Balance Higher Than
CREATE PROC usp_GetHoldersWithBalanceHigherThan(@number DECIMAL(13,2)) AS 
SELECT FirstName,LastName
  FROM AccountHolders AS ah
  JOIN Accounts AS a ON ah.Id=a.AccountHolderId
 GROUP BY FirstName,LastName
 HAVING SUM (a.Balance) > @number

 EXEC dbo.usp_GetHoldersWithBalanceHigherThan 200

--13.Future Value Function

CREATE FUNCTION ufn_CalculateFutureValue (@Sum MONEY, @Rate FLOAT , @Years INT)
RETURNS MONEY AS
BEGIN
 RETURN @Sum * POWER(1+@Rate,@Years)
END

--14.Calculating Interest
CREATE PROC usp_CalculateFutureValueForAccount (@AccountId INT, @InterestRate FLOAT) AS
SELECT a.Id AS [Account Id],
	   ah.FirstName AS [First Name],
	   ah.LastName AS [Last Name],
	   a.Balance,
	   dbo.ufn_CalculateFutureValue(Balance, @InterestRate, 5) AS [Balance in 5 years]
  FROM AccountHolders AS ah
  JOIN Accounts AS a ON ah.Id = a.Id
 WHERE a.Id = @AccountId


--15.*Scalar Function: Cash in User Games Odd Rows

CREATE FUNCTION ufn_CashInUsersGames(@gameName varchar(max))
RETURNS @returnedTable TABLE
(
SumCash money
)
AS
BEGIN
	DECLARE @result money

	SET @result = 
	(SELECT SUM(ug.Cash) AS Cash
	FROM
		(SELECT Cash, GameId, ROW_NUMBER() OVER (ORDER BY Cash DESC) AS RowNumber
		FROM UsersGames
		WHERE GameId = (SELECT Id FROM Games WHERE Name = @gameName)
		) AS ug
	WHERE ug.RowNumber % 2 != 0
	)

	INSERT INTO @returnedTable SELECT @result
	RETURN
END





