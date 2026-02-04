-- DDL ( Data Definition Language )-> The Structure of the Database
-- Syntax: CREATE, ALTER, DROP, TRUNCATE These are auto-committed. They define the "container."
-- SYNTAX: CREATE DATABASE [Name];
-- SYNTAX: CREATE TABLE [Name] (Col1 Type, Col2 Type...);
-- SYNTAX: ALTER TABLE [Name] ADD [ColName] Type;

USE master;
GO
-- Cleanup and Start Fresh
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'DemoDB')
    DROP DATABASE DemoDB;
GO

CREATE DATABASE DemoDB;
GO
USE DemoDB;
GO

CREATE TABLE Departments (
    DeptID INT PRIMARY KEY,
    DeptName VARCHAR(50)
);

CREATE TABLE Employees (
    EmpID INT PRIMARY KEY IDENTITY(1,1),
    EmpName VARCHAR(50),
    Salary DECIMAL(10,2),
    DeptID INT -- Will be a Foreign Key
);

-- ALTER: Adding a column later
ALTER TABLE Employees ADD Email VARCHAR(100);

-- DML (Data Manipulation Language) - The Content of the Database
-- Syntax: INSERT, UPDATE, DELETE These handle the rows inside the tables. These are NOT auto-committed.
-- SYNTAX: INSERT INTO [Table] (Cols) VALUES (Values);
-- SYNTAX: UPDATE [Table] SET Col = Val WHERE Condition;
-- SYNTAX: DELETE FROM [Table] WHERE Condition;

-- INSERT
INSERT INTO Departments VALUES (1, 'Development'), (2, 'Design'), (3, 'HR');
INSERT INTO Employees (EmpName, Salary, DeptID) VALUES
('Alice', 70000, 1),
('Bob', 50000, 2),
('Charlie', 60000, 1),
('David', 45000, NULL); -- Employee with no department

-- UPDATE
UPDATE Employees SET Salary = 75000 WHERE EmpName = 'Alice';

-- DELETE
DELETE FROM Employees WHERE EmpName = 'Bob';

-- DQL (The Data Query Language) - The Viewing of the Database
-- Syntax: SELECT, WHERE, ORDER BY, GROUP BY, HAVING Includes Selection (rows) vs Projection (columns).
-- PROJECTION ( Selecting columns) + SELECTION ( Filtering rows)
SELECT EmpName, Salary
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC;

-- GROUP BY & HAVING ( Aggregates )
SELECT DeptID, AVG(Salary) as AvgSalary
FROM Employees
GROUP BY DeptID
HAVING AVG(Salary) > 50000;

-- Joins combine tables based on a related column.
-- 1. INNER JOIN (Only matching rows in both)
SELECT E.EmpName, D.DeptName FROM Employees E
INNER JOIN Departments D ON E.DeptID = D.DeptID;

-- 2. LEFT JOIN ( All Employees, even those with no Dept )
SELECT E.EmpName, D.DeptName FROM Employees E
LEFT JOIN Departments D ON E.DeptID = D.DeptID;

-- 3. RIGHT JOIN (All Departments, even those with no Employees)
SELECT E.EmpName, D.DeptName FROM Employees E
RIGHT JOIN Departments D ON E.DeptID = D.DeptID;

-- 4. FULL OUTER JOIN (Everything from both, matching where possible)
SELECT E.EmpName, D.DeptName FROM Employees E
FULL OUTER JOIN Departments D ON E.DeptID = D.DeptID;

-- 5. CROSS JOIN (Every employee paired with every department - Cartesian Product)
SELECT E.EmpName, D.DeptName FROM Employees E CROSS JOIN Departments D;

-- TCL ( Transaction Control Language) - The Safety
-- Syntax: COMMIT, ROLLBACK, SAVEPOINT
BEGIN TRANSACTION;

UPDATE Employees SET Salary = 99999 WHERE EmpName = 'Alice';

-- If I realized I made a mistake:
-- ROLLBACK TO SAVEPOINT MySavePoint ;

-- Otherwise :
COMMIT;

-- DCL (Data Control Language) - The Security
-- Syntax: GRANT, REVOKE Note : These usually require Logins to be created first.
-- SYNTAX: GRANT [Permission] ON [Object] TO [User];

-- Creating a dummy user for the demo
CREATE USER JuniorDev WITHOUT LOGIN;

-- Granting permission
GRANT SELECT, INSERT ON Employees TO JuniorDev;

-- Taking it away
REVOKE INSERT ON Employees FROM JuniorDev;
