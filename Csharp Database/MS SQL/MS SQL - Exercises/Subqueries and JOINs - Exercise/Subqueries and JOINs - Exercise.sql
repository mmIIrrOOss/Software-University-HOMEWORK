USE SoftUni2

--01.Employee Address
SELECT e.EmployeeID,e.JobTitle,e.AddressID,a.AdDressID,a.AddressText
	FROM Employees e
		INNER JOIN Addresses a ON e.AddressID = a.AddressID
	ORDER BY e.AddressID

--02.Addresses with Towns
SELECT  e.FirstName,e.LastName,T.[Name] AS Town,a.AddressText
	FROM Employees e
		INNER JOIN Addresses a ON e.AddressID = a.AddressID
		INNER JOIN Towns t ON a.TownID = t.TownID



SELECT * FROM Employees e
SELECT * FROM Towns t

--03.Sales Employee
SELECT e.EmployeeID, e.FirstName,e.LastName,d.Name AS DepartmentName
	FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE d.[Name]='Sales'
	ORDER BY e.EmployeeID 

--04.Employee Departments
SELECT TOP(5) e.EmployeeID,e.FirstName,e.Salary,d.[Name]
	FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE e.Salary>15000
	ORDER BY d.DepartmentID

--05.Employees Without Project
SELECT TOP(3) e.EmployeeID,e.FirstName
	FROM Employees e
	LEFT OUTER JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID 
	WHERE ep.ProjectID IS NULL
	ORDER BY e.EmployeeID

--06.Employees Hired After
SELECT e.FirstName,e.LastName,e.HireDate,d.[Name] AS [DeptName]
	FROM Employees e
	INNER JOIN Departments d  
		ON e.DepartmentID = d.DepartmentID
	WHERE e.HireDate > '1999-01-01' AND
		d.[Name]='Finance' OR d.[Name]='Sales'

--07.Employees with Project
SELECT TOP (5) e.EmployeeID,e.FirstName,p.[Name]
	FROM Employees e
	INNER JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
	INNER JOIN Projects p ON ep.ProjectID = p.ProjectID
	WHERE p.StartDate> '08.13.2002' AND p.EndDate IS NULL
	ORDER BY e.EmployeeID

--08.Employee 24
SELECT e.EmployeeID,e.FirstName,
		CASE 
			WHEN DATEPART(YEAR, P.StartDate)>=2005 THEN NULL
			ELSE P.[Name]
		END AS [ProjectName]
	FROM Employees e
		INNER JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
		INNER JOIN Projects p ON ep.ProjectID = p.ProjectID
	WHERE e.EmployeeID = 24

--09.Employee Manager
SELECT  e.EmployeeID,e.FirstName,e.ManagerID
	FROM Employees e
	JOIN Employees e1 ON e.ManagerID = e1.EmployeeID
	WHERE e.ManagerID = 3 OR e.ManagerID = 7
	ORDER BY e.EmployeeID ASC

--10.Employee Summary
SELECT TOP 50 
  e.EmployeeID, 
  e.FirstName + ' ' + e.LastName AS EmployeeName, 
  m.FirstName + ' ' + m. LastName AS ManagerName,
  d.Name AS DepartmentName
FROM Employees AS e
  LEFT JOIN Employees AS m ON m.EmployeeID = e.ManagerID
  LEFT JOIN Departments AS d ON d.DepartmentID =       e.DepartmentID
  ORDER BY e.EmployeeID ASC

--11.Min Average Salary
SELECT   MIN(a.AverageSalary) AS MinAverageSalary
  FROM 
  (
     SELECT e.DepartmentID, 
            AVG(e.Salary) AS AverageSalary
       FROM Employees AS e
   GROUP BY e.DepartmentID
  ) AS a

--12.Highest Peaks in Bulgaria
USE [Geography]

SELECT c.CountryCode,m.MountainRange,p.PeakName,p.Elevation FROM Countries AS c
	INNER JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	INNER JOIN Mountains AS m ON mc.MountainID = m.Id
	INNER JOIN Peaks AS p ON p.MountainId = m.Id
	WHERE c.CountryCode = 'BG' AND p.Elevation >= 2835
	ORDER BY p.Elevation DESC

--13.Count Mountain Ranges
SELECT CountryCode, COUNT(MountainId) AS [MountainRanges] 
	FROM MountainsCountries
	WHERE CountryCode IN ('US','RU','BG')
	GROUP BY CountryCode

--14.Countries with Rivers
SELECT TOP (5) c.CountryName,
               r.RiverName
