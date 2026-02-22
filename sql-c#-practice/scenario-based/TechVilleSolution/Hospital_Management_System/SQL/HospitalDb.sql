USE master;
GO

--  Kick everyone out and roll back their unfinished work ( just for testing and development purposes , not for production environment)
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'HospitalDb')
BEGIN
    Alter DATABASE HospitalDb Set Single_User With Rollback Immediate ;
    DROP DATABASE HospitalDb;
END
GO

-- Creating the database
Create database HospitalDb;
GO

USE HospitalDb;
GO
-- Creating the tables
-- Adminstration Tables for the Hospital
-- These tables hold data that doesn't change often but is used by other tables

Create Table Specialties(
    SpecialtyId int PRIMARY KEY IDENTITY(1,1),
    SpecialtyName VARCHAR(100) NOT NULL -- Not using Nvarchar since we don't expect to store Unicode characters in specialty names, as every name will be in english itself
);
-- This table is created so that instead of typing Cardiology 50 times, I type it once here and link to it

Create Table Users(
    UserId int PRIMARY KEY IDENTITY(1,1) ,
    UserName Varchar (100) NOT NULL ,
    UserPasswordHash NVARCHAR(255) NOT NULL , -- Because hash if not in hexadecimal format, it can contain unicode characters, so I use NVARCHAR. 
    Salt NVARCHAR(MAX) NOT NULL, -- My c# code from backend will generate it .
    UserRole VARCHAR (100) NOT NULL Check (UserRole In ('Hospital_Admin', 'Role_Admin' , 'IT_Staff', 'Doctor', 'Nurse', 'Receptionist', 'Pharmacist', 'Patient' , 'System_Sync'))
);

Go
-- Now Let me create some roles for the hospital that is going to be in this table users
Create Role Hospital_Admin ; -- Hospital Owner and Super Admin who has access to everything in the system and can manage all aspects of the hospital operations, including staff, patients, appointments, financials, and system settings. This role is typically assigned to the  owner who oversees and owns the entire hospital administration and operations.
Create Role IT_Staff ; -- For system administrators who will manage the database and the system
Create Role Role_Admin;        -- Hospital Manager
Create Role Role_Medical;      -- Doctors,  Nurses and Pharmacists ( Pharmacists will be a sub role under the Role_Medical)
Create Role Role_FrontDesk;    -- Receptionists
Create Role Role_Patient;     -- Patients and their family members who have access to the system to check their medical records and appointments
Go


-- =============================================
-- STEP 1: Creatig the Secret Elevation Role
-- =============================================

-- The 'God' Role (Currently empty)
-- I already have 'Hospital_Admin' in my script, so I use that.

-- The 'Secret' Role ( The only one that can run the unlock procedure )
CREATE ROLE System_Internal_Sync; -- Boring name to hide from IT , as it is essentially the GateKeeper role that is a secret.
GO


-- Now let me create the core profiles for the hospital
Create Table Doctors(
    DoctorId int PRIMARY KEY IDENTITY(1,1) ,
    FirstName NVARCHAR(100) NOT NULL , --I am using Nvarchar as the names from non-english regions can contain unicode characters as well , so I need to support that
    LastName NVARCHAR(100) NOT NULL ,
    Gender Varchar (10) Not Null Check ( Gender in ( 'Male' , 'Female' , 'Other' ) ) ,
    DateOfBirth Date Not Null Default GetDate(), -- Defaulting to current date for testing purposes, but in real application it should be provided by the user and should not default to current date as it can lead to incorrect data if not provided by the user
    ContactNumber Nvarchar (30) Not Null Unique , -- Contact numbers of two doctors can't be same and can't be null and  keeping length as 30 to accommodate international numbers with country codes and extensions, which can be longer than standard 10-digit numbers. Also, I am using Nvarchar because some contact numbers may include special characters like + ,- for country codes or '-' for extensions, which may require Unicode support.
    Email varchar (255) Not Null , -- Keeping email as varchar of 255 characters, as email addresses can contain a wide range of characters but typically do not require Unicode support and also in general there is a standard of 30 characters ( before @gemail.com ) for email addresses, but I am giving it a bit more room just in case
    SpecialtyId int NOT NULL Foreign Key References Specialties ( SpecialtyId ) ,
    ConsultationFee decimal(19,4) Check ( ConsultationFee >= 0 ) Not Null , -- Fee can't be negative  or null . and it could go in decimal places as well .
    -- Here if i left only decimal then it would have default to decimal (18,0) and thus it would not be storing any decimal places values . Also not using Money itself as it is infamous for introducing rounding errors in financial calcualtions
    --So using instead decimal with a high precision and using 19 , 4 , which is considered as a standard for financial apps . as even Ms SQL Server's built-in Money type has a precision of 19 and scale of 4 though it introduces rounding errors and portabilty issues.
    IsActive bit  Default 1 Not Null , -- This column is used to mark whether the doctor is currently active or not. By default, it is set to 1 (active) when a new doctor is added. This allows us to keep the record of doctors who are no longer active without deleting their data, which can be important for historical records and reporting.and keeping it not null makes sure that bit doesn't bring null values to the table which can cause issues in queries and data integrity
    UserId int Unique Not NULL Foreign Key References Users(UserId) -- So that each doctor has a unique user account to log in to the system, and this also allows us to link the doctor's profile with their login credentials for authentication and authorization purposes. By making it Unique, we ensure that one user account can only be associated with one doctor, which helps maintain data integrity and security in the system.
);

