USE SoftUni
--CREATE NONCLUSTERED INDEX
CREATE NONCLUSTERED INDEX IX_Employees_FirstName_LastName
ON Employees(FirstName, LastName)

SELECT * FROM IX_Employees_FirstName_LastName

--GROUPING
SELECT e.DepartmentId 
    FROM Employees AS e
GROUP BY e.DepartmentId

--DISTINCT
SELECT DISTINCT e.DepartmentID
	FROM Employees AS e

--Departments Total Salaries
SELECT e.DepartmentID, 
  SUM(e.Salary) AS TotalSalary
	FROM Employees AS e
	GROUP BY e.DepartmentID
	ORDER BY e.DepartmentID


--Aggregate Functions
SELECT e.DepartmentID, 
		MIN(e.Salary) AS MinSalary
	FROM Employees AS e
	GROUP BY e.DepartmentID

SELECT e.DepartmentID, 
         COUNT(e.Salary) AS SalaryCount
    FROM Employees AS e
GROUP BY e.DepartmentID

SELECT e.DepartmentID,
         SUM(e.Salary) AS TotalSalary
    FROM Employees AS e
GROUP BY e.DepartmentID

SELECT e.DepartmentID,         
		MAX(e.Salary) AS MaxSalary
    FROM Employees AS e
GROUP BY e.DepartmentID

SELECT e.DepartmentID, 
         AVG(e.Salary) AS AvgSalary
    FROM Employees AS e
GROUP BY e.DepartmentID

--HAVING 
SELECT e.DepartmentID,SUM(e.Salary) AS TotalSalary
    FROM Employees AS e
GROUP BY e.DepartmentID
HAVING SUM(e.Salary) >= 15000




