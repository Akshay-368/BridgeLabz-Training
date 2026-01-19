using System;
using System.Collections.Generic;

public class resume 
{
    // abstract class for job roles
    public abstract class JobRole
    {
        public abstract string getRoleName();
    }

    // software engineer role
    public class SoftwareEngineer : JobRole
    {
        public override string getRoleName()
        {
            return "Software Engineer";
        }
    }

    // data scientist role
    public class DataScientist : JobRole
    {
        public override string getRoleName()
        {
            return "Data Scientist";
        }
    }

    // generic resume class
    // T must be some JobRole
    public static class Resume<T> where T : JobRole
    {
        public static string candidateName;
        public static int experienceYears;
        public static T jobRole;

        public static void setResume(string name,int exp,T role)
        {
            candidateName = name;
            experienceYears = exp;
            jobRole = role;
            Console.WriteLine("resume added for " + name);
        }

        public static void printResume()
        {
            Console.WriteLine("Name: " + candidateName);
            Console.WriteLine("Experience: " + experienceYears + " years");
            Console.WriteLine("Role: " + jobRole.getRoleName());
        }
    }

    public static void Main(string[] args)
    {
        /*
        3. AI-Driven Resume Screening System
        o Concepts: Generic Classes, Generic Methods, Constraints
        o Problem Statement: Develop a resume screening system that can process resumes for different job roles while ensuring type safety.
        o Hints: 
          * Create an abstract class JobRole (SoftwareEngineer, DataScientist).
          * Implement a generic class Resume<T> where T : JobRole to process resumes dynamically.
          * Use List<T> to handle multiple job roles in the screening pipeline.
        */

        Console.WriteLine("Resume Screening System\n");

        // list to store different resumes (using generic List)
        // List<T> is dynamic , grows when needed
        // stores reference types (JobRole objects)
        List<JobRole> resumes = new List<JobRole>();

        int ch = 0;
        while(ch != 4)
        {
            Console.WriteLine("1 Add Software Engineer resume");
            Console.WriteLine("2 Add Data Scientist resume");
            Console.WriteLine("3 Print all resumes");
            Console.WriteLine("4 Exit");

            Console.Write("Waiting , for user to enter choice : ");
            ch = Convert.ToInt32(Console.ReadLine());

            if(ch == 1)
            {
                Console.Write("enter candidate name : ");
                string nm = Console.ReadLine();
                Console.Write("enter experience years : ");
                int exp = Convert.ToInt32(Console.ReadLine());

                SoftwareEngineer se = new SoftwareEngineer();
                Resume<SoftwareEngineer>.setResume(nm, exp, se);
                resumes.Add(se);
            }
            else if(ch == 2)
            {
                Console.Write("enter candidate name : ");
                string nm = Console.ReadLine();
                Console.Write("enter experience years : ");
                int exp = Convert.ToInt32(Console.ReadLine());

                DataScientist ds = new DataScientist();
                Resume<DataScientist>.setResume(nm, exp, ds);
                resumes.Add(ds);
            }
            else if(ch == 3)
            {
                if(resumes.Count == 0)
                {
                    Console.WriteLine("no resumes yet");
                }
                else
                {
                    Console.WriteLine("All resumes:");
                    for(int i=0; i<resumes.Count ; i++)
                    {
                        Console.WriteLine("Role: " + resumes[i].getRoleName());
                    }
                }
            }
        }
    }
}
