USE SoftUni2

--After Triggers
CREATE TRIGGER tr_TownsUpdate ON Towns FOR UPDATE
AS
  IF (EXISTS(
        SELECT * FROM inserted
        WHERE Name IS NULL OR LEN(Name) = 0))
  BEGIN
    RAISERROR('Town name cannot be empty.', 16, 1)
    ROLLBACK
    RETURN
  END

UPDATE Towns SET Name='' WHERE TownId=1

--Instead of Triggers

USE [Bank]

CREATE TABLE Accounts(
  Username varchar(10) NOT NULL PRIMARY KEY,
  [Password] varchar(20) NOT NULL,
  Active bit NOT NULL DEFAULT 1
)
CREATE TRIGGER tr_AccountsDelete ON Accounts
INSTEAD OF DELETE
AS
UPDATE a SET Active = 0
  FROM Accounts AS a JOIN DELETED d
    ON d.Username = a.Username
 WHERE a.Active = 1



