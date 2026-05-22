184. Department Highest Salary
Solved
Medium
Topics
premium lock icon
Companies
SQL Schema
Pandas Schema
Table: Employee

+--------------+---------+
| Column Name  | Type    |
+--------------+---------+
| id           | int     |
| name         | varchar |
| salary       | int     |
| departmentId | int     |
+--------------+---------+
id is the primary key (column with unique values) for this table.
departmentId is a foreign key (reference columns) of the ID from the Department table.
Each row of this table indicates the ID, name, and salary of an employee. It also contains the ID of their department.
 

Table: Department

+-------------+---------+
| Column Name | Type    |
+-------------+---------+
| id          | int     |
| name        | varchar |
+-------------+---------+
id is the primary key (column with unique values) for this table. It is guaranteed that department name is not NULL.
Each row of this table indicates the ID of a department and its name.
 

Write a solution to find employees who have the highest salary in each of the departments.

Return the result table in any order.

The result format is in the following example.

 

Example 1:

Input: 
Employee table:
+----+-------+--------+--------------+
| id | name  | salary | departmentId |
+----+-------+--------+--------------+
| 1  | Joe   | 70000  | 1            |
| 2  | Jim   | 90000  | 1            |
| 3  | Henry | 80000  | 2            |
| 4  | Sam   | 60000  | 2            |
| 5  | Max   | 90000  | 1            |
+----+-------+--------+--------------+
Department table:
+----+-------+
| id | name  |
+----+-------+
| 1  | IT    |
| 2  | Sales |
+----+-------+
Output: 
+------------+----------+--------+
| Department | Employee | Salary |
+------------+----------+--------+
| IT         | Jim      | 90000  |
| Sales      | Henry    | 80000  |
| IT         | Max      | 90000  |
+------------+----------+--------+
Explanation: Max and Jim both have the highest salary in the IT department and Henry has the highest salary in the Sales department.

# Write your MySQL query statement below
Select
      d.name As Department,
      e.name As Employee,
      e.salary As Salary
From Employee As e
Join Department As d
On e.departmentId = d.id
Where (e.departmentId , e.salary) In 
(
    -- This is the subquery to find the exact Max Salary per department thus using department id and salary from the Employee table as e
    Select departmentId , Max(salary)
    From Employee
    Group By departmentId
);




/* Write your T-SQL query statement below */

WITH RankedEmployees AS (
    SELECT 
        departmentId,
        name AS Employee,
        salary AS Salary,
        DENSE_RANK() OVER (
            PARTITION BY departmentId 
            ORDER BY salary DESC
        ) AS rnk
    FROM Employee
)
SELECT 
    d.name AS Department,
    r.Employee,
    r.Salary
FROM RankedEmployees AS r
JOIN Department AS d ON r.departmentId = d.id
WHERE r.rnk = 1; -- We only want the number 1 spots!

/*
Select
      d.name as Department,
      e.name as Employee,
      e.salary as Salary
From Employee as e
Join Department as d
on e.departmentId = d.id
Join 
(
    Select departmentId , Max(salary) as MaxSalary
    From Employee 
    Group By departmentId
) as maxsalary
on e.departmentId = maxsalary.departmentId
And e.salary = maxsalary.MaxSalary ;


Step 1: The Subquery works completely alone first
The database runs the code inside your parentheses first, entirely by itself:

SELECT departmentId, MAX(salary) AS MaxSalary
FROM Employee 
GROUP BY departmentId

Because this code has a GROUP BY departmentId at the bottom, it doesn't just look at the whole company. It builds a neat, separate summary table right there in memory.
Using our LeetCode data, that subquery creates this exact temporary virtual table 

(which you named maxsalary):
Virtual Table 
(maxsalary)departmentId  MaxSalary1 
(IT)                     900002   
(Sales)                  80000

See? It already knows the maximums for each specific department before it talks to the outer query!

Step 2: Why can't we just write this subquery alone?

You asked a fantastic question: "If this subquery finds it per department, couldn't we just write it alone?"Let's look at that virtual table above. What is missing? 

The employees' names!
If we ran that subquery alone, the output would just be:

Dept 1 -> 90000Dept 2 -> 80000

But LeetCode wants the output to show Jim, Max, and Henry. Because we used a GROUP BY, we lose the ability to see individual row details like the employee names. We are forced to use the outer query to go fetch those names.

Step 3: How the ON and AND conditions act like a filter

This is where the second JOIN saves the day. We take the giant master list of all employees (Employee as e) and lay it right next to our small summary table (maxsalary).The ON and AND conditions act like a double-sided security checkpoint:

ON e.departmentId = maxsalary.departmentId
AND e.salary = maxsalary.MaxSalary

Let's watch what happens when individual employees try to pass through this checkpoint:
Joe (Dept 1, Salary 70000):
Does his Dept (1) match a row in the summary table? Yes (Row 1).
Does his Salary (70000) match the MaxSalary for Dept 1 (90000)? No. ❌ 
Joe is blocked and dropped from the output.

Jim (Dept 1, Salary 90000):
Does his Dept (1) match? Yes.
Does his Salary (90000) match the MaxSalary for Dept 1 (90000)? Yes!  ✓
Jim passes through!

Henry (Dept 2, Salary 80000):
Does his Dept (2) match a row in the summary table? Yes (Row 2).
Does his Salary (80000) match the MaxSalary for Dept 2 (80000)? Yes!  ✓ 
Henry passes through!

Summary: The Big Picture Difference
To tie it all together with your previous question:

In the Correlated Subquery variation (with inner_e), the subquery had to constantly ask the outer loop for instructions: "Hey, what row are you on? Okay, let me calculate the max for that specific department right now." (Slow, row-by-row).

In this Derived Table JOIN variation, the subquery runs once at the very beginning, builds a complete cheat sheet of all department maximums, and the outer query just uses a fast JOIN to filter out anyone whose name doesn't line up with those maximum numbers.
*/

