public class AverageMarks
{
    public static void Run()
    {
        /*Create a program to take input marks of students in 3 subjects physics, chemistry, and maths.
        Compute the percentage and then calculate the grade  as per the following guidelines
        Hint =>
        Take input for the number of students
        Create arrays to store marks, percentages, and grades of the students
        Take input for marks of students in physics, chemistry, and maths. If the marks are negative, ask the user to enter positive values and decrement the index
        Calculate the percentage and grade of the students based on the percentage
        Display the marks, percentages, and grades of each student
        */
        

        Console.Write("Enter the number of students: ");
        int numStudents = Convert.ToInt32(Console.ReadLine());
        
        //  arrays to store marks , percentages , and grades of the students
        double[] physicsMarks = new double[numStudents];
        double[] chemistryMarks = new double[numStudents];
        double[] mathsMarks = new double[numStudents];
        double[] percentages = new double[numStudents];
        string[] grades = new string[numStudents];
        string[] remarks = new string[numStudents];
        
        // Input marks for  students
        for (int i = 0; i < numStudents; i++)
        {
            bool validInput = false;
            
            while (!validInput)
            {
                Console.WriteLine($" Enter marks for Student {i + 1} (physics, chemistry, maths) space separated : " ) ;
                string input = Console.ReadLine() ;
                string[] marks = input.Split(' ') ;
                
                if ( marks.Length != 3 )
                {
                    Console.WriteLine( " Please enter y 3 marks  only ( separated by spaces. ) " ) ;
                    continue ;
                }
                
                // Validation of marks after converting to double
                double physics = Convert.ToDouble (marks[0]);
                double chemistry = Convert.ToDouble( marks[1]) ;
                double maths = Convert.ToDouble(marks [2] ) ;
                
                // negative marks or not
                if (physics < 0 || chemistry < 0 || maths < 0)
                {
                    Console.WriteLine("Marks cannot be negative. Invalid Input");
                    continue; // Asking again , instead of moving ahead
                }
                
                // Storing valid marks now
                physicsMarks[i] = physics ;
                chemistryMarks[i] = chemistry ;
                mathsMarks[i] = maths;
                
                validInput = true ;
            }
        }
        

        for (int i = 0; i < numStudents; i++) // percentage and grade for the students
        {
            percentages[i] = (physicsMarks[i] + chemistryMarks[i] + mathsMarks[i]) / 3;
            (grades[i], remarks[i]) = fun(percentages[i]);
        }
        

        Console.WriteLine("Student Results is as follows :");

        for (int i = 0; i < numStudents; i++)
        {
            Console.WriteLine($" Student {i + 1} th number:");
            Console.WriteLine($"Physics: {physicsMarks[i] }, Chemistry: {chemistryMarks[i]}, Maths: {mathsMarks[i] } ");
            Console.WriteLine($"Average marks: {percentages[i]:F2}");
            Console.WriteLine($"Grade: {grades[i]}");
            Console.WriteLine($"Remarks: {remarks[i]}");

        }
    }
    
    private static (string, string) fun(double percentage)
    {
        if (percentage <= 39)
        {
            return ("R", "Remedial Standards");
        }
        else if (percentage >= 40 && percentage <= 49)
        {
            return ("E", "Level - 1-, too below agency-normalise standards");
        }
        else if (percentage >= 50 && percentage <= 59)
        {
            return ("D", "Level -1, well below agency normalised standards");
        }
        else if (percentage >= 60 && percentage <= 69)
        {
            return ("C", "Level - 2 below but approaching agency normalised standards");
        }
        else if (percentage >= 70 && percentage <= 79)
        {
            return ("B", "Level - 3, at agency normalised standards");
        }
        else
        {
            return ("A", "Level - 4 above agency normalised standards");
        }
    }
}