Create Table DoctorSchedules (
    ScheduleId int Primary Key Identity(1,1),
    DoctorId int Not Null Foreign Key References Doctors(DoctorId),
    DayOfWeek varchar(10) Not Null Check (DayOfWeek in ('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday')),
    StartTime Time Not Null DEFAULT '09:00:00',
    EndTime Time Not Null DEFAULT '17:00:00',
    -- Start at 0, and we use C# to check if it hits 20
    CurrentNumberOfPatients int NOT NULL DEFAULT 0 CHECK (CurrentNumberOfPatients >= 0 AND CurrentNumberOfPatients <= 20), -- Capacity of patients per day for a doctor is 20, which is a reasonable limit to ensure quality of care and manageability. This constraint helps prevent overbooking and ensures that doctors can provide adequate attention to each patient.
    IsAvailable bit Default 1 -- For holidays/days off
);

-- For non-doctor staff like receptionists, nurses, pharmacists, and IT support who also need to log in to the system but
-- don't have the same scheduling and appointment management needs as doctors. 
--This table allows us to store their profiles and link them to their user accounts for authentication and authorization purposes, 
-- while keeping their specific job roles and contact information organized.
Create Table Staff (
    StaffId int Primary Key Identity(1,1),
    UserId int Not Null Foreign Key References Users(UserId), -- LINK TO LOGIN CREDENTIALS
    FirstName NVARCHAR(100) Not Null,
    LastName NVARCHAR(100) Not Null,
    Gender Varchar (10) Not Null Check ( Gender in ( 'Male' , 'Female' , 'Other' ) ) ,
    DateOfBirth Date Not Null Default GetDate(), -- Defaulting to current date for testing purposes, but in real application it should be provided by the user and should not default to current date as it can lead to incorrect data if not provided by the user
    JobTitle NVARCHAR(50) Not Null Check (JobTitle IN ('Nurse', 'Receptionist', 'Pharmacist', 'IT_Staff' , 'Manager' ,'Hospital_Admin' , 'System_Sync', 'Other')),
    ContactNumber NVARCHAR(30) Not Null,
    Email VARCHAR(255) Not Null,
    IsActive bit Default 1
);

Create Table Patients (
    PatientId int Primary Key Identity (1,1) ,
    FirstName NVARCHAR (100) Not Null ,
    LastName NVARCHAR (100) Not Null ,
    DateOfBirth Date Not Null Default GetDate() , -- Defaulting to current date for testing purposes, but in real application it should be provided by the user and should not default to current date as it can lead to incorrect data if not provided by the user
    Gender Varchar (10) Not Null Check (Gender in ('Male', 'Female', 'Other')),
    ContactNumber Nvarchar (30) NOT NULL Unique ,
    Email Varchar (255) Not Null ,
    AddressOfPatient Nvarchar (255) Not Null ,
    BloodGroup Nvarchar (5) NULL , -- as I may not have data of Patient's blood group initially
    IsPatientActive bit Default 1 Not Null, -- This column is used to mark whether the patient is currently active or not. By default, it is set to 1 (active) when a new patient is added. This allows us to keep the record of patients who are no longer active without deleting their data, which can be important for historical records and reporting. Keeping it not null ensures that bit doesn't bring null values to the table which can cause issues in queries and data integrity
    UserId int Unique Null Foreign Key References Users(UserId) -- So that each patient has a unique user account to log in to the system, and this also allows us to link the patient's profile with their login credentials for authentication and authorization purposes. By making it Unique, we ensure that one user account can only be associated with one patient, which helps maintain data integrity and security in the system. ANd also gives powers to patient's family to check their medical records and appointments if the patient themselves is not able to do so, by creating a user account for the patient and sharing the credentials with their family members.
);

