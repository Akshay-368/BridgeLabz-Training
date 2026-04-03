using System;

public class quiz
{
  
  public static int calcscore ( string[] corr, string[] stu )
  {
    // this method is for checking each answer and counts how many correct
    // using equalsIgnoreCase so case doesnt matter
    
    int score = 0 ;
    
    for (int i = 0 ; i <   corr.Length ; i++)
    {
      // safety if student array shorter or longer, but should be same
      if (i >= stu.Length)
      {
        break; // no more student answers
      }
      
      if (corr[i].Equals(stu[i], StringComparison.OrdinalIgnoreCase))
      {
        score++; // yay correct
      }
    }
    
    return score;
  }
  
  
  public static void printfeedback(string[] corr, string[] stu)
  {
    // printing detailed feedback for each question
    
    Console.WriteLine( " Detailed Feedback:");
    Console.WriteLine();
    
    for (int i = 0; i < corr.Length; i++)
    {
      string studentans = (i < stu.Length) ? stu[i] : " ( no answer ) " ;
      
      if (i < stu.Length && corr[i].Equals(stu[i], StringComparison.OrdinalIgnoreCase))
      {
        Console.WriteLine("Question " + (i+1) + ": Correct   (you said: " + studentans + ")");
      }
      else
      {
        Console.WriteLine("Question " + (i+1) + " : Incorrect (you said: " + studentans + ", correct is: " + corr[i] + ")");
      }
    }
    
    Console.WriteLine();
  }
  
  
  public static void Main ()
  {
    /*
    "EduQuiz – Student Quiz Grader"
    Story: You’re building the grading module for a quiz app. A student answers a 10-question quiz.
    You must compare their answers to the correct ones, give feedback, and calculate scores.
    Requirements:
    ● Use two String[] arrays: correctAnswers[] and studentAnswers[].
    ● Implement a method calculateScore(String[] correct, String[] student) that returns a score.
    ● Use string comparison with .equalsIgnoreCase() for case-insensitive matching.
    ● Print detailed feedback: Question 1: Correct / Incorrect.
    ● Bonus: Show percentage score and pass/fail message.
    */
    
    // hardcoding correct answers for the 10 questions of the   quiz
    string[] correct = new string[10];
    correct[0] = "A"  ;
    correct[1] = "B" ;
    correct[2] = "C" ;
    correct[3] = "D" ;
    correct[4] = "A" ;
    correct[5] = "B" ;
    correct[6] = "C" ;
    correct[7] = "D" ;
    correct[8] = "A" ;
    correct[9] = "B" ;
    
    // array to store student answers
    string[] student = new string[10] ;
    
    Console.WriteLine("Welcome to EduQuiz!") ;
    Console.WriteLine( "  Please enter your answers ( A ,  B , C , oro D ) for 10 questions ." ) ;
    Console.WriteLine();
    
    // waiting for user to enter each answer one by one
    for (int i = 0; i < 10; i++)
    {
      Console.WriteLine("Question " + (i+1) + ": ");
      student[i] = Console.ReadLine();
      
      // little safety
      if (student[i] == null)
      {
        student[i] = "";
      }
    }
    
    Console.WriteLine () ;
    Console.WriteLine ( "  Grading your quiz now... " ) ;
    Console.WriteLine ();
    
    printfeedback ( correct , student ) ;
    
    int scr = calcscore ( correct , student ) ;
    
    Console.WriteLine ( " Your score : " + scr + " out of 10");
    
    double perc = (scr / 10.0 ) * 100 ;
    Console.WriteLine ( " Percentage : " + perc + "%");
    
    Console.WriteLine ();
    
    if (scr >= 6)  // let's assume 60% will be the passing percentage
    {
      Console.WriteLine (  " Congrats! You passed the quiz ! " ) ;
    }
    else
    {
      Console.WriteLine (" Sorry  , you didn't pass this time. Try again ! " ) ;
    }
    
    Console.WriteLine ();
    Console.WriteLine ("press enter to exit the program...");
    Console.ReadLine  ();
    
  }
}
