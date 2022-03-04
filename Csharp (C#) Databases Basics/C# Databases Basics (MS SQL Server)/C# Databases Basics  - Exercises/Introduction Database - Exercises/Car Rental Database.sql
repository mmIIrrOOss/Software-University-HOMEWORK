CREATE  DATABASE CarRental

USE CarRental

CREATE TABLE Categories(
	 Id INT PRIMARY KEY IDENTITY NOT NULL,
	 CategoryName NVARCHAR(100) NOT NULL,
	 DailyRate DECIMAL(5,2) NOT NULL,
	 WeeklyRate DECIMAL(6,2) NOT NULL,
	 MonthlyRate DECIMAL(7,2) NOT NULL,
	 WeekendRate DECIMAL(5,2) NOT NULL
)

CREATE TABLE Cars(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Manufacturer NVARCHAR(30) NOT NULL,
	Model NVARCHAR(15) NOT NULL,
	PlateNumber NVARCHAR(10) UNIQUE,
	CarYear DATE NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Doors INT NOT NULL,
	Condition NVARCHAR(100) NOT NULL,
	Available NVARCHAR(10) NOT NULL,
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirtstName NVARCHAR(15) NOT NULL,
	LastName NVARCHAR(15) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
	)

CREATE TABLE Customers(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DriverLicenceNumber INT NOT NULL,
	FullName NVARCHAR(100) NOT NULL,
	[Address] NVARCHAR(100) NOT NULL,
	City NVARCHAR(50) NOT NULL,
	ZIPCode INT NOT NULL,
	Notes NVARCHAR(MAX)
	)

CREATE TABLE RentalOrders(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	CarId INT FOREIGN KEY REFERENCES Cars(id) NOT NULL,
	TankLevel INT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT NOT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied INT NOT NULL,
	TaxRate INT NOT NULL,
	OrderStatus NVARCHAR(10) NOT NULL,
	Notes NVARCHAR(MAX) NOT NULL
)

SELECT * FROM Categories 

INSERT INTO Categories
	VALUES
		('Van',70,140,200,300),
        ('Sedan',70,140,200,400),
        ('4x4',70,140,200,500)


SELECT * FROM Categories  
SELECT * FROM Cars 
SELECT * FROM Employees 

INSERT INTO Cars(Manufacturer,Model,PlateNumber,CarYear,CategoryId,Doors,Condition,Available)
	VALUES
		('Mercedes','G class','A9999KH','2021-01-02',1,5,'Great','YES'),
		('BMW','M6','A6666KH','2021-02-03',2,5,'Great','YES'),
		('Audi','RS','A5555KH','2021-03-04',3,5,'Great','YES')

INSERT INTO Employees(FirtstName,LastName,Title,Notes)
	VALUES
		('Ivam','Ivanov','CEO','NONE'),
		('Petar','Petrov','Sales','NONE'),
		('Maria','Dimitrova','Marketing','Random')

SELECT * FROM Customers 
SELECT * FROM RentalOrders

INSERT INTO Customers(DriverLicenceNumber,FullName,[Address],City,ZIPCode,Notes)
	VALUES
		(645612365,'Miroslav Minkov Atanasov','Aleksandrovska 127','Burgas',8000,'NONE'),
		(645612665,'Ivan Minkov Atanasov','Aleksandrovska 157','Burgas',8000,'NONE'),
		(645692365,'Maria Minkov Atanasov','Aleksandrovska 147','Burgas',8000,'NONE')

INSERT INTO RentalOrders(EmployeeId,CustomerId,CarId,TankLevel,KilometrageStart,KilometrageEnd,
TotalKilometrage,StartDate,EndDate,TotalDays,RateApplied,TaxRate,OrderStatus,Notes)
	VALUES
	(1,1,2,80,1000,300000,301000,'2019-02-03','2026-02-03',2555,50,80,'Avalaable','NONE'),
	(2,2,2,90,5000,300000,305000,'2019-02-04','2026-02-04',2556,60,80,'Avalaable','YES'),
	(3,3,3,100,9000,300000,309000,'2019-02-05','2026-02-05',2557,70,90,'Avalaable','RANDOM')