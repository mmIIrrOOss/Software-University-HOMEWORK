USE SoftUni

/*CONCATENATION*/

SELECT FirstName + ' '+ LastName AS [FullName]
	FROM Employees 

SELECT CONCAT(FirstName,' ',LastName)
	AS [FullName]
	FROM Employees e

SELECT CONCAT_WS(' '.FirstName,LastName)
	AS [FullName]
	FROM Employees

/*SUBSTRING*/

SELECT * FROM Employees e

SELECT FirstName, LastName, JobTitle,
	SUBSTRING(JobTitle,1,200) + '...' AS Summary
	FROM Employees

/*REPLACE*/

SELECT REPLACE(LastName,'ov','*****')
	AS LastName
	FROM Employees e

/*TRIM*/
SELECT LTRIM('        Ivan')

SELECT RTRIM('Ivan          ')

/*LENGTH*/
SELECT LEN('Miroslav')

/*DATALENGTH*/
SELECT DATALENGTH('Miroslav')

/*LEFT & RIGHT*/
SELECT Id, e.FirstName,
	LEFT(FirstName, 3) AS Shortened
	FROM Employees e


SELECT Id, FirstName, LastName,
		DATEDIFF(YEAR, e.HireDate, '2017/01/25')
	AS [Years In Service]
	FROM Employees e

SELECT DATENAME(weekday, '2017/01/27')
SELECT GETDATE()

SELECT ProjectID, [Name],
		ISNULL(CAST(EndDate AS varchar), 'Not Finished') AS IsFinished
	FROM Projects

SELECT ID, FirstName, LastName
	FROM Employees
		ORDER BY ID
			OFFSET 10 ROWS
		FETCH NEXT 5 ROWS ONLY

SELECT * FROM Employees e


SELECT Id, MiddleName
	FROM Employees e
	WHERE MiddleName LIKE '%max!%' ESCAPE '!'