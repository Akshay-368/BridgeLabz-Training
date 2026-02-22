USE master;
GO

--  Kick everyone out and roll back their unfinished work ( just for testing and development purposes , not for production environment)
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'EmployeeDb')
BEGIN
    Alter DATABASE EmployeeDb Set Single_User With Rollback Immediate ;
    DROP DATABASE EmployeeDb;
END
GO

-- Creating the database
Create database EmployeeDb;
GO

USE EmployeeDb;
GO



------------------------------------------------------------------------------
-- Creating Tables now for the database that i will need for the project

Create Table Employees(
     EmployeeId int primary key identity(1,1),
     FirstName nvarchar (50) not null,
     LastName NVARCHAR(50) not null,
     Email NVARCHAR(50) not null,
     PhoneNumber NVARCHAR(50) not null,
     HourlyRate Decimal(19,6) not null, -- here 19 means total number of digits that cna be stored both before and after decimal point and 6 ( exactly ) digits after decimal point
     EmployeeType NVARCHAR(50) not null Default 'Full Time' Check (EmployeeType in ('Full Time', 'Part Time')),
     IsDeleted bit Default 0 NOT NULL, -- 0 for not deleted and 1 for deleted
     CreatedAt DateTime2 Default SYSDATETIME() not null
);

Create Table Attendance(
     AttendanceId int PRIMARY KEY IDENTITY(1,1),
     EmployeeId int not null Foreign Key References Employees (EmployeeId),
     WorkDate Date not null ,
     IsPresent Bit Not Null Default 0 ,
     ClockedIn DateTime2 Default SYSDATETIME()  null,
     ClockedOut DateTime2  null,
     CONSTRAINT UQ_Attendance UNIQUE (EmployeeId, WorkDate)
);

CREATE TABLE Wages
(
    WagesId INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId INT NOT NULL FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId),
    WageMonth INT NOT NULL,
    WageYear INT NOT NULL,
    TotalDaysWorked INT NOT NULL,
    TotalHoursWorked DECIMAL(10,2) NOT NULL,
    TotalOvertimeHours DECIMAL(10,2) NOT NULL,
    MonthlyWage DECIMAL(12,2) NOT NULL,
    GeneratedOn DATETIME2 DEFAULT SYSDATETIME() NOT NULL
     
);


----------------------------------------------------------------------------------
