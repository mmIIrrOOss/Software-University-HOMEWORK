--Create Functions (Scalar) 
CREATE FUNCTION udf_ProjectDurationWeeks (@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
    DECLARE @projectWeeks INT;
    IF(@EndDate IS NULL)
    BEGIN
        SET @EndDate = GETDATE()
    END
    SET @projectWeeks = DATEDIFF(WEEK, @StartDate, @EndDate)
    RETURN @projectWeeks;
END

--Create Functions (Table-Valued Function) 
CREATE FUNCTION udf_AverageSalaryByDepartment()
RETURNS TABLE AS
RETURN 
(
	SELECT d.[Name] AS Department, AVG(e.Salary) AS AverageSalary 
	FROM Departments AS d 
	JOIN Employees AS e ON d.DepartmentID = e.DepartmentID
	GROUP BY d.DepartmentID, d.[Name]
)

--Create Functions (Multi-statement TVF) 
CREATE FUNCTION udf_EmployeeListByDepartment(@DepName nvarchar(20))
RETURNS @result TABLE(
    FirstName nvarchar(50) NOT NULL,
    LastName nvarchar(50) NOT NULL,
    DepartmentName nvarchar(20) NOT NULL) AS
BEGIN
    WITH Employees_CTE (FirstName, LastName, DepartmentName)
    AS(
        SELECT e.FirstName, e.LastName, d.[Name]
        FROM Employees AS e 
        LEFT JOIN Departments AS d ON d.DepartmentID = e.DepartmentID)

    INSERT INTO @result SELECT FirstName, LastName, DepartmentName 
      FROM Employees_CTE WHERE DepartmentName = @DepName
    RETURN
END

--Functions are called using schemaName.functionName
SELECT [ProjectID],
       [StartDate],
       [EndDate],
       dbo.udf_ProjectDurationWeeks([StartDate],[EndDate])
    AS ProjectWeeks
  FROM [SoftUni].[dbo].[Projects]

--Creating Stored Procedures
USE SoftUni
GO

CREATE PROC dbo.usp_SelectEmployeesBySeniority 
AS
  SELECT * 
  FROM Employees
  WHERE DATEDIFF(Year, HireDate, GETDATE()) > 19
GO

--Altering Stored Procedures
USE SoftUni
GO
ALTER PROC usp_SelectEmployeesBySeniority
AS
  SELECT FirstName, LastName, HireDate, 
    DATEDIFF(Year, HireDate, GETDATE()) as Years
  FROM Employees
  WHERE DATEDIFF(Year, HireDate, GETDATE()) > 19
  ORDER BY HireDate
GO


--Parameterized Stored Procedures - Example
CREATE PROC usp_SelectEmployeesBySeniority	(@minYearsAtWork int = 5)
AS
  SELECT FirstName, LastName, HireDate,
         DATEDIFF(Year, HireDate, GETDATE()) as Years
    FROM Employees
   WHERE DATEDIFF(Year, HireDate, GETDATE()) > @minYearsAtWork
   ORDER BY HireDate
GO

EXEC usp_SelectEmployeesBySeniority 10

--Passing values by parameter name
EXEC usp_AddCustomer 
  @customerID = 'ALFKI',
  @companyName = 'Alfreds Futterkiste',
  @address = 'Obere Str. 57',
  @city = 'Berlin',
  @phone = '030-0074321' 

  --Passing values by position
EXEC usp_AddCustomer 'ALFKI2', 'Alfreds Futterkiste', 'Obere Str. 57', 'Berlin', '030-0074321'

--Returning Values Using OUTPUT Parameters
CREATE PROCEDURE dbo.usp_AddNumbers
   @firstNumber SMALLINT,
   @secondNumber SMALLINT,
   @result INT OUTPUT
AS
   SET @result = @firstNumber + @secondNumber
GO

DECLARE @answer smallint
EXECUTE usp_AddNumbers 5, 6, @answer OUTPUT
SELECT 'The result is: ', @answer

-- The result is: 11

--Returning Multiple Results
CREATE OR ALTER PROC usp_MultipleResults
AS
SELECT FirstName, LastName FROM Employees
SELECT FirstName, LastName, d.[Name] AS Department 
FROM Employees AS e 
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID;
GO

EXEC usp_MultipleResults



--Solution: Employees with Three Projects (1)

CREATE PROCEDURE udp_AssignProject (@EmployeeID INT, @ProjectID INT)
AS
BEGIN
DECLARE @maxEmployeeProjectsCount INT = 3
DECLARE @employeeProjectsCount INT
SET @employeeProjectsCount = 
(SELECT COUNT(*) 
   FROM [dbo].[EmployeesProjects] AS ep
   WHERE ep.EmployeeId = @EmployeeID)
   --INSERT NEW DATA
   IF(@employeeProjectsCount >= @maxEmployeeProjectsCount)
BEGIN
   THROW 50001, 'The employee has too many projects!', 1;
END

INSERT INTO [dbo].[EmployeesProjects]  (EmployeeID, ProjectID)VALUES (@EmployeeID, @ProjectID)
END

--



