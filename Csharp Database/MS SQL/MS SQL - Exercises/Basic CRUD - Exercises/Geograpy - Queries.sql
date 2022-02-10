USE [Geography]



SELECT PeakName FROM Peaks
	ORDER BY PeakName ASC

SELECT TOP(30) [Population],CountryName  FROM Countries
	WHERE ContinentCode = 'EU'
	ORDER BY [Population] DESC, CountryName ASC

SELECT CountryName,CountryCode,CurrencyCode,
		CASE
			WHEN CurrencyCode = 'EUR' THEN 'Euro'
			ELSE 'Not Euro'
		END AS [Currency]
	FROM Countries
	ORDER BY CountryName ASC