FROM Countries AS c
     LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
     LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
     JOIN Continents AS cnt ON c.ContinentCode = cnt.ContinentCode
WHERE cnt.ContinentName = 'Africa'
ORDER BY c.CountryName; 

--Problem 15.	*Continents and Currencies

SELECT ranked.ContinentCode,
       ranked.CurrencyCode,
       ranked.CurrencyUsage
FROM
(
    SELECT gbc.ContinentCode,
           gbc.CurrencyCode,
           gbc.CurrencyUsage,
           DENSE_RANK() OVER(PARTITION BY gbc.ContinentCode ORDER BY gbc.CurrencyUsage DESC) AS UsageRank
    FROM
    (
        SELECT ContinentCode,
               CurrencyCode,
               COUNT(CurrencyCode) AS CurrencyUsage
        FROM Countries
        GROUP BY ContinentCode,
                 CurrencyCode
        HAVING COUNT(CurrencyCode) > 1
    ) AS gbc
) AS ranked
WHERE ranked.UsageRank = 1
ORDER BY ranked.ContinentCode; 
 
--16.	Countries without any Mountains
SELECT COUNT(c.CountryCode) AS CountryCode
FROM Countries AS c
     LEFT OUTER JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
WHERE mc.CountryCode IS NULL; 
 

--17.	Highest Peak and Longest River by Country

SELECT TOP (5) peaks.CountryName,
               peaks.Elevation AS HighestPeakElevation,
               rivers.Length AS LongestRiverLength
FROM
(
    SELECT c.CountryName,
           c.CountryCode,
           DENSE_RANK() OVER(PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS DescendingElevationRank,
           p.Elevation
    FROM Countries AS c
         FULL OUTER JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
         FULL OUTER JOIN Mountains AS m ON mc.MountainId = m.Id
         FULL OUTER JOIN Peaks AS p ON m.Id = p.MountainId
) AS peaks
FULL OUTER JOIN
(
    SELECT c.CountryName,
           c.CountryCode,
           DENSE_RANK() OVER(PARTITION BY c.CountryCode ORDER BY r.Length DESC) AS DescendingRiversLenghRank,
           r.Length
    FROM Countries AS c
         FULL OUTER JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
         FULL OUTER JOIN Rivers AS r ON cr.RiverId = r.Id
) AS rivers ON peaks.CountryCode = rivers.CountryCode
WHERE peaks.DescendingElevationRank = 1
      AND rivers.DescendingRiversLenghRank = 1
      AND (peaks.Elevation IS NOT NULL
           OR rivers.Length IS NOT NULL)
ORDER BY HighestPeakElevation DESC,
         LongestRiverLength DESC,
         CountryName; 
		  

-- 18.	* Highest Peak Name and Elevation by Country
SELECT TOP (5) jt.CountryName AS Country,
               ISNULL(jt.PeakName, '(no highest peak)') AS HighestPeakName,
               ISNULL(jt.Elevation, 0) AS HighestPeakElevation,
               ISNULL(jt.MountainRange, '(no mountain)') AS Mountain
FROM
(
    SELECT c.CountryName,
           DENSE_RANK() OVER(PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS PeakRank,
           p.PeakName,
           p.Elevation,
           m.MountainRange
    FROM Countries AS c
         LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
         LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
         LEFT JOIN Peaks AS p ON m.Id = p.MountainId
) AS jt
WHERE jt.PeakRank = 1
ORDER BY jt.CountryName,
         jt.PeakName;

-- CASE solution

SELECT TOP (5) jt.CountryName AS Country,
               CASE
                   WHEN jt.PeakName IS NULL
                   THEN '(no highest peak)'
                   ELSE jt.PeakName
               END AS HighestPeakName,
               CASE
                   WHEN jt.Elevation IS NULL
                   THEN 0
                   ELSE jt.Elevation
               END AS HighestPeakElevation,
               CASE
                   WHEN jt.MountainRange IS NULL
                   THEN '(no mountain)'
                   ELSE jt.MountainRange
               END AS Mountain
FROM
(
    SELECT c.CountryName,
           DENSE_RANK() OVER(PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS PeakRank,
           p.PeakName,
           p.Elevation,
           m.MountainRange
    FROM Countries AS c
         LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
         LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
         LEFT JOIN Peaks AS p ON m.Id = p.MountainId
) AS jt
WHERE jt.PeakRank = 1
ORDER BY jt.CountryName,
         jt.PeakName;