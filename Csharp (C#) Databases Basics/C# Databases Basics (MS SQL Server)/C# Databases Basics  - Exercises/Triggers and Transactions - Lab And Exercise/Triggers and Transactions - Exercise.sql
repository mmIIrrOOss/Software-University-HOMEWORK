USE Bank

--01.Create Table Logs

CREATE TABLE Logs(
	LogId INT PRIMARY KEY IDENTITY ,
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
	OldSum DECIMAL(15,2),
	NewSum DECIMAL(15,2)
)

SELECT * FROM Logs

CREATE TRIGGER tr_InsertAccountInfo ON Accounts FOR UPDATE
AS
	DECLARE @newSum DECIMAL(15,2) = (SELECT Balance	FROM INSERTED)
	DECLARE @oldSum DECIMAL(15,2) = (SELECT Balance FROM DELETED)
	DECLARE @accountId INT  = (SELECT Id FROM INSERTED)
INSERT INTO Logs(AccountId, NewSum, OldSum)
	VALUES
	(@accountId, @newSum, @oldSum)

UPDATE Accounts
SET Balance = 10
WHERE Id = 1;

--02.Create Table Emails

CREATE TABLE NotificationEmails(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT FOREIGN KEY REFERENCES Accounts(Id),
	[Subject] VARCHAR(50),
	Body VARCHAR(MAX)
) 

ALTER TRIGGER tr_LogEmail ON Logs FOR INSERT
AS 
DECLARE @accountId INT = (SELECT TOP(1) AccountId FROM INSERTED)
DECLARE @oldSum	DECIMAL(15,2) = (SELECT TOP(1) OldSum FROM INSERTED)
DECLARE @newSum	DECIMAL(15,2) = (SELECT TOP(1) NewSum FROM INSERTED)

INSERT INTO NotificationEmails(Recipient,[Subject],Body)
	VALUES
 (
	@accountId,
	'Balance change for account: ' + @accountId,
	'On ' +CONVERT(VARCHAR(50),GETDATE(),103)+ 
	' your balance was changed from '
	+ CAST(@oldSum AS VARCHAR(20)) + ' to ' + CAST(@newSum AS VARCHAR(20)
)

SELECT * FROM Accounts
	WHERE Id = 1

UPDATE Accounts
	SET Balance +=100
	WHERE Id = 1

--03.Deposit Money
CREATE PROCEDURE usp_DepositMoney(@AccountId INT, @moneyAmount MONEY)
AS
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = Balance + @moneyAmount
		WHERE Accounts.Id = @AccountId
		BEGIN
			COMMIT
		END

--04.Withdraw Money
CREATE PROCEDURE usp_WithdrawMoney(@AccountId INT, @moneyAmount MONEY)
AS
BEGIN
	DECLARE @CurrentAccountBalance MONEY
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = Balance - @moneyAmount
		WHERE Accounts.Id = @AccountId		
		SET @CurrentAccountBalance = (SELECT Balance FROM Accounts AS a WHERE a.Id = @AccountId)		
		IF (@CurrentAccountBalance < 0)
		BEGIN
			ROLLBACK
		END
		ELSE
		BEGIN
			COMMIT
		END
END

--05.Money Transfer

CREATE PROCEDURE usp_TransferMoney(@senderId INT, @receiverId INT, @amount MONEY)
AS
BEGIN
	DECLARE @SenderBalance MONEY = (SELECT ac.Balance FROM Accounts AS ac WHERE ac.Id = @senderId)
	BEGIN TRAN
		IF(@amount < 0)
		BEGIN
			ROLLBACK
		END
		ELSE
		BEGIN
			IF(@SenderBalance - @amount >= 0)
			BEGIN
				EXEC usp_WithdrawMoney @senderId, @amount
				EXEC usp_DepositMoney @receiverId, @amount
				COMMIT
			END
			ELSE
			BEGIN
				ROLLBACK
			END
		END
END

--06.*Massive Shopping

CREATE PROCEDURE usp_AssignProject (@employeeID int, @projectID int)
AS
BEGIN
  DECLARE @maxEmployeeProjectsCount int = 3;
  DECLARE @employeeProjectsCount int;

  BEGIN TRAN
  INSERT INTO EmployeesProjects (EmployeeID, ProjectID) 
  VALUES (@employeeID, @projectID)

  SET @employeeProjectsCount = (
    SELECT COUNT(*)
    FROM EmployeesProjects
    WHERE EmployeeID = @employeeID
  )
  IF(@employeeProjectsCount > @maxEmployeeProjectsCount)
    BEGIN
      RAISERROR('The employee has too many projects!', 16, 1);
      ROLLBACK;
    END
  ELSE COMMIT
END

--testing - do not submit in Judge
EXEC usp_AssignProject 2, 1; -- no projects initially
EXEC usp_AssignProject 2, 2;
EXEC usp_AssignProject 2, 3;
EXEC usp_AssignProject 2, 4; -- raiserror & rollback


--07.AssignProject
USE SoftUni2

CREATE PROC usp_AssignProject @emloyeeId INT, @projectID INT
AS
BEGIN
	BEGIN TRAN
	INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
	VALUES (@emloyeeId, @projectID)
	DECLARE @employeeProjectNumber INT = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = @emloyeeId)
	IF(@employeeProjectNumber > 3)
	BEGIN
		RAISERROR('The employee has too many projects!',16,1)
		ROLLBACK
	END
	ELSE
	BEGIN
		COMMIT
	END
END

EXEC dbo.ufn_CashInUsersGames 'Love in a mist'

--08.Delete Employees

CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50),
	LastName VARCHAR(50),
	MiddleName VARCHAR(50),
	JobTitle VARCHAR(50),
	DepartmentID INT,
	Salary MONEY
)

CREATE TRIGGER tr_Employees_After_Delete ON Employees FOR DELETE
AS
BEGIN
	INSERT INTO Deleted_Employees (FirstName, LastName, MiddleName, JobTitle, DepartmentID, Salary)
	SELECT d.FirstName, d.LastName, d.MiddleName, d.JobTitle, d.DepartmentID, d.Salary FROM deleted AS d
END

EXEC tr_Employees_After_Delet

