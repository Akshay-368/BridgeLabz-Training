Use HospitalDb;
GO

-- Now i will Deny everyone the ability to Delete or Update the logs
-- This makes the table "Write-Only" for the system and "Read-Only" for the Admin.
Deny Update, Delete On SystemAuditLogs To Public ;
Deny Update , Delete ON AppointmentAudit To Public ;
Go

-- Now I will assign the permissions to the roles 

-- A. Front Desk (Receptionist)
-- Financials :they need to record payments and transactions when a patient pays
Grant Select , Insert On PaymentTransactions To Role_FrontDesk ;
-- Audit Logs : They should be able to see the appointments aduit logs to track booking changes 
-- but should be able to delete or update them
Grant Select on AppointmentAudit To Role_FrontDesk ;

-- Lookups : They need to see doctors and their schedules to book appointments
Grant Select On Doctors To Role_FrontDesk ;
Grant Select on DoctorSchedules To Role_FrontDesk ;
Grant Select on Specialties To Role_FrontDesk ;

-- Staff -> They may need to see contact info for other staff members for coordination
Grant Select On Staff To Role_FrontDesk ;

Grant Select, Insert, Update ON Patients TO Role_FrontDesk;
Grant Select, Insert, Update, Delete ON Appointments TO Role_FrontDesk;
Grant Select, Insert, Update ON Bills TO Role_FrontDesk;

/* DENIALS FOR Role_FrontDesk (Safety & Privacy) */
DENY UPDATE, DELETE ON PaymentTransactions TO Role_FrontDesk; -- Payments should be immutable
-- They CANNOT see medical details:
Deny Select ON Visits TO Role_FrontDesk; 
Deny Select ON Prescriptions TO Role_FrontDesk;
-- They also shouldn't be able to delete patient records, as that can lead to loss of important medical history and data integrity issues:
DENY DELETE ON Patients TO Role_FrontDesk; -- Receptionists shouldn't delete patient history
-- Just like Patients, gotta need to ensure they can't delete a financial record:
DENY DELETE ON Bills TO Role_FrontDesk;
-- Security Rule :-> Front Desk staff should not see or touch login credentials at any cost.
-- Password management is an IT_Staff or Hospital_Admin task.
DENY SELECT, INSERT, UPDATE, DELETE ON Users TO Role_FrontDesk;
GO

