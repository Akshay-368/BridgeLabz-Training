use master;
GO
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'payroll_service')
BEGIN
    PRINT 'Database payroll_service already exists.';
    ALTER DATABASE payroll_service SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    Drop Database payroll_service;
    Print 'Database payroll_service dropped.';
END
GO

-- Createing the database
CREATE DATABASE payroll_service;
PRINT 'Database payroll_service created.';
Go

-- Switch to the database
USE payroll_service;
GO

-- Drop tables if they exist (for clean r e-run during develop )
IF OBJECT_ID('payroll_details', 'U') IS NOT NULL
    DROP TABLE payroll_details;
GO

IF OBJECT_ID('employee_payroll', 'U') IS NOT NULL
    DROP TABLE employee_payroll;
GO

-- Create employee_payroll table
CREATE TABLE employee_payroll
(
    ID          INT IDENTITY(1,1) PRIMARY KEY,
    Name        VARCHAR(255) NOT NULL,
    Salary      DECIMAL(18,2) NOT NULL,
    StartDate   DATETIME NOT NULL
);
GO

PRINT 'Table employee_payroll created.';
GO

-- Create payroll_details table
CREATE TABLE payroll_details
(
    EmployeeId  INT PRIMARY KEY,
    Salary      DECIMAL(18,2) NOT NULL,

    CONSTRAINT FK_payroll_details_employee_payroll
        FOREIGN KEY (EmployeeId) REFERENCES employee_payroll(ID)
        ON DELETE CASCADE
);
GO

PRINT 'Table payroll_details created with foreign key.';
GO

--  Add a few test records (for quick verification)
INSERT INTO employee_payroll (Name, Salary, StartDate)
VALUES
    ('Rahul Kumar', 65000.00, '2025-01-15'),
    ('Priya Sharma', 52000.00, '2025-02-01'),
    ('Aman Singh',   48000.00, '2025-03-10');
GO

PRINT '3 sample records inserted into employee_payroll.';
GO

PRINT 'Verification:';
SELECT COUNT(*) AS 'employee_payroll rows' FROM employee_payroll;
SELECT COUNT(*) AS 'payroll_details rows' FROM payroll_details;
GO

PRINT 'Setup complete. I can now use this database with my C# code.';
GO
