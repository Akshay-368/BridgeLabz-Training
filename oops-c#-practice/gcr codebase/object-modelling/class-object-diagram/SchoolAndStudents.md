# School and Students with Courses (Association and Aggregation) Diagram

```mermaid
classDiagram
    class School{
        +String schoolName
        +String address
        +List~Student~ students
        +addStudent(student: Student)
        +removeStudent(student: Student)
        +getAllCourses() List~Course~
    }
    class Student{
        +String studentId
        +String name
        +String email
        +List~Course~ enrolledCourses
        +enrollInCourse(course: Course)
        +dropCourse(course: Course)
        +viewEnrolledCourses() List~Course~
    }
    class Course{
        +String courseCode
        +String courseName
        +int credits
        +List~Student~ enrolledStudents
        +addStudent(student: Student)
        +removeStudent(student: Student)
        +viewEnrolledStudents() List~Student~
    }

    School o-- "*" Student : aggregates
    Student "1" -- "*" Course : enrolls in
    Course "1" -- "*" Student : has enrolled
