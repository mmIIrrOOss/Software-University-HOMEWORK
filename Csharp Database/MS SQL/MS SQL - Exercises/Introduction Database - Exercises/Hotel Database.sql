CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(15) NOT NULL,
	LastName NVARCHAR(15) NOT NULL,
	Title NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX),
	Salary DECIMAL(6,2) NOT NULL
	)

	SELECT * FROM Employees 

CREATE TABLE Customers(
	AccountNumber INT UNIQUE NOT NULL,
	FirstName NVARCHAR(15) NOT NULL,
	LastName NVARCHAR(15) NOT NULL,
	PhoneNumber INT UNIQUE NOT NULL,
	EmergencyName NVARCHAR(10) UNIQUE NOT NULL,
	EmergencyNumber INT UNIQUE NOT NULL,
	Notes NVARCHAR(MAX)
	)

	SELECT * FROM Customers 

CREATE TABLE RoomStatus(
	RoomStatus NVARCHAR(10) NOT NULL,
	Notes NVARCHAR(max)
	)

	SELECT * FROM RoomStatus  


CREATE TABLE RoomTypes(
	RoomType NVARCHAR(10) NOT NULL,
	Notes NVARCHAR(MAX)
	)

	SELECT * FROM RoomTypes 
	

CREATE TABLE BedTypes(
	BedType NVARCHAR(15) NOT NULL,
	Notes NVARCHAR(MAX)
	)

	SELECT * FROM BedTypes bt 

CREATE TABLE Rooms(
	RoomNumber INT UNIQUE NOT NULL,
	RoomType NVARCHAR(15) NOT NULL,
	BedType NVARCHAR(15) NOT NULL,
	Rate DECIMAL(6,2) NOT NULL,
	RoomStatus NVARCHAR(10) NOT NULL,
	Notes NVARCHAR(MAX)
	)

	SELECT * FROM Rooms r 

CREATE TABLE Payments(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	PaymentDate DATETIME2 NOT NULL,
	AccountNumber INT UNIQUE NOT NULL,
	FirstDateOccupied DATE NOT NULL,
	LastDateOccupied DATE NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(6,2) NOT NULL,
	TaxRate DECIMAL(4,2) NOT NULL,
	TaxAmount DECIMAL(6,2) NOT NULL,
	PaymentTotal DECIMAL(6,2) NOT NULL,
	Notes NVARCHAR(MAX)
	)

	SELECT * FROM Payments p 

CREATE TABLE Occupancies(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	DateOccupied DATE NOT NULL,
	AccountNumber INT UNIQUE NOT NULL,
	RoomNumber NVARCHAR NOT NULL,
	RateApplied DECIMAL(4,2) NOT NULL,
	PhoneCharge INT NOT NULL,
	Notes NVARCHAR(MAX)
	)

	SELECT * FROM Occupancies o

	SELECT * FROM Employees 

INSERT INTO Employees(FirstName,LastName,Title,Notes)
	VALUES
		('Miroslav','Atanasov','CEO','none'),
		('Minka','Manolova','Worker','none'),
		('Stefan','Hristov','Administrator','none')

		SELECT * FROM Customers 

INSERT INTO Customers(AccountNumber,FirstName,LastName
,PhoneNumber,EmergencyName,EmergencyNumber,Notes)
	VALUES
		(1212,'Miroslav','Atanasov',0885785811,'Miro',9999,'none'),
		(2323,'Minka','Manolova',0884565987,'Minche',5555,'none'),
		(3434,'Stefan','Hristov',0882458848,'Steff',3333,'none')

		SELECT * FROM RoomStatus  

INSERT INTO RoomStatus(RoomStatus,Notes)
	VALUES
		('FREE','NONE'),
		('NOT-FREE','NONE')

		SELECT * FROM RoomTypes
		
INSERT INTO RoomTypes(RoomType,Notes)
	VALUES
		('Apartment','none'),
		('Room','none')

		SELECT * FROM BedTypes bt 

INSERT INTO BedTypes(BedType,Notes)
	VALUES
		('Bed','none'),
		('Bedrom','none')

		SELECT * FROM Rooms r 

INSERT INTO Rooms(RoomNumber,RoomType,BedType,Rate,RoomStatus,Notes)
	VALUES
		(1,'Apartment','Bedroom',150,'FREE','NONE'),
		(2,'Apartment','Bedroom',150,'NOT-FREE','NONE'),
		(3,'Room','Bed',70,'FREE','NONE')

		SELECT * FROM Payments p 
		
INSERT INTO Payments(EmployeeId,PaymentDate,AccountNumber,FirstDateOccupied,LastDateOccupied,
	TotalDays,AmountCharged,TaxRate,TaxAmount,PaymentTotal,Notes)
		VALUES
			(1,'2022-01-20 19:20:00',1212,'2022-01-18','2022-01-20',2,300,20,10,136,'none'),
			(2,'2022-01-19 19:20:00',2323,'2022-01-17','2022-01-29',2,300,20,10,136,'none'),
			(3,'2022-01-18 19:20:00',3434,'2022-01-16','2022-01-18',2,300,20,10,136,'none')
			
		SELECT * FROM Occupancies o

INSERT INTO Occupancies(EmployeeId,DateOccupied,AccountNumber,RoomNumber,RateApplied,PhoneCharge,Notes)
	VALUES
		(1,'2022-01-18',1212,1,20,1,'none'),
		(1,'2022-01-17',2323,1,20,1,'none'),
		(1,'2022-01-16',3434,1,20,1,'none')

SELECT * FROM Employees e
      
SELECT * FROM Payments P

UPDATE Payments
SET TaxRate-= TaxRate*0.7

SELECT * FROM Payments p

DELETE FROM Occupancies 