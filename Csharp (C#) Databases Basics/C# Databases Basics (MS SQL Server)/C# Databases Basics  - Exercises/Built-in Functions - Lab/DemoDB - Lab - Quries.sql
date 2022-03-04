USE DemoDB

SELECT CustomerID,FirstName,LastName,
	LEFT(PaymentNumber,6) + '**********'
	FROM Customers

/*STRING FUNCTIONS*/
SELECT LOWER('MRISLAV')
SELECT UPPER('miroslav')
SELECT REPLICATE('mmiirrooss ',10)
SELECT REVERSE('miros')
SELECT CHARINDEX('o','Miroslav',4)
SELECT STUFF('Miroslav', 4, 5, 'pp')
SELECT FORMAT ( GETDATE(), 'yyyy-dd-MM' )

/*MATH FUNCTIONS*/
SELECT PI()
SELECT ABS(-20)
SELECT SQRT(9)
SELECT SQUARE(9)
SELECT POWER(9,2)
SELECT ROUND(3.14544,2)
SELECT FLOOR(3.2)
SELECT CEILING(3.2)

/*Exam*/
SELECT CEILING(
	CEILING(CAST(Quantity AS float) /
					BoxCapacity) / PalletCapacity)
		AS [Number of pallets]
		FROM Products

SELECT SIGN(50)
SELECT SIGN(-50)
SELECT SIGN(0)
SELECT RAND()
SELECT DATEPART(year, '12:10:30.123')  
    ,DATEPART(month, '12:10:30.123')  
    ,DATEPART(day, '12:10:30.123')  
    ,DATEPART(dayofyear, '12:10:30.123')  
    ,DATEPART(weekday, '12:10:30.123'); 
	SELECT DATEPART(millisecond, '00:00:01.1234567'); -- Returns 123  
SELECT DATEPART(microsecond, '00:00:01.1234567'); -- Returns 123456  
SELECT DATEPART(nanosecond,  '00:00:01.1234567'); -- Returns 123456700 

CREATE TABLE Quarterly (
	InvoiceID INT PRIMARY KEY IDENTITY,
	InvoiceDate DATE NOT NULL,
	Total DECIMAL(4,2) NOT NULL
)
SELECT * FROM Quarterly

INSERT INTO Quarterly(InvoiceDate,Total)
	VALUES
		('2009-01-01',1.98),
		('2009-01-02',3.96),
		('2009-01-03',5.94),
		('2009-01-04',8.91)

SELECT InvoiceId, Total,
	DATEPART(QUARTER, InvoiceDate) AS Quarter,
	DATEPART(MONTH, InvoiceDate) AS Month,
	DATEPART(YEAR, InvoiceDate) AS Year,
	DATEPART(DAY, InvoiceDate) AS Day
FROM Quarterly