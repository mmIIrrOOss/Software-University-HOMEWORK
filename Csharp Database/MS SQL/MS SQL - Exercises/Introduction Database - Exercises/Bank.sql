CREATE PROC p_Withdraw @AccountId INT, @Amount DECIMAL(15, 2) AS
BEGIN
DECLARE @OldBalance DECIMAL(15, 2)
SELECT @OldBalance = Balance FROM Accounts WHERE Id = @AccountId
IF (@OldBalance - @Amount >= 0)
BEGIN
UPDATE Accounts
SET Balance -= @Amount
WHERE Id = @AccountId
END
ELSE
BEGIN
RAISERROR('Insufficient funds', 10, 1)
END
END

CREATE TABLE Transactions (
Id INT PRIMARY KEY IDENTITY,
AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
OldBalance DECIMAL(15, 2) NOT NULL,
NewBalance DECIMAL(15, 2) NOT NULL,
Amount AS NewBalance - OldBalance,
[DateTime] DATETIME2
)

CREATE TRIGGER tr_Transaction ON Accounts
AFTER UPDATE
AS
INSERT INTO Transactions (AccountId, OldBalance, NewBalance, [DateTime])
SELECT inserted.Id, deleted.Balance, inserted.Balance, GETDATE() FROM inserted
JOIN deleted ON inserted.Id = deleted.Id

p_Deposit 1, 25.00
GO
p_Deposit 1, 40.00
GO
p_Withdraw 2, 200.00
GO
p_Deposit 4, 180.00
GO

SELECT * FROM Transactions