-- Now i will create the tables for scheduling and visits .

Create Table Appointments(
    AppointmentId int PRIMARY KEY identity (1,1),
    PatientId int Not Null FOREIGN KEY References Patients (PatientId) ,
    DoctorId int Foreign Key References Doctors ( DoctorId),
    AppointmentDate DateTime Not Null ,
    StatusOfVisit varchar (50) Not Null Check (StatusOfVisit in ('Scheduled' ,'Cancelled' , 'Completed') ) , -- Status can only be Scheduled, Cancelled or Completed
    CreatedAt DateTime Not Null Default GetDate()
);
-- This table will become a link between Doctor and Patient tables

Create Table Visits (
    VisitId int PRIMARY KEY Identity (1,1),
    AppointmentId int Unique Not Null Foreign Key References Appointments (AppointmentId) On Delete CASCADE,
    Diagnosis NVARCHAR (255) Not Null ,
    Notes Nvarchar (255) Null ,
    VisitDate DateTime NOT NULL DEFAULT GETDATE()
);

-- Now let's built a table for the Medical details for the hospital
Create Table Prescriptions (
    -- Here one visit can result in multiple medicines , obviouslyso no unique key in visit id.
    PrescriptionId int PRIMARY KEY Identity (1,1) ,
    VisitId int Not Null Foreign Key References Visits(VisitId) On Delete CASCADE,
    MedicineName Nvarchar (255) Not Null ,
    Dosage Nvarchar (100) Not Null,
    Frequency NVARCHAR ( 255 ) Not Null ,
    Duration Nvarchar ( 100 ) Not Null 
) ;

-- Now let's built tables for financials of the hospital
Create Table Bills (
    BillId int Primary Key Identity (1,1) ,
    VisitId int Not Null Foreign Key References Visits ( VisitId) On Delete CASCADE,
    TotalAmount Decimal (19 , 4 ) Not Null Check ( TotalAmount >= 0 ) , -- Total Amount can't be negaive  or null .
    -- which could be calculated from doctor fee and extras
    PaymentStatus varchar (30) Not Null Check ( PaymentStatus in ('Unpaid' , 'Paid'))
) ;

Create Table PaymentTransactions (
    TransactionId int not null Primary Key Identity (1,1) ,
    BillId int Not Null Foreign Key References Bills ( BillId)  On Delete CASCADE,
    PaymentDate DateTime Default GETDATE(),
    PaymentMode nvarchar (30) not null check ( PaymentMode in ('Cash' ,'Card' , 'UPI')),
    AmountPaid Decimal (19,4) Not Null check ( AmountPaid >= 0 ) -- Amount paid can't be negative or null
);

-- Now creating tables for system logs for the hospital
-- This one can be used by receptionists and doctors to track the changes in appointments quickly and easily without going into the details of system audit logs , which are more for admins to track the changes in the system and trace back any issues to specific records and users
Create Table AppointmentAudit (
    AuditId int Primary Key Identity (1, 1),
    AppointmentId int Not Null FOREIGN KEY REFERENCES Appointments (AppointmentId),
    ActionPerformed VARCHAR(100) Not Null check (ActionPerformed in ('Created', 'Preponed', 'Postponed', 'Cancelled')), -- Action can be 'Created', 'Updated', 'Cancelled', etc.
    ActionDate DATETIME NOT NULL DEFAULT GETDATE(),
    Reason NVARCHAR(MAX) NULL -- Reason for the action, which can be null for actions like 'Created' but should be provided for actions like 'Cancelled' or 'Postponed'
);

-- This is specifically for tracking the changes in the system by admins and tracing back any issues to specific records and users by the IT Admin or the System Admin of the hospital.
Create Table SystemAuditLogs(
    LogId int Primary Key Identity (1,1) ,
    TableName VARCHAR (100) Not Null , -- Name of the table where the action was performed
    ActionType varchar (100) Not Null check (ActionType in ('Insert', 'Update', 'Delete' ,  'Lockdown', 'Elevated Permissions', 'Auto-Revoke','CREATE_TABLE', 'ALTER_TABLE', 'DROP_TABLE', 'TRUNCATE_TABLE' , 'Staff_Registration', 'Patient_Registration', 'Doctor_Registration')), -- Type of action performed
    RecordId int  Null , -- Id of the record that was affected by the action , and this will store  the primary Key of all the other tables, so that I can trace back the changes to the specific record in the specific table
    UserId int Null Foreign Key References Users ( UserId) ,
    ActionDate DateTime Not Null Default GetDate(),
    OldValue NVARCHAR (MAX) Null , -- Old value before the change, which can be null for Insert actions. Also Using MAX instead of 255 to store full row snapshots
    NewValue NVARCHAR (MAX) Null -- New value after the change, which can be null for Delete actions
);


