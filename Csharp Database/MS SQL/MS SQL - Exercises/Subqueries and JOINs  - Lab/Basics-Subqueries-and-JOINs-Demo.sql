USE SoftUni

--IINER JOIN
SELECT * FROM Employees AS e
  INNER JOIN Departments AS d
  ON e.DepartmentID = d.DepartmentID

--LEFT OUTER JOIN
SELECT * FROM Employees AS e
  LEFT OUTER JOIN Departments AS d
  ON e.DepartmentId = e.DepartmentId

--RIGHT OUTER JOIN
SELECT * FROM Employees AS e
 RIGHT OUTER JOIN Departments AS d
 ON e.DepartmentId = d.id

 --FULL JOIN

 SELECT * FROM Employees AS e
  FULL JOIN Departments AS d
  ON e.DepartmentID = d.Id

--CARTESIAN PRODUCT
SELECT LastName, Name AS DepartmentName
FROM Employees, Departments

--CROSS JOIN
SELECT * FROM Employees AS e
 CROSS JOIN Departments AS d


 --01. Employee Address



 --02.Addresses with Towns
SELECT TOP 50 e.FirstName, e.LastName,
  t.Name as Town, a.AddressText
FROM Employees e
  JOIN Addresses a ON e.AdressId = a.AddressText
  JOIN Towns t ON a.TownID = t.ID
ORDER BY e.FirstName, e.LastName

--03.Solution: Sales Employees
SELECT e.EmployeeID, e.FirstName, e.LastName, 
  d.Name AS DepartmentName
FROM Employees e 
  INNER JOIN Departments d 
    ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID

--06. Employees Hired After
SELECT e.FirstName, e.LastName, e.HireDate,  d.Name as DeptName
FROM Employees e
  INNER JOIN Departments d
  ON (e.DepartmentId = d.DepartmentId
  AND e.HireDate > '1/1/1999'
  AND d.Name IN ('Sales', 'Finance'))
ORDER BY e.HireDate ASC


--10. Employees Summary
SELECT TOP 50 
  e.EmployeeID, 
  e.FirstName + ' ' + e.LastName AS EmployeeName, 
  m.FirstName + ' ' + m. LastName AS ManagerName,
  d.Name AS DepartmentName
FROM Employees AS e
  LEFT JOIN Employees AS m ON m.EmployeeID = e.ManagerID
  LEFT JOIN Departments AS d ON d.DepartmentID =       e.DepartmentID
  ORDER BY e.EmployeeID ASC

--SUBQUERY SYNTAX

SELECT FROM Employees AS e
 WHERE e.DepartmentID IN 
  (
   SELECT d.DepartmentID     FROM Deparments AS d
    WHERE d.Name = 'Finance'
  )

--Min Average Salary
SELECT   MIN(a.AverageSalary) AS MinAverageSalary
  FROM 
  (
     SELECT e.DepartmentID, 
            AVG(e.Salary) AS AverageSalary
       FROM Employees AS e
   GROUP BY e.DepartmentID
  ) AS a

--Common Table Expressions Syntax
WITH Employees_CTE   (FirstName, LastName, DepartmentName)
AS
(
  SELECT e.FirstName, e.LastName, d.Name
  FROM Employees AS e 
  LEFT JOIN Departments AS d ON 
    d.DepartmentID = e.DepartmentID
)

--Temporary Table Syntax
CREATE TABLE #Employees(
	Id INT PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50),
	Address VARCHAR(50)
)

SELECT * FROM #Employees


SELECT FirstName, LastName, DepartmentName 
  FROM Employees_CTE









