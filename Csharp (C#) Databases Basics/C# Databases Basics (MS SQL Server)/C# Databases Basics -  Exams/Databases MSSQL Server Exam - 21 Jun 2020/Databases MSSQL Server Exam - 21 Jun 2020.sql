CREATE DATABASE TripService
USE TripService


--Section 1. DDL 

--01.CREATE TABLES
CREATE TABLE Cities
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(20) NOT NULL,
	CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(30) NOT NULL,
	CityId INT REFERENCES Cities(Id) NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(18,2)
)

CREATE TABLE Rooms
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Price DECIMAL(18,2) NOT NULL,
	Type NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT REFERENCES Hotels(Id) NOT NULL,
)

CREATE TABLE Trips
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	RoomId INT REFERENCES Rooms(Id) NOT NULL,
	BookDate DATE NOT NULL,
	ArrivalDate DATE NOT NULL,
	ReturnDate DATE NOT NULL,
	CancelDate DATE,
	CHECK(BookDate < ArrivalDate),
	CHECK(ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT REFERENCES Cities(Id) NOT NULL,
	BirthDate DATE NOT NULL,
	Email VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE AccountsTrips
(
	AccountId INT REFERENCES Accounts(Id) NOT NULL,
	TripId INT  REFERENCES Trips(Id) NOT NULL,
	Luggage INT CHECK(Luggage >= 0) NOT NULL,
	CONSTRAINT PK_Accounts_Trips PRIMARY KEY (AccountId,TripId)
)

--Section 2. DML
--02.Insert

INSERT INTO Accounts(FirstName,MiddleName,LastName,CityId,BirthDate,Email) VALUES
('John','Smith','Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
('Gosho',NULL,'Petrov', 11,	'1978-05-16', 'g_petrov@gmail.com'),
('Ivan','Petrovich','Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'),
('Friedrich','Wilhelm','Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips(RoomId,BookDate,ArrivalDate,ReturnDate,CancelDate) VALUES
(101, '2015-04-12',	'2015-04-14', '2015-04-20', '2015-02-02	'),
(102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29	'),
(103, '2013-07-17', '2013-07-23', '2013-07-24', NULL),
(104, '2012-03-17',	'2012-03-31', '2012-04-01', '2012-01-10	'),
(109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)

--03.Update

UPDATE Rooms
	SET Price *= 1.14
 WHERE HotelId IN (5,7,9)

 --04.Delete
 DELETE FROM AccountsTrips
	WHERE AccountId = 47

--Section 3.Querying 

--05. EEE-Mails

SELECT a.FirstName,a.LastName,FORMAT(a.BirthDate,'MM-dd-yyyy'),c.Name,a.Email
	FROM Accounts AS a
	JOIN Cities AS c ON c.Id = a.CityId
	WHERE Email LIKE 'e%'
ORDER BY c.Name

--06.City Statistics

SELECT c.Name, COUNT(h.CityId)
	FROM Cities AS c
	JOIN Hotels AS h ON h.CityId = c.Id
 GROUP BY c.Name
 ORDER BY COUNT(h.CityId) DESC,c.Name

 --07.Longest and Shortest Trips

SELECT a.Id,CONCAT(a.FirstName,' ',a.LastName) AS FullName,MAX(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate)) AS LongestTrip,MIN(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate)) AS ShortestTrip
	FROM Accounts AS a
	JOIN AccountsTrips AS act ON act.AccountId = a.Id
	JOIN Trips AS t ON t.Id = act.TripId
	WHERE MiddleName IS NULL AND t.CancelDate IS NULL
GROUP BY a.Id,CONCAT(a.FirstName,' ',a.LastName)
ORDER BY LongestTrip DESC,ShortestTrip


--08.Metropolis

SELECT TOP(10) c.Id,c.Name,c.CountryCode, COUNT(a.Id) AS Accounts
	FROM Accounts AS a
	JOIN Cities AS c ON c.Id = a.CityId
 GROUP BY c.Id,c.Name,c.CountryCode
 ORDER BY Accounts DESC

--09.Romantic Getaways

SELECT a.Id,a.Email,c.Name AS City,COUNT(t.Id) AS Trips
	FROM Accounts AS a
	JOIN AccountsTrips AS tr ON tr.AccountId = a.Id
	JOIN Trips AS t ON t.Id = tr.TripId
	JOIN Rooms AS r ON r.Id = t.RoomId
	JOIN Hotels AS h ON h.Id = r.HotelId
	JOIN Cities AS c ON c.Id = A.CityId
	WHERE h.CityId = a.CityId
	GROUP BY a.Id,a.Email,c.Name
ORDER BY Trips DESC,a.Id

--10. GDPR Violation

SELECT  t.Id,
		CONCAT(a.FirstName,' ',ISNULL(a.MiddleName + ' ',''),a.LastName) AS FullName,
		accountCity.Name AS [From],
		hotelCity.Name AS [To],
		CASE
			WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
		ELSE
			CONCAT(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate),' days')		
		END
	FROM Trips as t
	JOIN AccountsTrips AS at ON at.TripId = t.Id
	JOIN Accounts AS a ON a.Id = at.AccountId
	JOIN Cities AS accountCity ON accountCity.Id = a.CityId
	JOIN Rooms AS r ON r.Id = t.RoomId
	JOIN Hotels AS h ON h.Id = r.HotelId
	JOIN Cities AS hotelCity ON hotelCity.Id = h.CityId
ORDER BY FullName,t.Id

--Section 4. Programmability 
--11.Available Room

CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(MAX)
AS
BEGIN 
	DECLARE @RoomId INT = 
	(
		SELECT TOP(1) r.Id 
			FROM Rooms AS r
			JOIN Trips AS t ON t.RoomId = r.Id
			WHERE r.HotelId = @HotelId 
				  AND r.Beds > @People
				  AND ((@Date >= t.ArrivalDate AND @Date <= t.ReturnDate AND t.CancelDate IS NOT NULL) 
				  OR (@Date < t.ArrivalDate OR @Date > t.ReturnDate))
			ORDER BY r.Price DESC

	)

	IF(SELECT COUNT(Id) FROM Rooms WHERE Id = @RoomId) < 1
		RETURN 'No rooms available'

	DECLARE @HotelBaseRate DECIMAL(15,2) = (SELECT BaseRate FROM Hotels WHERE Id = @HotelId)
	DECLARE @RoomPrice DECIMAL(15,2) = (SELECT Price FROM Rooms WHERE Id = @RoomId)
	DECLARE @RoomType NVARCHAR(MAX) = (SELECT [Type] FROM Rooms WHERE Id = @RoomId)
	DECLARE @RoomBeds INT = (SELECT Beds FROM Rooms WHERE Id = @RoomId)
	DECLARE @TotalPrice DECIMAL(15,2) = (@HotelBaseRate + @RoomPrice) * @People

	RETURN CONCAT('Room ',@RoomId,': ',@RoomType,' (',@RoomBeds,' beds) - $',@TotalPrice)
END

--12. Switch Room

CREATE PROC usp_SwitchRoom @TripId INT , @TargetRoomId INT
AS 
BEGIN
	DECLARE @HotelTargetId INT  = (SELECT HotelId FROM Rooms WHERE Id = @TargetRoomId)
	DECLARE @TripRoomId INT = (SELECT RoomId FROM Trips WHERE Id = @TripId)
	DECLARE @TripHotelId INT = (SELECT HotelId FROM Rooms WHERE Id = @TripRoomId)

	IF(@HotelTargetId <> @TripHotelId)
	BEGIN
		RAISERROR('Target room is in another hotel!',16,1)
		RETURN
	END

	DECLARE @TripsAcc INT = (SELECT COUNT(TripId) FROM AccountsTrips WHERE TripId = @TripId)
	IF(SELECT Beds FROM Rooms WHERE Id = @TargetRoomId) < @TripsAcc
	BEGIN
		RAISERROR('Not enough beds in target room!',16,1)
		RETURN
	END

	UPDATE Trips
		SET RoomId = @TargetRoomId
		WHERE Id = @TripId

END 