CREATE TABLE Directors
(
    Id int IDENTITY ,
    DirectorName nvarchar(50) NOT NULL,
    Notes nvarchar(MAX)
)

CREATE TABLE Genres
(
    Id int IDENTITY,
    GenereName nvarchar(50) NOT NULL,
    Notes nvarchar(MAX)
)

CREATE TABLE Categories 
(
    Id int IDENTITY,
    CategoryName nvarchar(50) NOT NULL,
    Notes nvarchar(MAX)
)

CREATE TABLE Movies
(
    Id int IDENTITY,
    Title nvarchar(50),
    DirectorId int,
    CopyrightYear  int,
    Length int,
    GenreId int,
    CatgoryId int,
    Rating int, 
    Notes nvarchar(MAX)
)

ALTER TABLE Directors
ADD CONSTRAINT PK_Id
PRIMARY KEY (Id)

ALTER TABLE Genres
ADD CONSTRAINT PK_Genres
PRIMARY KEY (Id)

ALTER TABLE Categories
ADD CONSTRAINT PK_Categories
PRIMARY KEY (Id)

ALTER TABLE Movies
ADD CONSTRAINT PK_Movies
PRIMARY KEY (Id)

INSERT INTO Directors(DirectorName,Notes)
VALUES ('Pesho', 'Пешо е добър служител'), 
('Mitko','Митко е най-добрия'),
('Калин', 'Отличникът'),
('Калина', 'Тя просто е перфектна'),
('Явор', 'Връзкар')

INSERT INTO Genres (GenereName, Notes)
VALUES ('Asen', 'klklkl'),
('Kaloqn', ' lrlllll'),
('Simeon', 'Aheloi'),
('Boris', 'Покръстителят'),
('Крум', 'Крумовите закони')

INSERT INTO Categories (CategoryName,Notes)
VALUES ('HISTORY', 'Отличен филм'),
('Action', 'Oscar'),
('History','lklllllk'),
('drama', 'lkooooopo' ),
('Triller', 'llkllkklk')

INSERT INTO Movies (Title,DirectorId,CopyrightYear,Length,GenreId,CatgoryId,Rating,Notes)
VALUES(' King' ,5,1999,78,1,5,10,'otlichen'),
('RRIRIR',4,2000,90,2,4,9,'otlichen'),
('plpppo',3,1980,100,3,3,5,'otlichen'),
('kkiklo',2,1890,20,4,2,10,'iopkll'),
('ukukkk',1,1990,120,5,1,10,'plpppp')