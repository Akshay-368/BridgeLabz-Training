using System ;
namespace ScoreManager ;
/*
2. Scenario: Develop a program to manage student test scores. The program should:
● Store the scores of n students in an array.
● Calculate and display the average score.
● Find and display the highest and lowest scores.
● Identify and display the scores above the average.
● Handle invalid input like negative scores or non-numeric input.
*/
public class ScoreManager
{
    public static void Run()
    {
        Console.Write ( " Enter the number of students : ") ;
        if (!int.TryParse (Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine ("Invalid number of students.") ;
            return ;
        }

        double[] scores = new double[n];

        for (int i = 0; i < n; i++)
        {
            while (true)
            {
                Console.Write($" Enter score for student {i + 1} : " ) ;
                string input = Console.ReadLine();

                if (double.TryParse(input, out double score) && score >= 0 && score <= 100)
                {
                    scores[i] = score;
                    break;
                }
                Console.WriteLine( "  Please enter a numeric score between 0 and 100.");
            }
        }

        // DOing calculations
        double average = scores.Average();
        double highest = scores.Max();
        double lowest = scores.Min();

        Console.WriteLine ( "Scores are as follows  : ");
        Console.WriteLine ( $"Average Score: {average:F2}");
        Console.WriteLine ( $"Highest Score: {highest}");
        Console.WriteLine ( $"Lowest Score:  {lowest}");

        Console.WriteLine( "Scores Above Average : " ) ;
        foreach (var s in scores)
        {
            if (s > average) Console.WriteLine ( $"- {s}");
        }
    }
}
