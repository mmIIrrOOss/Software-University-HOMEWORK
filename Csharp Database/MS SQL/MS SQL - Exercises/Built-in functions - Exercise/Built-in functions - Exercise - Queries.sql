USE SoftUni

SELECT FirstName
	FROM Employees e
	WHERE e.FirstName LIKE 'SA%'

SELECT FirstName,LastName
	FROM Employees e
	WHERE e.LastName LIKE '%ei%'

SELECT FirstName
	FROM Employees e
	WHERE e.DepartmentId IN (3,10) AND DATEPART(YEAR,e.HireDate)
								BETWEEN 1995 AND 2005

SELECT FirstName, LastName 
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

SELECT [Name] FROM Towns 
	WHERE LEN([Name]) = 5 OR LEN([Name]) = 6
	ORDER BY [Name] ASC

SELECT [Name] FROM Towns 
	WHERE [Name] LIKE '[MKBE]%'
	ORDER BY [Name] ASC

SELECT [Name] FROM Towns 
	WHERE [Name] NOT LIKE '[RBD]%'
	ORDER BY [Name] ASC


SELECT EmployeeID,FirstName,LastName,Salary,
		DENSE_RANK() 
		OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	FROM Employees 
	WHERE Salary BETWEEN 10000 AND 50000
	ORDER BY Salary DESC
		

CREATE VIEW V_EmployeesHiredAfter2000 AS
	SELECT FirstName, LastName 
	FROM Employees WHERE DATEPART(YEAR, HireDate) > 2000

SELECT * FROM V_EmployeesHiredAfter2000 veha

SELECT e.FirstName,e.LastName FROM Employees e
	WHERE LEN([e].[LastName]) = 5


SELECT  * FROM (SELECT EmployeeID,FirstName,LastName,Salary,
		DENSE_RANK() 
		OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
		FROM Employees 
		WHERE Salary BETWEEN 10000 AND 50000) AS [Rank]
WHERE [Rank] = 2
ORDER BY Salary DESC

USE [Geography]

SELECT CountryName,IsoCode  FROM Countries
	WHERE CountryName LIKE '%a%a%a%'
	ORDER BY IsoCode ASC

SELECT P.PeakName,r.RiverName,
			LOWER
				(CONCAT(P.PeakName,
						SUBSTRING(r.RiverName,2,LEN(R.RiverName)-1))) AS [Mix]
	FROM Peaks p,Rivers r
	WHERE RIGHT(p.PeakName, 1) = LEFT(r.RiverName,1) 
	ORDER BY [Mix]


USE Diablo

SELECT TOP(50) [Name],FORMAT([Start],'yyyy-MM-dd') AS [Start]
	FROM Games
 	WHERE DATEPART(YEAR,[Start])IN (2011,2012)
	ORDER BY [Start], [Name]

SELECT [Name],
	CASE 
    	WHEN DATEPART(HOUR,[Start]) BETWEEN 0 AND 11 THEN 'Morning'
    	WHEN DATEPART(HOUR,[Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
    	ELSE'Evening'
    END AS [Part of the Day],
	CASE 
    	WHEN g.Duration<=3 THEN 'Extra short'
    	WHEN g.Duration BETWEEN 4 AND 6 THEN 'Short'
    	WHEN g.Duration > 6 THEN 'Long'
		ELSE 'Extra long'
    END AS [Duration]
FROM Games g
ORDER BY [g].[Name],Duration,[Part of the Day]

USE [Diablo]

SELECT Username,IpAddress FROM  [Users]
	WHERE IpAddress LIKE '___.1_%._%.___'
	ORDER BY Username