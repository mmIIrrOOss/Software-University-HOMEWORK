--CREATE DATABASE WMS
--USE WMS

--01.Database design

CREATE TABLE Clients
(
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(12) NOT NULL
)

CREATE TABLE Mechanics
(
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(255) NOT NULL
)

CREATE TABLE Models
(
	ModelId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL,
)

CREATE TABLE Jobs
(
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT FOREIGN KEY REFERENCES Models(ModelId) NOT NULL,
	[Status] VARCHAR(11) DEFAULT 'Pending' CHECK([Status] IN ('Pending','In Progress','Finished')),
	ClientId INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL,
	MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE
)

CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	IssueDate DATE,
	Delivered BIT DEFAULT 0
)

CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL,
)

CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) UNIQUE NOT NULL,
	[Description] VARCHAR(255),
	Price MONEY CHECK(Price > 0) NOT NULL,
	VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId) NOT NULL,
	StockQty INT DEFAULT 0 CHECK(StockQty >= 0)
)

CREATE TABLE OrderParts
(
	OrderId INT FOREIGN KEY REFERENCES Orders(OrderId) NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
	Quantity INT DEFAULT 1 CHECK(Quantity > 0) NOT NULL
	CONSTRAINT PK_OrderParts PRIMARY KEY (OrderId,PartId)
)

CREATE TABLE PartsNeeded
(
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
	Quantity INT DEFAULT 1 CHECK(Quantity > 0) NOT NULL
	CONSTRAINT PK_PartsNeeded PRIMARY KEY (JobId,PartId)
)

--Section 2. DML
--02.Insert
INSERT INTO Clients(FirstName,LastName,Phone) VALUES
('Teri', 'Ennaco', '570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie', 'Mconnell', '908-802-3564'),
('Lemuel', 'Latzke', '631-748-6479'),
('Melodie', 'Knipp', '805-690-1682'),
('Candida', 'Corbley', '908-275-8357')

INSERT INTO Parts(SerialNumber,[Description],Price,VendorId) VALUES
('WP8182119', 'Door Boot Seal', 117.86, 2),
('W10780048', 'Suspension Rod', 42.81, 1),
('W10841140', 'Silicone Adhesive', 6.77, 4),
('WPY055980', 'High Temperature Adhesive', 13.94, 3)


--03.Update

UPDATE Jobs
	SET [Status] = 'In Progress' , MechanicId = 3
	WHERE [Status] = 'Pending '

--04.Delete

ALTER TABLE OrderParts
ADD CONSTRAINT FK__OrderPart FOREIGN KEY (OrderId) REFERENCES Orders(OrderId)  ON DELETE CASCADE

DELETE FROM Orders
	WHERE OrderId = 19

--Section 3. Querying 
--05.Mechanic Assignments

SELECT m.FirstName + ' ' + m.LastName AS [Mechanic],j.Status,j.IssueDate 
	FROM Mechanics AS m
	JOIN Jobs AS j ON j.MechanicId = m.MechanicId
ORDER BY m.MechanicId,j.IssueDate,j.JobId

--06.Current Clients
SELECT c.FirstName + ' ' + c.LastName AS Client,DATEDIFF(DAY, j.IssueDate,'2017-04-24'),j.Status
	FROM Jobs AS j
	JOIN Clients AS c ON c.ClientId = j.ClientId
	WHERE j.[Status] != 'Finished'

--07.Mechanic Performance

SELECT m.FirstName + ' ' + m.LastName AS Available
	FROM Mechanics AS m
	LEFT JOIN Jobs AS j ON j.MechanicId = m.MechanicId
	WHERE j.Status = 'Finished' OR j.JobId IS NULL
	GROUP BY m.FirstName,m.LastName,m.MechanicId
ORDER BY m.MechanicId

--08.vailable Mechanics

SELECT m.FirstName + ' ' + m.LastName AS Available
	FROM Mechanics AS m
	LEFT JOIN Jobs AS j ON j.MechanicId = m.MechanicId
	WHERE j.Status = 'Finished' OR j.JobId IS NULL
	GROUP BY m.FirstName,m.LastName,m.MechanicId
ORDER BY m.MechanicId

--09.Past Expenses

SELECT j.JobId,ISNULL(SUM(pr.Price * op.Quantity),0) AS Total
	FROM Jobs AS j
	LEFT JOIN Orders AS o ON o.JobId = j.JobId
	LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
	LEFT JOIN Parts AS pr ON pr.PartId = op.PartId
	WHERE j.[Status] = 'Finished'
 GROUP BY j.JobId
 ORDER BY Total DESC,j.JobId

 --10.Missing Parts

 SELECT TOP (3) pr.PartId,pr.Description,pn.Quantity AS [Required],pr.StockQty [In Stock],0 AS Ordered
	FROM Jobs AS j
	JOIN PartsNeeded AS pn ON pn.JobId = j.JobId
	JOIN Parts AS pr ON pr.PartId = pn.PartId
	WHERE j.[Status] != 'Finished' AND pn.Quantity > pr.StockQty

---Section 4.Programmability
---11.Place Order

CREATE PROC usp_PlaceOrder @JobId INT , @PartSerialNumber VARCHAR(50) ,@Quantity INT
AS
BEGIN
	DECLARE @Status VARCHAR(11) = (SELECT [Status] FROM Jobs WHERE JobId = @JobId)
	IF (@Quantity <= 0)
		THROW 50012,'Part quantity must be more than zero!',1
	ELSE IF (NOT EXISTS(SELECT JobId FROM Jobs WHERE JobId = @JobId))
		THROW 50013,'Job not found!',1
	ELSE IF (@Status = 'Finished')
		THROW 50011,'This job is not active!',1
	ELSE IF (NOT EXISTS(SELECT PartId FROM Parts WHERE SerialNumber = @PartSerialNumber))
		THROW 50014,'Part not found!',1

	IF((SELECT COUNT(*) FROM Orders WHERE JobId = @JobId AND IssueDate IS NULL) <> 1)
	BEGIN
		INSERT INTO Orders(JobId,IssueDate) VALUES
		(@JobId,NULL)
	END

	DECLARE @OrderId INT = (SELECT OrderId FROM Orders WHERE JobId = @JobId AND IssueDate IS NULL)
	DECLARE @PartId INT = (SELECT PartId FROM Parts WHERE SerialNumber = @PartSerialNumber)

	IF((SELECT COUNT(*) FROM OrderParts WHERE OrderId = @OrderId AND PartId = @PartId) <> 1)
	BEGIN
		INSERT INTO OrderParts VALUES
		(@OrderId,@PartId,@Quantity)
	END
	ELSE 
	BEGIN
		UPDATE OrderParts
			SET Quantity += @Quantity
			WHERE OrderId = @OrderId AND PartId = @PartId
	END

END

--12.Cost Of Order
CREATE FUNCTION udf_GetCost(@JobId INT)
RETURNS DECIMAL(15,2)
AS
BEGIN 
	DECLARE @Result DECIMAL(15,2) = 
	(
		SELECT SUM(pr.Price)
			FROM Jobs AS j
		 	LEFT JOIN Orders AS o ON o.JobId = j.JobId
			LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
			LEFT JOIN Parts AS pr ON pr.PartId = op.PartId
		WHERE j.JobId = @JobId
		GROUP BY j.JobId
	)

	IF @Result IS NULL
	 SET @Result = 0

	RETURN @Result
END