-- =============================================
-- The Elevation Procedure ( For The Gatekeeper Role Only)
-- =============================================
-- For that creating a seperate table to track the elevated sessions and their expiry time, so that I can automatically revoke the permissions after the expiry time is reached, which adds an extra layer of security to ensure that the elevated permissions are not misused or left open indefinitely.
CREATE TABLE dbo.ElevatedSessions (
    UserId INT PRIMARY KEY FOREIGN KEY REFERENCES Users(UserId),
    ExpiryTime DATETIME NOT NULL
);

Go



USE HospitalDb;
GO

-- 1. Insert basic Specialties
INSERT INTO Specialties (SpecialtyName) 
VALUES ('General Medicine'), ('Cardiology'), ('Neurology'),('Orthopedics'),('Dermatology'),('Pediatrics');




-- 2. Create the Essential Users
-- Note: Passwords here are placeholders. In your C# app, you'll replace these with actual hashes.
INSERT INTO Users (UserName, UserPasswordHash, Salt, UserRole)
VALUES 
('super_admin', 'HASH_PLACEHOLDER', 'SALT_PLACEHOLDER', 'Hospital_Admin'),
('manager_bob', 'HASH_PLACEHOLDER', 'SALT_PLACEHOLDER', 'Role_Admin'), -- Acting as Role_Admin
('it_tech_sam', 'HASH_PLACEHOLDER', 'SALT_PLACEHOLDER', 'IT_Staff'),
('dr_smith', 'HASH_PLACEHOLDER', 'SALT_PLACEHOLDER', 'Doctor'),
('reception_amy', 'HASH_PLACEHOLDER', 'SALT_PLACEHOLDER', 'Receptionist'),
('gatekeeper_sys', 'HASH_PLACEHOLDER', 'SALT_PLACEHOLDER', 'System_Sync'); -- The Secret Role
-- 2. Create the Database Principals (The "Key Cards")
-- We use 'WITHOUT LOGIN' because these users will be authenticated via your App/Table
-- but the DB engine needs to recognize the name to apply ROLE permissions.
CREATE USER [super_admin] WITHOUT LOGIN;
CREATE USER [manager_bob] WITHOUT LOGIN;
CREATE USER [it_tech_sam] WITHOUT LOGIN;
CREATE USER [dr_smith] WITHOUT LOGIN;
CREATE USER [reception_amy] WITHOUT LOGIN;
CREATE USER [gatekeeper_sys] WITHOUT LOGIN;
GO

--  Map SQL Roles to the Users (Database Level Security)
-- This ensures the DB engine itself recognizes them, not just your table.
ALTER ROLE Hospital_Admin ADD MEMBER [super_admin]; -- If these are SQL Logins
ALTER ROLE Role_Admin ADD MEMBER [manager_bob];
ALTER ROLE IT_Staff ADD MEMBER [it_tech_sam];
ALTER ROLE Role_Medical ADD MEMBER [dr_smith];
ALTER ROLE Role_FrontDesk ADD MEMBER [reception_amy];
ALTER ROLE System_Internal_Sync ADD MEMBER [gatekeeper_sys];
GO

--  Link Users to the Staff Table
-- We need the UserIds we just created.
INSERT INTO Staff (UserId, FirstName, LastName, Gender, JobTitle, ContactNumber, Email)
VALUES 
((SELECT UserId FROM Users WHERE UserName = 'super_admin'), 'Admin', 'Owner', 'Other', 'Hospital_Admin', '000-000-0000', 'admin@hospital.com'),
((SELECT UserId FROM Users WHERE UserName = 'manager_bob'), 'Bob', 'Smith', 'Male', 'Manager', '111-220-3333', 'bob@hospital.com'),
((SELECT UserId FROM Users WHERE UserName = 'it_tech_sam'), 'Sam', 'IT', 'Male', 'IT_Staff', '111-222-3333', 'sam@hospital.com'),
((SELECT UserId FROM Users WHERE UserName = 'reception_amy'), 'Amy', 'Jones', 'Female', 'Receptionist', '444-555-6666', 'amy@hospital.com'),
((SELECT UserId FROM Users WHERE UserName = 'gatekeeper_sys'), 'Sys', 'Gatekeeper', 'Other', 'System_Sync', '777-888-9999', 'sys@hospital.com');




