using System;
using System.Collections.Generic;

namespace QuizRankingSystem;

// Represents a student record
public class Student
{
    public string studentName;
    public string department;
    public int quiz1;
    public int quiz2;
    public int quiz3;

    // Constructor
    public Student(string Name, string depart, int q1, int q2, int q3)
    {
        // WRITE YOUR CODE HERE
        studentName = Name ;
        department = depart ;
        quiz1 = q1 ;
        quiz2 = q2 ;
        quiz3 = q3 ;
    }

    // Optional helper
    public int GetTotalScore()
    {
        // WRITE YOUR CODE HERE
        int total = quiz1 + quiz2 + quiz3 ;
        return total ;
    }
}

// Manager class to handle operations
public class QuizRankingManager
{
    private List<Student> students = new List<Student>();

    // Record a student
    public void recordStudent(string studentName, string department, int q1, int q2, int q3)
    {
        // WRITE YOUR CODE HERE
        Student s = new Student (studentName ,department , q1 , q2 , q3 );
        students.Add(s);
        Console.WriteLine("Record Added:" + studentName);
    }

    // Get top student(s) by department
    public void getTopByDepartment(string department)
    {
        // WRITE YOUR CODE HERE
        bool found = false ; // flag to be set initially at false
        int max = int.MinValue ; // for keeping track of max values and find the ultimate highest score that is required tobe displayed
        
        // I need to find students in the department with highest total score
        for ( int i = 0 ; i < students.Count ; i++)
        {
            if ( students[i].department == department)
            {
              found = true;
              int a = students[i].GetTotalScore();
              max = Math.Max( a , max );
            }
            
        }
        for ( int i = 0 ; i < students.Count ; i++)
        {
            if ( students[i].GetTotalScore() == max  && students[i].department == department)
            {
                Console.WriteLine(students[i].studentName + " " + students[i].GetTotalScore());
            }
        }
        // Edge case
        if ( found) { 
            Console.WriteLine("Department Not Found");
            return ;
            }
    }

    // Get top student(s) by quiz (Q1, Q2, Q3)
    public void getTopByQuiz(string quizName)
    {
        // WRITE YOUR CODE HERE
        if ( quizName != "Q1" && quizName != "Q2" && quizName != "Q3") return ;
        if (students.Count == 0 )
        {
            Console.WriteLine("No Records Available");
            return;
        }

        int q1  = int.MinValue ;
        int q2  = int.MinValue ;
        int q3  = int.MinValue ;
        int max = int.MinValue;
        for ( int i = 0 ; i < students.Count ; i++)
        {
            if ( quizName == "Q1")
            {
                 q1= students[i].quiz1;
            }
            if ( quizName == "Q2")
            {
                 q2= students[i].quiz2;
            }
            if ( quizName == "Q3")
            {
                 q3= students[i].quiz3;
            }

            max = Math.Max(max , Math.Max (q1 , Math.Max(q2 , q3)));
        }

        for ( int i = 0 ; i < students.Count ; i++)
        {
            if ( students[i].quiz1 == max && quizName == "Q1")
            {
                Console.WriteLine(students[i].studentName + " " + students[i].quiz1);
            }
            else if ( students[i].quiz2 == max && quizName == "Q2")
            {
                Console.WriteLine(students[i].studentName + " " + students[i].quiz2);
            }
            else if ( students[i].quiz3 == max && quizName == "Q3")
            {
                Console.WriteLine(students[i].studentName + " " + students[i].quiz3);
            }
        }

    }

    // Process commands
    public void processCommands(int n)
    {
        // WRITE YOUR CODE HERE

        QuizRankingManager manager = new QuizRankingManager();

        for (int i = 0; i < n; i++)
        {

            string input = Console.ReadLine();
            string[] parts = input.Split(' ');

            if (parts[0] == "Record")
            {
                string name = parts[1];
                string dept = parts[2];
                int q1 = int.Parse(parts[3]);
                int q2 = int.Parse(parts[4]);
                int q3 = int.Parse(parts[5]);

                manager.recordStudent(name, dept, q1, q2, q3);
            }
            else if (parts[0] == "Top")
            {
                string arg = parts[1];

                if (arg == "Q1" || arg == "Q2" || arg == "Q3")
                {
                    manager.getTopByQuiz(arg);
                }
                else
                {
                    manager.getTopByDepartment(arg);
                }
            }
        }
    }
}


