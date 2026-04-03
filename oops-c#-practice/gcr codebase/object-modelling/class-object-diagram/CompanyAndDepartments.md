# Problem 3: Company and Departments (Composition) Diagram

```mermaid
classDiagram
    class Company{
        +String companyName
        +String address
        +List~Department~ departments
        +addDepartment(name: String) Department
        +removeDepartment(dept: Department)
    }
    class Department{
        +String deptName
        +String deptCode
        +List~Employee~ employees
        +addEmployee(name: String, role: String) Employee
        +removeEmployee(emp: Employee)
    }
    class Employee{
        +String employeeId
        +String name
        +String role
        +double salary
    }

    Company *-- "*" Department : consists of
    Department *-- "*" Employee : consists of
