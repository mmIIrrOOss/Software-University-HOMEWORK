

/*---------------Section 1. DDL 

01.Database Design
Submit all of yours create statements to the Judge system.
---------------------------------*/


CREATE DATABASE ColonialJourney 
USE ColonialJourney

CREATE TABLE Planets(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,

)

CREATE TABLE Spaceports(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PlanetId INT FOREIGN KEY REFERENCES Planets(Id) NOT NULL
)

CREATE TABLE Spaceships(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	LightSpeedRate INT  DEFAULT 0
)

CREATE TABLE Colonists(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Ucn VARCHAR(10) UNIQUE NOT NULL,
	BirthDate DATE NOT NULL
)

CREATE TABLE Journeys(
	Id INT PRIMARY KEY IDENTITY,
	JourneyStart DATETIME NOT NULL,
	JourneyEnd DATETIME NOT NULL,
	Purpose  VARCHAR(11)  CHECK(Purpose IN( 'Medical', 'Technical', 'Educational', 'Military')),
	DestinationSpaceportId INT FOREIGN KEY REFERENCES Spaceports(Id) NOT NULL, 
	SpaceshipId INT FOREIGN KEY REFERENCES Spaceships(Id) NOT NULL
)

CREATE TABLE TravelCards(
	Id INT PRIMARY KEY IDENTITY,
	CardNumber VARCHAR(10) UNIQUE NOT NULL,
	JobDuringJourney VARCHAR(8)  CHECK(JobDuringJourney IN ('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
	ColonistId INT FOREIGN KEY REFERENCES Colonists(Id) NOT NULL, 
	JourneyId INT FOREIGN KEY REFERENCES Journeys(Id) NOT NULL
)
/*-------------------Section 2. DML
Before you start, you must import “DataSet-ColonialJourney.sql”.
If you have created the structure correctly, the data should be successfully inserted without any errors.
In this section, you have to do some data manipulations:

--02.Insert

Insert sample data into the database.
Write a query to add the following records into the corresponding tables. All Ids should be auto-generated.
--------------------------------------------*/

INSERT INTO Planets(Name)
	VALUES
	('Mars'),
	('Earth'),
	('Jupiter'),
	('Saturn')

INSERT INTO Spaceships(Name,Manufacturer,LightSpeedRate)
	VALUES
	('Golf','VW',3),
	('WakaWaka','Wakanda',4),
	('Falcon9','SpaceX',1),
	('Bed','Vidolov',6)	

/*---03.Update
Update all spaceships light speed rate with 1 where the Id is between 8 and 12
----------------.----------*/

UPDATE Spaceships
SET LightSpeedRate += 1
	WHERE Id  BETWEEN 8 AND 12

SELECT * FROM Journeys

/*-------04.Delete
Delete first three inserted Journeys (be careful with the relationships)
---------------------.----------*/

DELETE FROM TravelCards
	WHERE JourneyId IN (1,2,3)

DELETE FROM Journeys
	WHERE Id IN (1,2,3)

/*------------------Section 3. Querying 
You need to start with a fresh dataset, so recreate your DB and import the sample data again (DataSet-ColonialJourney.sql).

--05.Select all military journeys
Extract from the database, all Military journeys in the format "dd-MM-yyyy". 
Sort the results ascending by journey start
.---------------------------------------------*/

SELECT Id,FORMAT(JourneyStart,'dd/MM/yyyy'),FORMAT(JourneyEnd,'dd/MM/yyyy')
	FROM Journeys
	WHERE Purpose = 'Military'
ORDER BY JourneyStart

/*-------06.Select all pilots
Extract from the database all colonists, which have a pilot job.
Sort the result by id, ascending.
`Required Columns
•	Id
•	FullName
-----------------------------------------------*/

SELECT c.Id,CONCAT(c.FirstName,' ',c.LastName)
	FROM Colonists c
	JOIN TravelCards AS t ON t.ColonistId = c.Id
	WHERE t.JobDuringJourney = 'pilot'
	ORDER BY c.Id ASC

/*-------07.Count colonists
Count all colonists that are on technical journey. 
Required Columns
•Count-------------------------------------*/

SELECT COUNT(*)
	FROM Colonists AS c
	JOIN TravelCards AS t ON t.ColonistId = c.Id
	JOIN Journeys AS j ON j.Id = t.JourneyId
 WHERE j.Purpose = 'Technical'

SELECT  * from TravelCards

/*-------08.	Select spaceships with pilots younger than 30 years
Extract from the database those spaceships, which have pilots, younger than 30 years old. In other words, 30 years from 01/01/2019. Sort the results alphabetically by spaceship name.
Required Columns
•	Name
•	Manufacturer
-----------------------------------*/

SELECT s.Name,s.Manufacturer
	FROM Colonists AS c
	JOIN TravelCards AS t ON t.ColonistId = c.Id
	JOIN Journeys AS j ON j.Id = t.JourneyId
	JOIN Spaceships AS s ON s.Id = j.SpaceshipId
 WHERE DATEDIFF(YEAR,BirthDate,'2019-01-01') < 30 AND t.JobDuringJourney = 'pilot'
 ORDER BY s.Name

/*--------------09.	Select all planets and their journey count
Extract from the database all planets’ names and their journeys count.
Order the results by journeys count, descending and by planet name ascending.
Required Columns
•	PlanetName
•	JourneysCount
------------------------------------------------------*/

SELECT p.Name,COUNT(*)
	FROM Planets AS p
	JOIN Spaceports AS s ON s.PlanetId = p.Id
	JOIN Journeys AS j ON j.DestinationSpaceportId = s.Id
GROUP BY p.Name
ORDER BY COUNT(*) DESC,p.Name


/*--------10.	Select Second Oldest Important Colonist
Find all colonists and their job during journey with rank 2. 
Keep in mind that all the selected colonists with rank 2 must be the oldest ones.
You can use ranking over their job during their journey.
Required Columns
•	JobDuringJourney
•	FullName
•	JobRank
---------------------------------------------*/

SELECT *
	FROM (SELECT t.JobDuringJourney,
	CONCAT(c.FirstName,' ',c.LastName) AS FullName,
	DENSE_RANK() OVER (PARTITION BY t.JobDuringJourney ORDER BY c.BirthDate) AS JobRank
	FROM Colonists AS c
	JOIN TravelCards AS t ON t.ColonistId = c.Id) AS r
 WHERE r.JobRank = 2

/*-----------Section 4. Programmability
01.	Get Colonists Count
Create a user defined function with the name
dbo.udf_GetColonistsCount(PlanetName VARCHAR (30)) that receives planet name and returns 
the count of all colonists sent to that planet.
-------------------------------------------------*/

 CREATE FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT(*)
		FROM Planets AS p
		JOIN Spaceports AS sp ON sp.PlanetId = p.Id
		JOIN Journeys AS j ON j.DestinationSpaceportId = sp.Id

		JOIN TravelCards AS t ON t.JourneyId = j.Id
	WHERE p.Name = @PlanetName)
END


/*12.	Change Journey Purpose
Create a user defined stored procedure, named usp_ChangeJourneyPurpose(@JourneyId, @NewPurpose), 
that receives an journey id and purpose, and attempts to change the purpose of that journey.
An purpose will only be changed if all of these conditions pass:
•	If the journey id doesn’t exists, then it cannot be changed. Raise an error with the message 
“The journey does not exist!”
•	If the journey has already that purpose, raise an error with the message “You cannot change the purpose!”
If all the above conditions pass, change the purpose of that journey.
---------------------------------------------------------------------------*/

CREATE PROC usp_ChangeJourneyPurpose @JourneyId INT , @NewPurpose VARCHAR(11)
AS
	IF(NOT EXISTS(SELECT * FROM Journeys WHERE Id = @JourneyId ))
	BEGIN
		RAISERROR('The journey does not exist!',16,1)
		RETURN
	END

	IF(EXISTS(SELECT * FROM Journeys WHERE Id = @JourneyId AND Purpose = @NewPurpose))
	BEGIN
		RAISERROR('You cannot change the purpose!',16,1)
		RETURN
	END

	UPDATE Journeys
		SET Purpose = @NewPurpose
		WHERE Id = @JourneyId