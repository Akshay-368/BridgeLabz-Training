USE DemoDB;
GO

-- Now running  procedure
EXEC dbo.sp_AddDepartment @DeptID = 5, @DeptName = 'Sales';
GO
-- 1. Add a new department
EXEC sp_AddDepartment @DeptID = 4, @DeptName = 'Marketing';

-- 2. Add a new employee to that department
EXEC sp_AddEmployee @EmpName = 'Frank', @Salary = 55000, @DeptID = 4;

-- Verify the insertion
SELECT * FROM Employees WHERE EmpName = 'Frank';

-- 3. Get all employees earning more than 50,000
-- This should now include 'Alice' and  new guy 'Frank'
EXEC sp_GetHighEarners @MinSalary = 50000;

-- 4. Get the join report 
-- (Shows names and department names together)
EXEC sp_GetEmployeeReport;

-- 5. Update Frank's salary safely
EXEC sp_SafeSalaryUpdate @EmpName = 'Frank', @NewSalary = 65000;

-- Verify the update
SELECT EmpName, Salary FROM Employees WHERE EmpName = 'Frank';

-- 6. Find departments where the average salary is above 60,000
EXEC sp_GetDeptStats @Threshold = 60000;

-- 7. Grant the JuniorDev the ability to select/insert
EXEC sp_ManageJuniorDevAccess @GrantAccess = 1;

-- Check permissions (System View)
SELECT * FROM sys.database_permissions 
WHERE grantee_principal_id = USER_ID('JuniorDev');

-- 7. Grant the JuniorDev the ability to select/insert
EXEC sp_ManageJuniorDevAccess @GrantAccess = 1;

-- Check permissions (System View)
SELECT * FROM sys.database_permissions 
WHERE grantee_principal_id = USER_ID('JuniorDev');
