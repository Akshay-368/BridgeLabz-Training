# University Management System Diagram
```mermaid
classDiagram
    class Student{
        +String studentId
        +String name
        +String email
        +List~Course~ enrolledCourses
        +enrollCourse(course: Course)
        +dropCourse(course: Course)
        +viewSchedule() List~Course~
    }
    class Professor{
        +String professorId
        +String name
        +String department
        +List~Course~ taughtCourses
        +assignToCourse(course: Course)
        +removeFromCourse(course: Course)
        +gradeStudent(student: Student, course: Course, grade: String)
    }
    class Course{
        +String courseCode
        +String title
        +int credits
        +Professor instructor
        +List~Student~ enrolledStudents
        +assignProfessor(prof: Professor)
        +addStudent(student: Student)
        +removeStudent(student: Student)
    }

    Student "*" -- "*" Course : enrolls in
    Professor "1" -- "*" Course : teaches
    Course "1" --> "1" Professor : taught by
    Course "1" o-- "*" Student : aggregates
