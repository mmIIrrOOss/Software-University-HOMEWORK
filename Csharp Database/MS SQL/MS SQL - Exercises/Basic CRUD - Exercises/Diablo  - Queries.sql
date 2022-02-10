CREATE DATABASE Relationships

USE Relationships

CREATE TABLE Passports(
	PassportID INT PRIMARY KEY NOT NULL,
	PassporTNumber CHAR(8) NOT NULL
	)

CREATE TABLE Persons(
	PersonID INT PRIMARY KEY,
	FirstName NVARCHAR(30) NOT NULL,
	Salary DECIMAL(7,2) NOT NULL,
	PassportID INT NOT NULL FOREIGN KEY REFERENCES Passports(PassportID) UNIQUE
	)


		 

INSERT INTO Passports(PassportID,PassporTNumber)
	VALUES
		(101,'N34FG21B'),
		(102,'K65LO4R7'),
		(103,'ZE657QP2')

INSERT INTO Persons(PersonID,FirstName,Salary,PassportID)
	VALUES
		(1,'Roberto',43300.00,102),
		(2,'Tom',56100,103),
		(3,'Yana',60200.00,101)

CREATE TABLE Manufacterers(
	ManufecturerID INT PRIMARY KEY NOT  NULL,
	[Name] CHAR(30) NOT NULL,
	EstablishedOn DATE NOT NULL,
	)

CREATE TABLE Models(
	ModelID INT PRIMARY KEY NOT NULL,
	[Name] CHAR(30)NOT NULL,
	ManufacturerID INT NOT NULL FOREIGN KEY REFERENCES Manufacterers(ManufecturerID)
	)

INSERT INTO Manufacterers(ManufecturerID,[Name],EstablishedOn)
	VALUES
		(1,'BMW','07/03/1916'),
		(2,'Tesla','01/01/2003'),
		(3,'Lada','01/05/1966')

INSERT INTO Models(ModelID,[Name],ManufacturerID)
	VALUES
		(101,'X1',1),
		(102,'i6',1),
		(103,'Model S',2),
		(104,'Model X',2),
		(105,'Model 3',2),
		(106,'Nova',3)

SELECT * FROM Manufacterers 
SELECT * FROM Models 


CREATE TABLE Students(
	StudentID INT PRIMARY KEY,
	[Name] NVARCHAR(30) NOT NULL,
)

CREATE TABLE Exams(
	ExamID INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(80) NOT NULL,
)

CREATE TABLE StudentsExams(
	StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID),
	ExamID INT NOT NULL FOREIGN KEY REFERENCES Exams(ExamID),
		PRIMARY KEY(StudentID,ExamID)
)

INSERT INTO Students(StudentID,[Name])
	VALUES
		(1,'Mila'),
		(2,'Toni'),
		(3,'Ron')

SELECT * FROM Students s

INSERT INTO Exams(ExamID,[Name])
	VALUES
		(101,'SpringMVC'),
		(102,'nEO4J'),
		(103,'Oracle 11g')

SELECT * FROM Exams

INSERT INTO StudentsExams(StudentID,ExamID)
	VALUES
		(1,101),
		(1,102),
		(2,101),
		(3,103),
		(2,102),
		(2,103)

SELECT * FROM StudentsExams

SELECT s.[Name], e.[Name] FROM StudentsExams AS se
	JOIN Students AS s ON se.StudentID = s.StudentID
	JOIN Exams AS e ON se.ExamID = e.ExamID

CREATE TABLE Teachers(
	TeacherID INT PRIMARY KEY,
	[Name] NVARCHAR(30) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers(TeacherID,[Name],ManagerID)
	VALUES
		(101,'John',NULL),
		(102,'Maya',106),
		(103,'Silvia',106),
		(104,'Ted',105),
		(105,'Mark',101),
		(106,'Greta',101)

SELECT * FROM Teachers t

