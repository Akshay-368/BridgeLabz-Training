USE master;
GO

--  Kick everyone out and roll back their unfinished work ( just for testing and development purposes , not for production environment)
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'ContactsManagerDb')
BEGIN
    Alter DATABASE ContactsManagerDb Set Single_User With Rollback Immediate ;
    DROP DATABASE ContactsManagerDb;
END
GO

-- Creating the database
Create database ContactsManagerDb;
GO

USE ContactsManagerDb;
GO

----------------------------------------------------------------------------------------------------------------

-- Creating the tables
Create Table Contacts
(
    ContactId int PRIMARY Key Identity(1,1) Not Null ,
    FirstName nvarchar(50) Not Null,
    LastName nvarchar(50) Not Null,
    PhoneNumber nvarchar(50) Unique Not Null,
    Email nvarchar(50) Null,
    Address nvarchar(200) Null,
    ContactType VARCHAR(50) Not Null  Check ( ContactType IN ('Work','Home','Personal','Other')) Default ( 'Personal') ,
    DateOfBirth Date Null,
    RelationType VARCHAR(50) Not Null  Check ( RelationType IN ('Family','Friend','Acquaintance','Colleague','Other')) Default ( 'Other') ,
    CustomRelation nvarchar(50) Null,
    IsVip Bit Not Null Default (0),
    CreatedDate DATETIME2 Not Null Default (SYSDATETIME()),-- using SysDateTime() instead of GetDate() for more precision as it gives upto nanoseconds instead of milliseconds
    UpdatedDate DATETIME2 Not Null Default (SYSDATETIME())
);
GO

-- This is specifically for tracking the changes in the database
Create Table SystemAuditLogs (
    LogId int Primary Key Identity (1,1) ,
    ActionType varchar (100) Not Null check (ActionType in ('Insert', 'Update', 'Delete' )), -- Type of action performed
    ContactId int Null ,
    ActionDate DATETIME2 Not Null Default SYSDATETIME(),
    OldValue NVARCHAR (MAX) Null , -- Old value before the change, which can be null for Insert actions. Also Using MAX instead of 255 to store full row snapshots
    NewValue NVARCHAR (MAX) Null -- New value after the change, which can be null for Delete actions
);
GO

----------------------------------------------------------------------------------------------------------------
-- Creating a trigger on the table Contacts

-- Trigger on SystemAUditLogs itself to act as a  way to ask the user for the active conscious consent to actually delete the record
-- and thus acting as a soft safety mechanism for preventing user from shooting themslef in the foot
GO
Create Trigger trg_AduitSystemAuditLogs
on SystemAuditLogs
After Update , DELETE
AS
BEGIN
    IF TRIGGER_NESTLEVEL() > 1
        RETURN;
    Set NoCount ON ;
    Declare @ActionType Varchar (100) ;
    If Exists ( Select * from inserted ) and exists ( Select * from deleted)
        Set @ActionType = 'Update';
    Else If Exists ( Select * from inserted) 
        Set @ActionType = 'Insert';
    ELSE Set @ActionType = 'Delete';
    Insert Into SystemAuditLogs ( ActionType , ContactId , ActionDate , OldValue , NewValue )
    SELECT
          @ActionType,
          COALESCE (i.ContactId , d.ContactId),
          SYSDATETIME(),
          (Select d.* for Json Path , Without_Array_Wrapper),
          ( Select i.* for Json Path , WIthout_Array_Wrapper)
        From inserted i Full Outer Join deleted d on i.LogId = d.LogId ;
END
Go

GO
Create Trigger trg_AuditContacts
on Contacts
After Insert , Update , Delete
AS
BEGIN
    Set NoCount ON ;
    Declare @ActionType Varchar (100) ;
    If Exists ( Select * from inserted ) and exists ( Select * from deleted)
        Set @ActionType = 'Update';
    Else If Exists ( Select * from inserted) 
        Set @ActionType = 'Insert';
    ELSE Set @ActionType = 'Delete';
    Insert Into SystemAuditLogs ( ActionType , ContactId , ActionDate , OldValue , NewValue )
    SELECT
          @ActionType,
          Coalesce (i.ContactId , d.ContactId),
          SYSDATETIME(),
          (Select d.* for Json Path , Without_Array_Wrapper),
          ( Select i.* for Json Path , WIthout_Array_Wrapper)
        From inserted i Full Outer Join deleted d on i.ContactId = d.ContactId ;
END
Go


----------------------------------------------------------------------------------------------------------------
DENY Update , DELETE ON SystemAuditLogs TO PUBLIC;
GO