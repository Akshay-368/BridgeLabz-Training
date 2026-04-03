using System;
using System.Collections.Generic;

public class univ 
{
    // abstract class for course type
    public abstract class CourseType
    {
        public abstract void showEvalType();
    }

    // concrete exam course
    public class ExamCourse : CourseType
    {
        public override void showEvalType()
        {
            Console.WriteLine("Evaluation: Final Exam");
        }
    }

    // concrete assignment course
    public class AssignmentCourse : CourseType
    {
        public override void showEvalType()
        {
            Console.WriteLine("Evaluation: Assignments + Project");
        }
    }

    // generic class Course<T> with constraint T : CourseType
    // T must be some kind of CourseType
    public static class Course<T> where T : CourseType
    {
        public static string courseName;
        public static int credits;
        public static T evalType;

        public static void setCourse(string name,int cred,T type)
        {
            courseName = name;
            credits = cred;
            evalType = type;
            Console.WriteLine("course added: " + name);
        }

        public static void printCourse()
        {
            Console.WriteLine("Course: " + courseName);
            Console.WriteLine("Credits: " + credits);
            evalType.showEvalType();
        }
    }

    public static void Main(string[] args)
    {
        /*
        3. Multi-Level University Course Management System
        o Concepts: Generic Classes, Constraints, Variance
        o Problem Statement: Develop a university course management
        system where different departments offer courses with different
        evaluation types.
        o Hints:
         Create an abstract class CourseType (e.g., ExamCourse,
        AssignmentCourse).
         Implement a generic class Course<T> where T : CourseType
        to manage different courses.
         Use List<T> to handle any type of course dynamically.
        */

        Console.WriteLine("University Course Manager\n");

        // list to store different courses (using generic List)
        // List<T> is dynamic array , grows automatically
        // under hood: array , doubles when full
        // here we store CourseType objects (reference types)
        List<CourseType> allCourses = new List<CourseType>();

        int ch = 0;
        while(ch != 4)
        {
            Console.WriteLine("1 Add Exam Course");
            Console.WriteLine("2 Add Assignment Course");
            Console.WriteLine("3 Show all courses");
            Console.WriteLine("4 Exit");

            Console.Write("Waiting , for user to enter choice : ");
            ch = Convert.ToInt32(Console.ReadLine());

            if(ch == 1)
            {
                Console.Write("enter course name : ");
                string nm = Console.ReadLine();
                Console.Write("enter credits : ");
                int cred = Convert.ToInt32(Console.ReadLine());

                ExamCourse exam = new ExamCourse();
                Course<ExamCourse>.setCourse(nm, cred, exam);
                allCourses.Add(exam);
            }
            else if(ch == 2)
            {
                Console.Write("enter course name : ");
                string nm = Console.ReadLine();
                Console.Write("enter credits : ");
                int cred = Convert.ToInt32(Console.ReadLine());

                AssignmentCourse ass = new AssignmentCourse();
                Course<AssignmentCourse>.setCourse(nm, cred, ass);
                allCourses.Add(ass);
            }
            else if(ch == 3)
            {
                if(allCourses.Count == 0)
                {
                    Console.WriteLine("no courses added");
                }
                else
                {
                    Console.WriteLine("All courses:");
                    for(int i=0; i<allCourses.Count ; i++)
                    {
                        allCourses[i].showEvalType();
                    }
                }
            }
        }
    }
}