/*
-- This is one of the possible way to solve this question, with the help of a simple join and sub query inside where clause with the use Max() aggregate function , though the learning was how we cna't use more than one column inside where clause in mssql and how we need to use  a seperate inner where clause and aliasing inside the outer where clause to deal with scope and keep the constraint of finding teh max () as per the constraint  of second column

Select
      d.name As Department,
      e.name As Employee,
      e.salary As Salary
From Employee As e
Join Department As d
on e.departmentId = d.id
where e.salary = (
    -- Single column subquery linked to outer row e
    Select Max(salary) 
    From Employee as inner_e
    where inner_e.departmentId = e.departmentId -- withoutthis where clause here , the output just only end up focusing on the max salary in the entire table of employees and will end up crossing the boundary of department completely and thus end up eliminating that 80,000 salried employee ( from the sameple data test case)
);
*/

/*
To fix that global maximum issue, we have to tell the inner subquery: "Don't just look at the whole company. Only look at the employees who work in the specific department of the row I am currently checking on the outside."

This is called a Correlated Subquery. It loops through the outer table row-by-row.

When the database engine is evaluating Henry (Sales, Dept 2):

It looks at the outer row e: Henry, Dept 2, $80,000.

It pauses and jumps inside the subquery to find his comparison target.

If you just typed FROM Employee WHERE departmentId = departmentId, SQL would look inside the subquery box, see the column departmentId twice, and compare the inner table to itself (which is always true!). It completely forgets about Henry.

WHERE inner_e.departmentId = e.departmentId
--     [Inside Box]        = [Outside Row (Henry's Dept, which is 2)]
Now, the subquery successfully restricts its vision to only Department 2 employees, calculates that the maximum for Department 2 is $80,000, and hands that number back to the outer filter. Henry's $80,000 matches the subquery's $80,000, and he is saved!

So in short :
We need the inner WHERE clause to find the max salary per department instead of the max salary of the whole company.

We need the inner_e alias so SQL doesn't get confused about which departmentId belongs to the inner loop and which one belongs to the outer loop.
*/


/*
Strategy A: The Row-by-Row Loop (Correlated Subquery)
When you use the WHERE e.salary = (Select Max... Where inner_e.dept = e.dept) approach:

[Outer Query Engine] 
  👉 Looks at Row 1 (Joe, Dept 1, 70k)
       ↳ 🛑 PAUSE! Jump into subquery. 
       ↳ Calculate MAX for Dept 1... It's 90k. 
       ↳ Compare 70k = 90k? False. Drop Joe.

  👉 Looks at Row 2 (Jim, Dept 1, 90k)
       ↳ 🛑 PAUSE! Jump into subquery. 
       ↳ Calculate MAX for Dept 1... It's 90k. 
       ↳ Compare 90k = 90k? True. Keep Jim.

  👉 Looks at Row 3 (Henry, Dept 2, 80k)
       ↳ 🛑 PAUSE! Jump into subquery. 
       ↳ Calculate MAX for Dept 2... It's 80k. 
       ↳ Compare 80k = 80k? True. Keep Henry.

Memory Profile: It doesn't store a temporary table. Instead, it behaves like a programming nested for-loop. It repeatedly calculates the maximum over and over for every single employee row in the table.


Strategy B: The Cheat-Sheet Filter (Derived Table JOIN)
When you use the JOIN (Select dept, Max... Group By dept) as maxsalary approach:

[Step 1: Subquery Engine runs completely ALONE ONCE]
  ↳ Scans table, creates an in-memory "Cheat Sheet":
    • Dept 1 -> 90k
    • Dept 2 -> 80k

[Step 2: Main Engine runs]
  ↳ Instantly compares the main table rows directly against the Cheat Sheet.
    • Joe (Dept 1, 70k)   -> Checks sheet for Dept 1. Max is 90k. 70k != 90k. Drop.
    • Jim (Dept 1, 90k)   -> Checks sheet for Dept 1. Max is 90k. 90k == 90k. Keep.
    • Henry (Dept 2, 80k) -> Checks sheet for Dept 2. Max is 80k. 80k == 80k. Keep.

Memory Profile: It allocates a tiny pocket of temporary memory to hold that cheat-sheet table up front. Because it builds that sheet once, it never has to recalculate a MAX() function ever again for the rest of the query.
*/
