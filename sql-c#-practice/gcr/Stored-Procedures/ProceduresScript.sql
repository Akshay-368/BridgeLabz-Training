USE DemoDB;
GO

-- 1. Procedure to Add a Department
CREATE OR ALTER PROCEDURE sp_AddDepartment
    @DeptID INT,
    @DeptName VARCHAR(50)
AS
BEGIN
    INSERT INTO Departments (DeptID, DeptName)
    VALUES (@DeptID, @DeptName);
END;
GO

-- 2. Procedure to Add an Employee
CREATE OR ALTER PROCEDURE sp_AddEmployee
    @EmpName VARCHAR(50),
    @Salary DECIMAL(10,2),
    @DeptID INT = NULL
AS
BEGIN
    INSERT INTO Employees (EmpName, Salary, DeptID)
    VALUES (@EmpName, @Salary, @DeptID);
END;
GO

-- 3. Procedure to Update Employee Salary
CREATE OR ALTER PROCEDURE sp_UpdateSalary
    @EmpName VARCHAR(50),
    @NewSalary DECIMAL(10,2)
AS
BEGIN
    UPDATE Employees 
    SET Salary = @NewSalary 
    WHERE EmpName = @EmpName;
END;
GO

-- 4. Get High Earners (Selection & Projection)
CREATE OR ALTER PROCEDURE sp_GetHighEarners
    @MinSalary DECIMAL(10,2)
AS
BEGIN
    SELECT EmpName, Salary
    FROM Employees
    WHERE Salary > @MinSalary
    ORDER BY Salary DESC;
END;
GO

-- 5. Get Department Stats (Group By & Having)
CREATE OR ALTER PROCEDURE sp_GetDeptStats
    @Threshold DECIMAL(10,2)
AS
BEGIN
    SELECT DeptID, AVG(Salary) as AvgSalary
    FROM Employees
    GROUP BY DeptID
    HAVING AVG(Salary) > @Threshold;
END;
GO

-- 6. Flexible Join Report
-- Using a parameter to choose the join type or just returning a standard Inner Join
CREATE OR ALTER PROCEDURE sp_GetEmployeeReport
AS
BEGIN
    -- Standard Inner Join
    SELECT E.EmpName, D.DeptName 
    FROM Employees E
    INNER JOIN Departments D ON E.DeptID = D.DeptID;
END;
GO

-- 7. Transactional Update (TCL inside SP)
CREATE OR ALTER PROCEDURE sp_SafeSalaryUpdate
    @EmpName VARCHAR(50),
    @NewSalary DECIMAL(10,2)
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        UPDATE Employees SET Salary = @NewSalary WHERE EmpName = @EmpName;
        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        PRINT 'Error occurred, transaction rolled back.';
    END CATCH
END;
GO

-- 8. Management Procedure for Permissions (DCL)
CREATE OR ALTER PROCEDURE sp_ManageJuniorDevAccess
    @GrantAccess BIT -- 1 for Grant, 0 for Revoke
AS
BEGIN
    IF @GrantAccess = 1
        GRANT SELECT, INSERT ON Employees TO JuniorDev;
    ELSE
        REVOKE INSERT ON Employees FROM JuniorDev;
END;
GO

