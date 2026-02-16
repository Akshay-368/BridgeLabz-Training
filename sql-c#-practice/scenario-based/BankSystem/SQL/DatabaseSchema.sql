Use master;
GO
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'BankSystem')
BEGIN
    Alter DATABASE BankSystem Set Single_User WITH ROLLBACK IMMEDIATE;
    Drop DATABASE BankSystem;
END
GO
Create DATABASE BankSystem;
GO
Use BankSystem;
GO

---------------------------------------------------------------------------------------
-- Creating tables
Create TABLE Accounts(
  AccountId int Primary Key Identity(1,1),
  HolderName Nvarchar(50) Not Null ,
  Balance DECIMAL NOT NULL ,
  IsDeleted BIT NOT NULL DEFAULT 0 -- 0 means false and 1 means true
);
GO

CREATE TABLE Transactions(
  TransactionId int Primary Key Identity(1,1),
  -- AccountId int FOREIGN KEY REFERENCES Accounts(AccountId) On Delete CASCADE,
  -- Using cascade could be risky but ofcourse now transactions should be deleted if accout is getting deleted .
  -- so it brings up a bit of trouble , that's why i am adding IsDeleted bit for soft delete adn simply that bit will turn 1 when account is getting deleted
  AccountId int FOREIGN KEY REFERENCES Accounts(AccountId),
  Amount DECIMAL NOT NULL,
  Type Nvarchar(50) NOT NULL Check ( Type in ( 'Deposit','Withdrawal')) ,
  TransactionDate DATETIME2 NOT NULL
);
GO
----------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Creating Stored Procedures

Create Procedure sp_InsertAccount
@HolderName Nvarchar(50),
@Balance DECIMAL,
@NewAccountId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
        BEGIN TRY
            Insert INTO Accounts(HolderName,Balance) Values(@HolderName,@Balance);
            -- 3. SET THE OUTPUT PARAMETER for C#
            SET @NewAccountId = SCOPE_IDENTITY();
        COMMIT TRANSACTION
        End TRY
  BEGIN CATCH
    ROLLBACK TRANSACTION ;
    Throw ;
  End Catch
END
GO

CREATE PROCEDURE sp_DeleteAccount
    @AccountId INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;

    BEGIN TRY

        IF NOT EXISTS
        (
            SELECT 1 FROM Accounts
            WHERE AccountId = @AccountId
            AND IsDeleted = 0
        )
        BEGIN
            ;THROW 50001, 'Account not found or already deleted.', 1;
        END

        UPDATE Accounts
        SET IsDeleted = 1
        WHERE AccountId = @AccountId;

        COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH

        ROLLBACK TRANSACTION;
        THROW;

    END CATCH
END
GO

CREATE PROCEDURE sp_Deposit
    @AccountId INT,
    @Amount DECIMAL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;

    BEGIN TRY

        IF @Amount <= 0
        BEGIN
            ;THROW 50002, 'Deposit amount must be positive.', 1;
        END

        UPDATE Accounts
        SET Balance = Balance + @Amount
        WHERE AccountId = @AccountId
        AND IsDeleted = 0;

        IF @@ROWCOUNT = 0
        BEGIN
            ;THROW 50003, 'Account not found.', 1;
        END

        INSERT INTO Transactions
        (AccountId, Amount, Type, TransactionDate)
        VALUES
        (@AccountId, @Amount, 'Deposit', SYSDATETIME());

        COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH

        ROLLBACK TRANSACTION;
        THROW;

    END CATCH
END
GO


CREATE PROCEDURE sp_Withdraw
    @AccountId INT,
    @Amount DECIMAL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;

    BEGIN TRY

        IF @Amount <= 0
        BEGIN
            ;THROW 50004, 'Withdrawal amount must be positive.', 1;
        END

        DECLARE @CurrentBalance DECIMAL;

        SELECT @CurrentBalance = Balance
        FROM Accounts
        WHERE AccountId = @AccountId
        AND IsDeleted = 0;

        IF @CurrentBalance IS NULL
        BEGIN
            ;THROW 50005, 'Account not found.', 1;
        END

        IF @CurrentBalance < @Amount
        BEGIN
            ;THROW 50006, 'Insufficient balance.', 1;
        END

        UPDATE Accounts
        SET Balance = Balance - @Amount
        WHERE AccountId = @AccountId;

        INSERT INTO Transactions
        (AccountId, Amount, Type, TransactionDate)
        VALUES
        (@AccountId, @Amount, 'Withdrawal', SYSDATETIME());

        COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH

        ROLLBACK TRANSACTION;
        THROW;

    END CATCH
END
GO

CREATE PROCEDURE sp_GetBalance
    @AccountId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Balance
    FROM Accounts
    WHERE AccountId = @AccountId
    AND IsDeleted = 0;
END
GO
