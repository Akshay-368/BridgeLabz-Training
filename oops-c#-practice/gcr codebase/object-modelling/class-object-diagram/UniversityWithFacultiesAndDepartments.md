# University with Faculties and Departments (Composition and Aggregation) Diagram
```mermaid
classDiagram
    class University{
        +String universityName
        +String location
        +List~Department~ departments
        +List~Faculty~ facultyMembers
        +addDepartment(name: String) Department
        +addFaculty(faculty: Faculty)
    }
    class Department{
        +String deptName
        +String deptCode
        +List~Faculty~ assignedFaculty
        +assignFaculty(faculty: Faculty)
        +removeFaculty(faculty: Faculty)
    }
    class Faculty{
        +String facultyId
        +String name
        +String specialization
        +String email
    }

    University *-- "*" Department : consists of
    University o-- "*" Faculty : aggregates
    Department o-- "*" Faculty : employs (optional assignment)