/* Ensuring FrontDesk/Medical can NEVER perform DDL */
-- In SQL Server, this is implicit (they can't do it unless granted),
-- but if just to be extra safe:
DENY ALTER, CONTROL ON DATABASE::HospitalDb TO Role_FrontDesk;


---------------------------------------------------------------------------------

/*  MEDICAL ROLE (Doctors, Nurses, Pharmacists) */
-- Doctors and Nurses need to see patient details and history to treat them
GRANT SELECT ON Patients TO Role_Medical;
GRANT SELECT ON Appointments TO Role_Medical;
GRANT SELECT, INSERT, UPDATE ON Visits TO Role_Medical;
GRANT SELECT, INSERT, UPDATE ON Prescriptions TO Role_Medical;
GRANT SELECT ON DoctorSchedules TO Role_Medical;
GRANT SELECT ON Staff TO Role_Medical;
GRANT SELECT ON Specialties TO Role_Medical;
-- They should be able to see why an appointment was changed for better coordination
Grant Select On AppointmentAudit To Role_Medical ;

-- Pharmacists only need to see prescriptions and patient names, not diagnoses (Privacy)
-- We use DENY to override the general Medical grant for Pharmacist-specific users , as this is the policy of the  HIPAA compliance for the hospital to ensure that pharmacists only have access to the information they need to do their job, which is managing prescriptions, without exposing them to sensitive medical information that they don't need, such as diagnoses and medical history, which helps protect patient privacy and comply with regulations.
-- So for that I will have to create a separate role for Pharmacists and assign the permissions accordingly.
-- Or i can just put them under the Role_Medical as a parent role.
GO
Create Role Role_Pharmacist ;
Go
Alter Role Role_Medical Add Member Role_Pharmacist ; -- This makes Pharmacists inherit all permissions
Deny Select ON Visits TO Role_Pharmacist; -- But they should not see diagnoses
Go

/* MEDICAL ROLE - FINANCIAL & SYSTEM REJECTIONS (The Strict No) */

-- Doctors should NOT be involved in the billing process as there could be Conflict of interest and Privacy concerns
DENY SELECT, INSERT, UPDATE, DELETE ON Bills TO Role_Medical;
DENY SELECT, INSERT, UPDATE, DELETE ON PaymentTransactions TO Role_Medical;

-- Doctors should NEVER touch system-level security or logs
DENY SELECT, INSERT, UPDATE, DELETE ON Users TO Role_Medical;
DENY SELECT ON SystemAuditLogs TO Role_Medical;

/*  DDL / DCL / ADMINISTRATIVE REJECTIONS */

-- I will explicitly block them frowam changing the table structures (DDL) 
-- or granting permissions to others (DCL) Though in SQL Server, this is implicit (they can't do it unless granted),
-- but  just to be extra safe:
DENY ALTER, CONTROL ON DATABASE::HospitalDb TO Role_Medical;
GO


-------------------------------------------------------------------------------------

/*  PATIENT ROLE (Self-Service & Family) */
-- Patients can see their own basic info and schedule
GRANT SELECT ON Patients TO Role_Patient;
GRANT SELECT ON Appointments TO Role_Patient;
GRANT SELECT ON Prescriptions TO Role_Patient;
GRANT SELECT ON Doctors TO Role_Patient; -- To see who their doctor is
GRANT SELECT ON Specialties TO Role_Patient; -- To see the doctor's specialty
GRANT SELECT ON DoctorSchedules TO Role_Patient;

-- Financials: They need to see what they owe and their payment history
GRANT SELECT ON Bills TO Role_Patient;
GRANT SELECT ON PaymentTransactions TO Role_Patient;

-- STRICT DENIALS: Patients can NEVER touch the "internals"
DENY INSERT, UPDATE, DELETE ON Doctors TO Role_Patient;
DENY Select , INSERT, UPDATE, DELETE ON Staff TO Role_Patient;
DENY INSERT, UPDATE, DELETE ON Specialties TO Role_Patient;
-- Patients should NEVER see the internal 'Visits' table (raw diagnosis/clinical notes)
DENY SELECT ON Visits TO Role_Patient;
-- Security & Audit rejections
DENY SELECT ON Users TO Role_Patient;
DENY SELECT ON SystemAuditLogs TO Role_Patient;
DENY SELECT ON AppointmentAudit TO Role_Patient;
-- Prevent any schema changes
DENY ALTER, CONTROL ON DATABASE::HospitalDb TO Role_Patient;
GO

-- Creating a Predicate FUnction to ensure that patients can only see their own records in the Patients tbable
CREATE FUNCTION dbo.fn_securitypredicate_PatientAccess(@UserId_In_Table INT)
RETURNS TABLE
WITH SCHEMABINDING
AS
RETURN SELECT 1 AS fn_securitypredicate_result
WHERE 
    -- Rule A: If the person logged in is a Receptionist, Admin, or Doctor, they see ALL rows
    CAST(SESSION_CONTEXT(N'UserRole') AS NVARCHAR(50)) IN ('Receptionist', 'Hospital_Admin', 'Role_Admin', 'Doctor' , 'Nurse' , 'Pharmacist' )
    OR 
    -- Rule B: If they are a Patient, they ONLY see the row where the Table's UserId matches their Session UserId
    (CAST(SESSION_CONTEXT(N'UserRole') AS NVARCHAR(50)) = 'Patient' 
     AND @UserId_In_Table = CAST(SESSION_CONTEXT(N'UserId') AS INT));
GO
-- Creating a Security Policy to apply The predicate function to the patients table for the Role_Patient , 
Create Security Policy PatientRecordFilterPolicy
Add Filter Predicate dbo.fn_securitypredicate_PatientAccess(UserId) On dbo.Patients
With ( State = ON );
Go

-----------------------------------------------------------------------------------------------------------------------

/*  IT_STAFF ROLE (The Technical and Data Maintainers) */
-- IT Staff usually shouldn't see sensitive medical data (Visits/Diagnosis), 
-- but they need to manage the structure.
GRANT SELECT, INSERT, UPDATE, DELETE ON Specialties TO IT_Staff;
GRANT SELECT, INSERT, UPDATE, DELETE ON DoctorSchedules TO IT_Staff;

-- IT needs to be able to fix login issues in the Staff/Doctor tables
GRANT SELECT, UPDATE ON Doctors TO IT_Staff;
GRANT SELECT, UPDATE ON Staff TO IT_Staff;
GRANT SELECT, INSERT, UPDATE ON Users TO IT_Staff;

-- DQL: Allow them to see metadata (how tables are built)
GRANT VIEW DEFINITION TO IT_Staff;
GRANT SHOWPLAN TO IT_Staff; -- To see query performance

-- DDL: Allow them to maintain indexes and statistics for performance
-- (They can't drop tables, but they can optimize them)
GRANT ALTER ON SCHEMA::dbo TO IT_Staff; 

-- TCL: Allow them to manage locks and transactions
-- Note: In SQL Server, if you can run DML, you can usually use COMMIT/ROLLBACK,
-- but we grant them the right to see active transactions.
GRANT VIEW DATABASE STATE TO IT_Staff;

-- DCL: Allow them to manage roles for OTHER users (but not themselves)
-- This allows them to move a 'Nurse' to 'Receptionist' if they change jobs.
GRANT ALTER ANY ROLE TO IT_Staff;


--  DENIALS (Privacy & Security)
DENY SELECT, INSERT, UPDATE, DELETE ON Patients TO IT_Staff;
DENY SELECT, INSERT, UPDATE, DELETE ON Visits TO IT_Staff;
DENY SELECT, INSERT, UPDATE, DELETE ON Prescriptions TO IT_Staff;
DENY SELECT, INSERT, UPDATE, DELETE ON Bills TO IT_Staff;
GO


----------------------------------------------------------------------------------------------------------------------------------

-- Management Role - Role_Admin
--  Business Oversight
GRANT SELECT ON Patients TO Role_Admin;
GRANT SELECT ON Doctors TO Role_Admin;
GRANT SELECT ON Staff TO Role_Admin;
GRANT SELECT ON Appointments TO Role_Admin;

--  Financial Oversight (The most important part for a Manager)
GRANT SELECT ON Bills TO Role_Admin;
GRANT SELECT ON PaymentTransactions TO Role_Admin;

--  Staffing Control
GRANT INSERT, UPDATE ON Doctors TO Role_Admin;
GRANT INSERT, UPDATE ON Staff TO Role_Admin;
GRANT SELECT, INSERT, UPDATE ON DoctorSchedules TO Role_Admin;

-- DQL: Allow them to run advanced reports
GRANT SELECT ON SCHEMA::dbo TO Role_Admin; 

-- DML: Broad access to fix data across the board
GRANT INSERT, UPDATE, DELETE ON SCHEMA::dbo TO Role_Admin;

-- TCL: Allow them to use Explicit Transactions
-- (Important if they are doing a bulk update in C# and want to rollback on error)
-- This is implicit with DML permissions.

-- DCL: Minimal (They should ask IT to change roles)
-- But we can allow them to VIEW who has what role.
GRANT SELECT ON sys.database_role_members TO Role_Admin;
GRANT SELECT ON sys.database_principals TO Role_Admin;

--  DENIALS (Clinical Privacy & System Integrity)
-- Even the Manager shouldn't see the raw "Visits" (Notes/Diagnosis)
DENY SELECT ON Visits TO Role_Admin;
DENY SELECT ON Prescriptions TO Role_Admin;
-- They manage the hospital, NOT the database users or secret logs
DENY SELECT, INSERT, UPDATE, DELETE ON Users TO Role_Admin;
DENY SELECT ON SystemAuditLogs TO Role_Admin;
GO


---------------------------------------------------------------------------------------------------------------------------

/* PERFORMANCE INDEXES */
-- These happen after the tables are created.
--It creates a hidden, separate data structure (usually a B-Tree).
-- It takes the column you specified (e.g., LastName) and sorts it alphabetically.
-- Next to each name, it stores a pointer ( like a GPS coordinate) to where the full row lives on the hard drive.
-- Con: Writing ( INSERT or UPDATE) becomes a tiny bit slower because every time you add a patient, SQL has to update the hidden index too. This is why we only index columns we search often!

-- Search patients by name (UC-1.3)
CREATE INDEX IX_Patients_Name ON Patients ( LastName, FirstName );

-- Search/Validate patients by contact (UC-1.1)
CREATE UNIQUE INDEX IX_Patients_Contact ON Patients ( ContactNumber);

-- Check doctor availability (UC-3.2)
-- This is called a Filtered Index, which is a special type of index that only includes rows that meet a certain condition. In this case, we are only indexing the rows
-- where IsAvailable = 1, which means the doctor is available. This makes our queries faster when we are looking for available doctors, as the index will be smaller 
-- and more efficient to search through. By including the relevant columns (DoctorId, DayOfWeek, StartTime, EndTime, CurrentNumberOfPatients) in the index, we can 
-- quickly find doctors who are available at a specific time and day, and also check how many patients they currently have scheduled.
CREATE INDEX IX_Schedules_Lookup ON DoctorSchedules ( DoctorId , DayOfWeek , StartTime , EndTime ,CurrentNumberOfPatients , IsAvailable ) WHERE IsAvailable = 1; -- This index will be used to quickly find available doctors for a given day and time, which is a common query when scheduling appointments. By including IsAvailable in the index and filtering on it, we can speed up queries that look for available doctors.

-- Daily Schedule View (UC-3.5)
-- This is called a Covering Index, which is an index that includes all the columns needed to satisfy a specific query, allowing the database to retrieve the results 
-- directly from the index without having to access the main table. In this case, we are indexing the AppointmentDate, PatientId, DoctorId, and StatusOfVisit columns 
-- from the Appointments table. This means that when we run queries to generate daily schedules or manage appointments for a specific date, the database can quickly 
-- retrieve all the necessary information from this index without having to look up each appointment in the main Appointments table, resulting in much faster query 
-- performance for those specific operations.
CREATE INDEX IX_Appointments_Date ON Appointments (AppointmentDate , PatientId, DoctorId ,  StatusOfVisit); -- This index will help in quickly retrieving appointments for a specific date, which is essential for generating daily schedules and managing appointments efficiently.

Create Index IX_Prescrptions_VisitId on Prescriptions ( VisitId , MedicineName ) ; -- This index will help in quickly retrieving prescriptions for a specific visit, which is a common query when doctors or pharmacists need to review or manage prescriptions for a patient. By including MedicineName in the index, we can also speed up queries that search for specific medications prescribed during a visit.

-- Now I will create some Schedule Procedures for the hospital for these operations : Insert, Update and Delete for (now )Patients and Doctors tables
-- Syntax for creating a stored procedure in SQL Server
-- Create Procedure[Name] (@Parameters ) As Begin [Logic] End

Go -- Using Go to seperate the batches of sql as stored procedures should be the first statement in a batch

Create Procedure sp_RegisterPatient
    @FirtName NVARCHAR(100) ,
    @LastName NVARCHAR(100) ,
    @DateOfBirth Date,
    @Gender Varchar (10) ,
    @ContactNumber NVARCHAR (30) ,
    @Email VARCHAR (255) ,
    @AddressOfPatient NVARCHAR (255) ,
    @BloodGroup NVARCHAR (5),
    @IsPatientActive bit
    AS
    BEGIN
         -- Insert statment to add a new patient to the Patients table
         Insert into Patients ( FirstName , LastName , DateOfBirth , ContactNumber , Email , AddressOfPatient , BloodGroup , Gender , IsPatientActive )
         Values ( @FirtName , @LastName , @DateOfBirth , @ContactNumber , @Email , @AddressOfPatient , @BloodGroup , @Gender , @IsPatientActive );

         -- Return the newly generated ID to the application ( C#)  for further use
         Select SCOPE_IDENTITY() AS NewPatientId; -- SCOPE_IDENTITY() is a function that returns the last identity value generated in the current scope, which in this case is the PatientId of the newly inserted patient.
    END;
GO

Go
CREATE PROCEDURE sp_RegisterFullPatient
    @UserName VARCHAR(100),
    @PasswordHash NVARCHAR(255),
    @Salt NVARCHAR(MAX),
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @DOB DATE,
    @Contact NVARCHAR(30),
    @Email VARCHAR(255),
    @Address NVARCHAR(255),
    @Gender Varchar (10) ,
    @BloodGroup NVARCHAR (5) = NULL, -- Set default to NULL
    @IsPatientActive bit = 1 , -- Set default to 1 (Active)
    @NewPatientId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        -- 1. Create the Login Entry
        INSERT INTO Users (UserName, UserPasswordHash, Salt, UserRole)
        VALUES (@UserName, @PasswordHash, @Salt, 'Patient');

        DECLARE @NewUserId INT = SCOPE_IDENTITY();

        -- 2. Create the Patient Profile linked to that User
       Insert into Patients ( FirstName , LastName , DateOfBirth , ContactNumber , Email , AddressOfPatient , BloodGroup , Gender , IsPatientActive , UserId)
        VALUES (@FirstName, @LastName, @DOB, @Contact, @Email, @Address,@BloodGroup, @Gender, @IsPatientActive, @NewUserId);

        -- 3. SET THE OUTPUT PARAMETER for C#
        SET @NewPatientId = SCOPE_IDENTITY();

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW; -- Send the error back to C#
    END CATCH
END
Go




CREATE PROCEDURE sp_RegisterFullDoctor
    -- User Table Params
    @UserName VARCHAR(100),
    @PasswordHash NVARCHAR(255),
    @Salt NVARCHAR(MAX),
    -- Doctor Table Params
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Gender VARCHAR(10),
    @DOB DATE,
    @Contact NVARCHAR(30),
    @Email VARCHAR(255),
    @SpecialtyId INT,
    @ConsultationFee DECIMAL(19,4),
    -- Output
    @NewDoctorId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        -- 1. Create the Login Entry
        INSERT INTO Users (UserName, UserPasswordHash, Salt, UserRole)
        VALUES (@UserName, @PasswordHash, @Salt, 'Doctor');

        DECLARE @NewUserId INT = SCOPE_IDENTITY();

        -- 2. Create the Doctor Profile
        INSERT INTO Doctors (FirstName, LastName, Gender, DateOfBirth, ContactNumber, Email, SpecialtyId, ConsultationFee, UserId, IsActive)
        VALUES (@FirstName, @LastName, @Gender, @DOB, @Contact, @Email, @SpecialtyId, @ConsultationFee, @NewUserId, 1);
        

        SET @NewDoctorId = SCOPE_IDENTITY();

        -- 3. Create a Default Schedule (e.g., Mon-Fri , 9-5)
        -- This ensures the doctor exists in the scheduling system immediately
        INSERT INTO DoctorSchedules (DoctorId, DayOfWeek, StartTime, EndTime, CurrentNumberOfPatients, IsAvailable)
        VALUES (@NewDoctorId, 'Monday', '09:00:00', '17:00:00', 0, 1),
            (@NewDoctorId, 'Tuesday',   '09:00:00', '17:00:00', 0, 1),
            (@NewDoctorId, 'Wednesday', '09:00:00', '17:00:00', 0, 1),
            (@NewDoctorId, 'Thursday',  '09:00:00', '17:00:00', 0, 1),
            (@NewDoctorId, 'Friday',    '09:00:00', '17:00:00', 0, 1);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW; 
    END CATCH
END
GO




CREATE PROCEDURE sp_RegisterStaff
    @UserName VARCHAR(100),
    @PasswordHash NVARCHAR(255),
    @Salt NVARCHAR(MAX),
    @UserRole VARCHAR(100), -- 'Receptionist', 'Nurse', etc.
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Gender VARCHAR(10),
    @DOB DATE,
    @JobTitle NVARCHAR(50), -- Must match  CHECK constraint in Staff table
    @Contact NVARCHAR(30),
    @Email VARCHAR(255),
    @NewStaffId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        -- 1. Create Login
        INSERT INTO Users (UserName, UserPasswordHash, Salt, UserRole)
        VALUES (@UserName, @PasswordHash, @Salt, @UserRole);

        DECLARE @NewUserId INT = SCOPE_IDENTITY();

        -- 2. Create Staff Profile
        INSERT INTO Staff (UserId, FirstName, LastName, Gender, DateOfBirth, JobTitle, ContactNumber, Email, IsActive)
        VALUES (@NewUserId, @FirstName, @LastName, @Gender, @DOB, @JobTitle, @Contact, @Email, 1);

        SET @NewStaffId = SCOPE_IDENTITY();

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

GO
CREATE PROCEDURE sp_RegisterRoleAdmin
    @UserName VARCHAR(100),
    @PasswordHash NVARCHAR(255),
    @Salt NVARCHAR(MAX),
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Gender VARCHAR(10),
    @DOB DATE,
    @Contact NVARCHAR(30),
    @Email VARCHAR(255),
    @AdminSecretKey NVARCHAR(100), -- The key provided by the user
    @SystemSecretKey NVARCHAR(100), -- The actual key to compare against
    @NewAdminId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validate the Secret Key
    IF @AdminSecretKey <> @SystemSecretKey
    BEGIN
        RAISERROR('Invalid Admin Secret Key. Registration Denied.', 16, 1);
        RETURN;
    END

    BEGIN TRANSACTION;
    BEGIN TRY
        -- 1. Create Login in Users Table
        INSERT INTO Users (UserName, UserPasswordHash, Salt, UserRole)
        VALUES (@UserName, @PasswordHash, @Salt, 'Role_Admin');

        DECLARE @NewUserId INT = SCOPE_IDENTITY();

        -- 2. Create Profile in Staff Table (Admin is considered senior staff)
        INSERT INTO Staff (UserId, FirstName, LastName, Gender, DateOfBirth, JobTitle, ContactNumber, Email, IsActive)
        VALUES (@NewUserId, @FirstName, @LastName, @Gender, @DOB, 'Manager', @Contact, @Email, 1);

        SET @NewAdminId = SCOPE_IDENTITY();

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO


CREATE PROCEDURE sp_BookAppointment
    @PatientId INT,
    @DoctorId INT,
    @AppointmentDate DATETIME,
    @Reason NVARCHAR(MAX) -- Matches your AppointmentAudit reason column
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @DayName NVARCHAR(20) = DATENAME(WEEKDAY, @AppointmentDate);

    -- 1. Verify Doctor is actually working that day
    IF NOT EXISTS (SELECT 1 FROM DoctorSchedules WHERE DoctorId = @DoctorId AND DayOfWeek = @DayName AND IsAvailable = 1)
    BEGIN
        RAISERROR('Doctor is not available or scheduled for this day.', 16, 1);
        RETURN;
    END

    BEGIN TRANSACTION;
    BEGIN TRY
        -- 2. Insert Appointment (Matches your StatusOfVisit column)
        INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, StatusOfVisit, CreatedAt)
        VALUES (@PatientId, @DoctorId, @AppointmentDate, 'Scheduled', GETDATE());

        DECLARE @NewApptId INT = SCOPE_IDENTITY();

        -- 3. Update Schedule (The CHECK constraint in your table will automatically 
        -- throw an error if CurrentNumberOfPatients > 20)
        UPDATE DoctorSchedules
        SET CurrentNumberOfPatients = CurrentNumberOfPatients + 1
        WHERE DoctorId = @DoctorId AND DayOfWeek = @DayName;

        -- 4. Log to AppointmentAudit (Matches your table)
        INSERT INTO AppointmentAudit (AppointmentId, ActionPerformed, ActionDate, Reason)
        VALUES (@NewApptId, 'Created', GETDATE(), @Reason);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        -- This will catch the "CurrentNumberOfPatients <= 20" constraint violation
        DECLARE @ErrMsg NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrMsg, 16, 1);
    END CATCH
END






GO
CREATE PROCEDURE sp_ValidateLogin
    @UserName VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    -- We return everything needed to verify the password in C# 
    -- and identify the user in the session.
    SELECT UserId, UserPasswordHash, Salt, UserRole 
    FROM Users 
    WHERE UserName = @UserName;
END
GO


CREATE PROCEDURE sp_GetUserLoginCredentials
(
    @UserName NVARCHAR(100),
    @UserRole  VARCHAR(100)
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        UserId,
        UserPasswordHash,
        Salt
    FROM Users
    WHERE
        UserName = @UserName
        AND UserRole = @UserRole;
END
GO


CREATE PROCEDURE sp_GetAuditLogs
AS
BEGIN
    -- Check if the person calling this is an Admin
    IF IS_ROLEMEMBER('Hospital_Admin') = 1
    BEGIN
        SELECT * FROM SystemAuditLogs;
    END
    ELSE
    BEGIN
        RAISERROR('Access Denied: You do not have permission to view Audit Logs.', 16, 1);
    END
END;

GO
CREATE TRIGGER trg_AuditPatients
ON Patients
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON; -- Prevents extra rows affected messages from interfering with C#

    DECLARE @ActionType VARCHAR(10);
    DECLARE @RecordId INT;
    Declare @UserId Int = Cast ( Session_Context(N'UserId') As Int) ;

    -- 1. Determine the Action Type
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
        SET @ActionType = 'Update';
    ELSE IF EXISTS (SELECT * FROM inserted)
        SET @ActionType = 'Insert';
    ELSE
        SET @ActionType = 'Delete';

    -- 2. Log the change
    INSERT INTO SystemAuditLogs (TableName, ActionType, RecordId, UserId, ActionDate, OldValue, NewValue)
    SELECT 
        'Patients',
        @ActionType,
        COALESCE(i.PatientId, d.PatientId), -- Get ID from whichever table has it
        @UserId,
        GETDATE(),
        -- Use FOR JSON PATH to turn the whole row into a string (Requires SQL 2016+)
        (SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER), 
        (SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
    FROM inserted i
    FULL OUTER JOIN deleted d ON i.PatientId = d.PatientId;
END;
GO
/*  
This is to remind myself for how to set the session context in C# after the user logs in, so that the triggers can capture the 
UserId for auditing purposes. This code snippet should be executed right after the user successfully logs in and I have their 
UserId available in my C# application.

string setContext = "EXEC sp_set_session_context @key = N'UserId', @value = @uid;";
using (SqlCommand cmd = new SqlCommand(setContext, connection))
{
    cmd.Parameters.AddWithValue("@uid", loggedInUserId); // The ID from your login screen
    cmd.ExecuteNonQuery();
}
// Now, any trigger that runs on this connection will know who did it!
*/

GO
Create Trigger trg_AuditDoctors
On Doctors
After Insert , Update , DELETE
AS
BEGIN
    Set NOCOUNT ON ;
    Declare @ActionType Varchar (10) ;
    Declare @RecordId int ;
    Declare @UserId int = Cast(Session_Context(N'UserId') As Int) ;
    IF EXISTS  (Select * from inserted ) And Exists ( Select * from deleted )
        Set @ActionType = 'Update';
    Else If Exists ( Select * from inserted )
        Set @ActionType = 'Insert' ;
    Else Set @ActionType = 'Delete';
    Insert Into SystemAuditLogs ( TableName , ActionType , RecordId , UserId , ActionDate , OldValue , NewValue )
    Select
         'Doctors',
         @ActionType,
         Coalesce ( i.DoctorId , d.DoctorId ) ,
         @UserId,
        GetDate() ,
        (Select d.* for Json Path , Without_Array_Wrapper) ,
        ( Select i.* for Json Path , Without_Array_Wrapper ) 
    From inserted i
    FULL Outer Join deleted d  on i.DoctorId = d.DoctorId ;
END
Go



GO
CREATE TRIGGER trg_AuditDoctorSchedules
ON DoctorSchedules
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @ActionType VARCHAR(10);
    DECLARE @UserId INT = CAST(SESSION_CONTEXT(N'UserId') AS INT);
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
        SET @ActionType = 'Update';
    ELSE IF EXISTS (SELECT * FROM inserted)
        SET @ActionType = 'Insert';
    ELSE
        SET @ActionType = 'Delete';
    INSERT INTO SystemAuditLogs (TableName, ActionType, RecordId, UserId, ActionDate, OldValue, NewValue)
    SELECT 
        'DoctorSchedules',
        @ActionType,
        COALESCE(i.ScheduleId, d.ScheduleId),
        @UserId, 
        GETDATE(),
        (SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER), 
        (SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
    FROM inserted i
    FULL OUTER JOIN deleted d ON i.ScheduleId = d.ScheduleId;
END;
GO



GO
Create Trigger trg_AuditStaff
on Staff
After Insert , Update , DELETE
AS
Begin
     Set NOCOUNT ON ;
     dECLARE @ActionType Varchar (10) ;
     Declare @RecordId int ;
     Declare @UserId int = Cast (Session_COntext (N'UserId') As Int ) ;
     If Exists ( Select * from inserted ) and Exists ( Select * from deleted ) 
        Set @ActionType = 'Update' ;
    Else If Exists ( Select * from inserted ) 
        Set @ActionType = 'Insert';
    Else set @ActionType = 'Deleted';
    Insert into SystemAuditLogs ( TableName , ActionType , RecordId , UserId , ActionDate , OldValue , NewValue )
    SELECT
        'Staff',
        @ActionType ,
        Coalesce ( i.StaffId , d.StaffId ) ,
        @UserId ,
        GetDate(),
        (Select d.*for Json Path , Without_Array_Wrapper ),
        ( Select i.* for Json Path , Without_Array_Wrapper )
      From inserted i Full Outer Join deleted d on i.StaffId = d.StaffId ;
END
GO


GO

CREATE TRIGGER trg_AuditAppointments
ON Appointments
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @ActionType VARCHAR(10);
    DECLARE @UserId INT = CAST(SESSION_CONTEXT(N'UserId') AS INT);
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
        SET @ActionType = 'Update';
    ELSE IF EXISTS (SELECT * FROM inserted)
        SET @ActionType = 'Insert';
    ELSE
        SET @ActionType = 'Delete';
    INSERT INTO SystemAuditLogs (TableName, ActionType, RecordId, UserId, ActionDate, OldValue, NewValue)
    SELECT 
        'Appointments',
        @ActionType,
        COALESCE(i.AppointmentId, d.AppointmentId),
        @UserId,
        GETDATE(),
        (SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER), 
        (SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
    FROM inserted i
    FULL OUTER JOIN deleted d ON i.AppointmentId = d.AppointmentId;
END
Go

GO
CREATE TRIGGER trg_AuditAppointmentAudit
ON AppointmentAudit
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @ActionType VARCHAR(10);
    DECLARE @UserId INT = CAST(SESSION_CONTEXT(N'UserId') AS INT);
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
        SET @ActionType = 'Update';
    ELSE IF EXISTS (SELECT * FROM inserted)
        SET @ActionType = 'Insert';
    ELSE
        SET @ActionType = 'Delete';
    INSERT INTO SystemAuditLogs (TableName, ActionType, RecordId, UserId, ActionDate, OldValue, NewValue)
    SELECT 
        'AppointmentAudit',
        @ActionType,
        COALESCE(i.AuditId, d.AuditId),
        @UserId, 
        GETDATE(),
        (SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER), 
        (SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
    FROM inserted i
    FULL OUTER JOIN deleted d ON i.AuditId = d.AuditId;
END
GO


GO
Create Trigger trg_AduitSpecialties
on Specialties
After Insert , Update , DELETE
As
BEGIN
     Set NOCOUNT ON ;
     Declare @ActionType Varchar (10) ;
     Declare @UserId int = Cast ( Session_Context(N'UserId') As Int) ;
     If Exists ( Select * from inserted ) ANd Exists ( Select * from deleted )
           Set @ActionType = 'Update';
     ELse If Exists ( Select * from inserted)
         Set @ActionType = 'Insert';
     Else Set @ActionType = 'Delete';

     Insert Into SystemAuditLogs ( TableName , ActionType , RecordId , UserId , ActionDate , OldValue , NewValue )
     Select
          'Specialties',
          @ActionType,
          Coalesce (i.SpecialtyId , d.SpecialtyId),
          @UserId ,
          GetDate() ,
          (Select d.* for Json Path , Without_Array_Wrapper),
          (Select i.* for Json Path , Without_Array_Wrapper )
        From inserted i 
        Full Outer Join deleted d on i.SpecialtyId = d.SpecialtyId ;
END
Go


GO
Create Trigger trg_AuditUsers
On Users
After Insert , Update , DELETE
AS
BEGIN
     Set NOCOUNT ON ;
     Declare @ActionType Varchar (10) ;
     Declare @UserId int = Cast( Session_Context(N'UserId') As int);
     if Exists ( Select * from inserted ) and exists ( select * from deleted)
        Set @ActionType = 'Update';
     Else if exists ( select * from inserted )
          Set @ActionType = 'Insert';
     Else Set @ActionType = 'Delete';
     Insert into SystemAuditLogs ( TableName , ActionType , RecordId , UserId , ActionDate , OldValue , NewValue )
     Select
          'Users',
          @ActionType,
          Coalesce (i.UserId , d.UserId),
          @UserId ,
          GetDate(),
          (Select d.* for Json Path , Without_Array_Wrapper),
          (Select i.* for Json Path , Without_Array_Wrapper)
        From inserted i Full Outer Join deleted d on i.UserId = d.UserId ;

END
Go


GO
Create Trigger trg_AuditPrescriptions
On Prescriptions
After Insert , Update , DELETE
AS
BEGIN
     Set NOCOUNT ON ;
     Declare @ActionType Varchar (10) ;
    DECLARE @UserId INT = CAST(SESSION_CONTEXT(N'UserId') AS INT);
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
        SET @ActionType = 'Update';
    ELSE IF EXISTS (SELECT * FROM inserted)
        SET @ActionType = 'Insert';
    ELSE
        SET @ActionType = 'Delete';
    INSERT INTO SystemAuditLogs (TableName, ActionType, RecordId, UserId, ActionDate, OldValue, NewValue)
    SELECT 
        'Prescriptions',
        @ActionType,
        COALESCE(i.PrescriptionId, d.PrescriptionId),
        @UserId,
        GETDATE(),
        (SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER), 
        (SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
    FROM inserted i
    FULL OUTER JOIN deleted d ON i.PrescriptionId = d.PrescriptionId;
END;
GO

GO

CREATE TRIGGER trg_AuditBills
ON Bills
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @ActionType VARCHAR(10);
    DECLARE @UserId INT = CAST(SESSION_CONTEXT(N'UserId') AS INT);
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
        SET @ActionType = 'Update';
    ELSE IF EXISTS (SELECT * FROM inserted)
        SET @ActionType = 'Insert';
    ELSE
        SET @ActionType = 'Delete';
    INSERT INTO SystemAuditLogs (TableName, ActionType, RecordId, UserId, ActionDate, OldValue, NewValue)
    SELECT 
        'Bills',
        @ActionType,
        COALESCE(i.BillId, d.BillId),
        @UserId, 
        GETDATE(),
        (SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER), 
        (SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
    FROM inserted i
    FULL OUTER JOIN deleted d ON i.BillId = d.BillId;
END;
GO

GO
CREATE TRIGGER trg_AuditElevatedSessions
ON ElevatedSessions
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @ActionType VARCHAR(10);
    DECLARE @UserId INT = CAST(SESSION_CONTEXT(N'UserId') AS INT);
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
        SET @ActionType = 'Update';
    ELSE IF EXISTS (SELECT * FROM inserted)
        SET @ActionType = 'Insert';
    ELSE
        SET @ActionType = 'Delete';
    INSERT INTO SystemAuditLogs (TableName, ActionType, RecordId, UserId, ActionDate, OldValue, NewValue)
    SELECT 
        'ElevatedSessions',
        @ActionType,
        COALESCE(i.UserId, d.UserId),
       @UserId, 
        GETDATE(),
        (SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER), 
        (SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
    FROM inserted i
    FULL OUTER JOIN deleted d ON i.UserId = d.UserId;
END;
GO

GO
CREATE TRIGGER trg_AuditPaymentTransactions
ON PaymentTransactions
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @ActionType VARCHAR(10);
    DECLARE @UserId INT = CAST(SESSION_CONTEXT(N'UserId') AS INT);
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
        SET @ActionType = 'Update';
    ELSE IF EXISTS (SELECT * FROM inserted)
        SET @ActionType = 'Insert';
    ELSE
        SET @ActionType = 'Delete';
    INSERT INTO SystemAuditLogs (TableName, ActionType, RecordId, UserId, ActionDate, OldValue, NewValue)
    SELECT 
        'PaymentTransactions',
        @ActionType,
        COALESCE(i.TransactionId, d.TransactionId),
      @UserId, 
        GETDATE(),
        (SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER), 
        (SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
    FROM inserted i
    FULL OUTER JOIN deleted d ON i.TransactionId = d.TransactionId;
END
GO

GO

CREATE TRIGGER trg_AuditVisits
ON Visits
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @ActionType VARCHAR(10);
    DECLARE @UserId INT = CAST(SESSION_CONTEXT(N'UserId') AS INT);
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
        SET @ActionType = 'Update';
    ELSE IF EXISTS (SELECT * FROM inserted)
        SET @ActionType = 'Insert';
    ELSE
        SET @ActionType = 'Delete';
    INSERT INTO SystemAuditLogs (TableName, ActionType, RecordId, UserId, ActionDate, OldValue, NewValue)
    SELECT 
        'Visits',
        @ActionType,
        COALESCE(i.VisitId, d.VisitId),
        @UserId, 
        GETDATE(),
        (SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER), 
        (SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
    FROM inserted i
    FULL OUTER JOIN deleted d ON i.VisitId = d.VisitId;
END;
Go

GO
Create Trigger trg_AduitSystemAuditLogs
on SystemAuditLogs
After Update , DELETE
AS
BEGIN
    Set NoCount ON ;
    Declare @ActionType Varchar (10) ;
    Declare @UserId int = Cast ( Session_COntext(N'UserId') As Int) ;
    If Exists ( Select * from inserted ) and exists ( Select * from deleted)
        Set @ActionType = 'Update';
    Else If Exists ( Select * from inserted) 
        Set @ActionType = 'Insert';
    ELSE Set @ActionType = 'Delete';
    Insert Into SystemAuditLogs ( TableName , ActionType , RecordId , UserId , ActionDate , OldValue , NewValue )
    SELECT
          'SystemAuditLogs',
          @ActionType,
          Coalesce (i.LogId , d.LogId),
          @UserId ,
          GetDate(),
          (Select d.* for Json Path , Without_Array_Wrapper),
          ( Select i.* for Json Path , WIthout_Array_Wrapper)
        From inserted i Full Outer Join deleted d on i.LogId = d.LogId ;
END
Go

GO
Create Trigger trg_CaptureDDLChanges
On Database
For DDL_TABLE_EVENTS -- This covers CREATE, ALTER, DROP, and TRUNCATE
AS
BEGIN
     Set NOCOUNT ON ;
     Declare @Event  XML = EventData() ;
     Declare @ActionType Varchar (100) ;
     DECLARE @TargetTable VARCHAR(100);
     Declare @UserId int =  CAST (  SESSION_CONTEXT ( N'UserId') AS INT) ;
     
     -- Extracting Deatils from event data and storing them in variables
     Set @ActionType = @Event.value('(/EVENT_INSTANCE/EventType)[1]' , 'NVARCHAR(100)');
     SET @TargetTable = @Event.value('(/EVENT_INSTANCE/ObjectName)[1]', 'NVARCHAR(100)');
     /*
       Note: For DDL events like TRUNCATE/DROP/ALTER, there is no "RecordId",
       OldValue, or NewValue because these operations affect entire tables,
       not individual rows. I’ll store RecordId as 0 ,
       and leave OldValue/NewValue as NULL.
    */
    -- SAFETY RAIL : If someone tries to DROP or TRUNCATE the audit log itself
    IF @TargetTable = 'SystemAuditLogs' AND @ActionType IN ('DROP_TABLE', 'TRUNCATE_TABLE')
    BEGIN
        PRINT 'Critical Error: SystemAuditLogs cannot be dropped or truncated without disabling this trigger.';
        ROLLBACK ; -- This if to undo the command completely.
    END
    ELSE
    BEGIN
    Insert Into SystemAuditLogs( TableName , ActionType , RecordId , UserId , ActionDate , OldValue , NewValue )
    Values (  
         @TargetTable,
         @ActionType,
         0, -- entire table was affected, so no specific record
         @UserId,
         GetDate(),
         @Event.value('(/EVENT_INSTANCE/TSQLCommand/CommandText)[1]', 'NVARCHAR(MAX)'), -- Storing the actual SQL command used
         NULL 
    ); -- No new value for DDL events
    END
END
Go




-- Instead of letting anyone query the table directly, 
-- I will create a View and only give the Admin access to that view
CREATE VIEW vw_AdminAuditPortal AS
SELECT 
    l.LogId, 
    u.UserName, 
    l.TableName, 
    l.ActionType, 
    l.ActionDate, 
    l.OldValue, 
    l.NewValue,
    l.RecordId
FROM SystemAuditLogs l
JOIN Users u ON l.UserId = u.UserId;
GO

-- Only IT Admins get to see this view
GRANT SELECT ON vw_AdminAuditPortal TO Hospital_Admin , IT_Staff ;
GRANT SELECT, INSERT, UPDATE, DELETE ON Users TO IT_Staff;





GO
CREATE PROCEDURE dbo.usp_ExecuteSystemSync
    @SecretKey NVARCHAR(50),
    @Reason NVARCHAR(255)
WITH EXECUTE AS OWNER -- Gives the procedure power to change roles
AS
BEGIN
    SET NOCOUNT ON;

    --  Checking if the user has the Secret entrance role
    IF IS_ROLEMEMBER('System_Internal_Sync') = 0
    BEGIN
        RAISERROR('Critical Error: System Link 404.', 16, 1);
        RETURN;
    END

    --  Checking the Secret Key (Hashed)
    -- This hash is for the password : 'MyHospitalSecret2026'
    -- Later I  can generate a new one in C# using SHA512
    IF HASHBYTES('SHA2_512', @SecretKey) = 0x51737E5528256F8C9822765A79F5E364A042B59114D6D298E7072E27B13F101A6184E1A9D490E00000B0253457A3C5B56EBAF30E14B700C22E1568F3F1929960
    BEGIN
        DECLARE @UID INT = CAST(SESSION_CONTEXT(N'UserId') AS INT);
        DECLARE @User NVARCHAR(128) = USER_NAME();


         -- Log this critical action in the SystemAuditLogs for traceability
        INSERT INTO SystemAuditLogs (UserId, TableName, ActionType, ActionDate, OldValue, NewValue, RecordId)
        VALUES (@UID, 'System', 'Elevated Permissions', GETDATE(), NULL, 'System Sync Activated - Reason: ' + @Reason, 0);

        -- Add user to the God Role
        EXEC sp_addrolemember 'Hospital_Admin', @User;

        -- 2. Set the Time Bomb (Current Time + 5 Minutes)
        IF EXISTS (SELECT 1 FROM dbo.ElevatedSessions WHERE UserId = @UID)
            UPDATE dbo.ElevatedSessions SET ExpiryTime = DATEADD(minute, 5, GETDATE()) WHERE UserId = @UID;
        ELSE
            INSERT INTO dbo.ElevatedSessions (UserId, ExpiryTime) VALUES (@UID, DATEADD(minute, 5, GETDATE()));
        
        PRINT 'Administrative Sync Successful. Permissions Elevated.';
        PRINT 'God Mode activated. You have 5 minutes.';
    END
    ELSE
    BEGIN
        PRINT 'Command completed Successfully.'; -- This is a decoy message to avoid giving away the existence of the secret key or the gatekeeper procedure to unauthorized users.
    END
END;
GO



GO

-- This is the ONLY new SQL object needed to make the "Promote" feature work.
CREATE PROCEDURE usp_PromoteStaff
    @TargetStaffId INT,
    @NewRole VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @TargetUserId INT;

    -- 1. Find the UserID linked to this StaffID
    SELECT @TargetUserId = UserId FROM Staff WHERE StaffId = @TargetStaffId;

    IF @TargetUserId IS NULL
    BEGIN
        ; THROW 50001, 'Staff member not found.', 1; -- semicolon before Throw as T-Sql's parser is a bit pickier.
        -- If the statement immediately before it doesn't end in a semicolon, the parser tries to "read through" 
        -- the THROW and interprets it as an argument for the previous command (like TRANSACTION). 
    END

    -- 2. Validate the Role (Prevent Manager from creating another God/Secret Admin)
    IF @NewRole IN ('Hospital_Admin', 'System_Internal_Sync', 'System_Sync')
    BEGIN
        ; THROW 50002, 'Security Violation: You cannot promote to this restricted role.', 1;
    END

    BEGIN TRANSACTION ; -- End this statement with a semicolon
    Begin TRY
        -- A. Update the User Login Role (The security ticket)
        UPDATE Users SET UserRole = @NewRole WHERE UserId = @TargetUserId;

        -- B. Update the Staff Job Title (The HR title)
        UPDATE Staff SET JobTitle = @NewRole WHERE StaffId = @TargetStaffId;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- Grant the Manager permission to use this specific tool
GRANT EXECUTE ON usp_PromoteStaff TO Role_Admin;

-- Grant Manager permission to manage schedules (as requested in menu option 4)
GRANT INSERT, UPDATE ON DoctorSchedules TO Role_Admin;
GO



-- =============================================
-- Now Distributing the Permissions
-- =============================================

-- Give the Secret role permission to use the gate
GRANT EXECUTE ON dbo.usp_ExecuteSystemSync TO System_Internal_Sync;

-- Hospital_Admin gets CONTROL ( The God Power to do anything in the system, including granting permissions to others)
GRANT CONTROL TO Hospital_Admin;


Go
CREATE PROCEDURE dbo.usp_CheckSecurityStatus
AS
BEGIN
    SET NOCOUNT ON; -- Prevents "rows affected" messages from breaking C# logic

    DECLARE @UID INT = CAST(SESSION_CONTEXT(N'UserId') AS INT);
    DECLARE @Expiry DATETIME;

    SELECT @Expiry = ExpiryTime FROM dbo.ElevatedSessions WHERE UserId = @UID;

    -- If the time has passed, strip the role
    IF @Expiry IS NOT NULL AND GETDATE() > @Expiry
    BEGIN
        -- Log the auto-revocation before stripping the role
        INSERT INTO SystemAuditLogs (UserId, TableName, ActionType, ActionDate, OldValue, NewValue, RecordId)
        VALUES (@UID, 'Security', 'Auto-Revoke', GETDATE(), 'Hospital_Admin', 'Timer Expired', 0);

        -- sp_droprolemember is a stored procedure, use EXEC
        DECLARE @User NVARCHAR(128) = USER_NAME();
        EXEC sp_droprolemember 'Hospital_Admin', @User;
        DELETE FROM dbo.ElevatedSessions WHERE UserId = @UID;
        
        RAISERROR('Security Session Expired. Access Revoked.', 16, 1);
    END
END
GO

/*
For me to remember to implement this in the c# backend 

public void ExecuteAdminTask()
{
    using (SqlConnection conn = new SqlConnection(yourConnectionString))
    {
        conn.Open();
        
        // Always run the security check before sensitive tasks
        SqlCommand checkCmd = new SqlCommand("EXEC dbo.usp_CheckSecurityStatus", conn);
        
        try 
        {
            checkCmd.ExecuteNonQuery();
            
            // If we get here, the user is still valid or isn't in God Mode
            Console.WriteLine("Executing sensitive hospital operation...");
        }
        catch (SqlException ex)
        {
            // This catches the RAISERROR if the 5 minutes are up
            Console.WriteLine($"ALERT: {ex.Message}");
        }
    }
}
*/

-- If an unauthorized attempt is made to access elevation procedure,
CREATE PROCEDURE dbo.usp_SystemLockdown
    @NewGhostPassword NVARCHAR(255)
AS
BEGIN
    -- 1. Rotate the password for the gatekeeper user
    UPDATE Users 
    SET UserPasswordHash = @NewGhostPassword -- The hash of the stego-hidden password
    WHERE UserRole = 'System_Sync';

    -- 2. Clear all current elevated sessions
    DELETE FROM dbo.ElevatedSessions;

    -- 3. Log the lockdown event
    INSERT INTO SystemAuditLogs (TableName, ActionType, NewValue, UserId)
    VALUES ('SYSTEM_SECURITY', 'LOCKDOWN', 'Manual lockdown triggered - unauthorized access attempt.', 0);
END;
GO


--Now adding some obfuscation and stripping away unnecessary powers i might have granted to some roles of IT and manangers
--  Strip all direct access from IT and other roles
REVOKE SELECT, INSERT, UPDATE, DELETE ON Users FROM IT_Staff;
REVOKE SELECT, INSERT, UPDATE, DELETE ON Users FROM Role_Admin;

-- Create a "Safe" View for Management
-- This view hides the Hash, the Salt, and my Secret Roles
GO
CREATE VIEW vw_StaffManagement AS
SELECT 
    UserId, 
    UserName, 
    UserRole
FROM Users
WHERE UserRole NOT IN ('Hospital_Admin', 'System_Sync'); -- Hide the Power - Secret roles entirely
GO

--  Give IT and managers access only to this filtered view
GRANT SELECT ON vw_StaffManagement TO IT_Staff;
GRANT SELECT ON vw_StaffManagement TO Role_Admin;
Go

GO
Create View vw_StaffActivityLog AS
SELECT
    l.LogId,
    u.UserName,
    l.TableName,
    l.ActionType,
    l.ActionDate,
    l.OldValue,
    l.NewValue,
    l.RecordId
From SystemAuditLogs l
Join Users u On l.UserId = u.UserId
Where u.UserRole Not in ('Hospital_Admin', 'System_Sync')-- Hide the Power - Secret roles entirely
And l.NewValue Not LIKE '%Hospital_Admin%' -- Hide any changes related to the Admin role
And l.NewValue Not LIKE '%System_Sync%'; -- Hide any changes related to the Secret role
Go

Grant Select On vw_StaffActivityLog To IT_Staff ;
Grant Select On vw_StaffActivityLog To Role_Admin ;

Deny Select On SystemAuditLogs To IT_Staff ;
Deny Select On SystemAuditLogs To Role_Admin ;
Go
-- Protect the "God Mode" mechanism from the new broad permissions
DENY SELECT, ALTER ON dbo.ElevatedSessions TO IT_Staff;
DENY SELECT, ALTER ON dbo.Users TO IT_Staff;
DENY SELECT, ALTER ON dbo.SystemAuditLogs TO IT_Staff;

-- Prevent them from messing with your Secret Procedures
DENY ALTER ON dbo.usp_ExecuteSystemSync TO IT_Staff;
DENY ALTER ON dbo.usp_CheckSecurityStatus TO IT_Staff;
GO
-- Protect the "God Mode" mechanism from the new broad permissions
DENY SELECT, ALTER ON dbo.ElevatedSessions TO  Role_Admin;
DENY SELECT, ALTER ON dbo.Users TO  Role_Admin;
DENY SELECT, ALTER ON dbo.SystemAuditLogs TO  Role_Admin;
DENY SELECT ON ElevatedSessions TO Role_Admin;

-- Prevent them from messing with your Secret Procedures
DENY ALTER ON dbo.usp_ExecuteSystemSync TO  Role_Admin;
DENY ALTER ON dbo.usp_CheckSecurityStatus TO  Role_Admin;
GO