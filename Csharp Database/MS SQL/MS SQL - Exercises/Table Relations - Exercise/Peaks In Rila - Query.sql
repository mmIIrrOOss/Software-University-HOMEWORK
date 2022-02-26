USE [Geography]

SELECT MountainRange,PeakName,Elevation FROM Peaks 
	JOIN Mountains ON Peaks.MountainId = MountainId
	WHERE MountainRange = 'Rila'
	ORDER BY Elevation DESC

SELECT * FROM Mountains 