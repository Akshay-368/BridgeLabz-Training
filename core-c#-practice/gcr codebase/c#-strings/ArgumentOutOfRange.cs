using System;

public class ArgumentOutOfRange
{
  
  public static void badsub ()
  {
    // this one will throw ArgumentOutOfRangeException cuz we give bad numbers to Substring
    
    string msg = "welcome";
    
    // msg length is 7, indexes from 0 to 6
    // we try start at 10 (too big) and length 5, definitely wrong
    string part = msg.Substring(10, 5); 
    
    // never gonna print this
    Console.WriteLine(part);
  }
  
  
  public static void safesub ()
  {
    // here we do the same bad thing but wrap in try catch so it doesnt crash everything
    
    string txt = "csharp fun";
    
    try
    {
      // start index 15 is way past the end (txt is 10 chars long)
      // also asking for length -3 which is nonsense
      string sub = txt.Substring(15, -3);
      
      // if no exception (wont happen) print it
      Console.WriteLine("got substring: " + sub);
    }
    catch (ArgumentOutOfRangeException err)
    {
      // caught the exact error we wanted
      Console.WriteLine("oh no! bad arguments for Substring");
      Console.WriteLine("details: " + err.Message);
      
      // print full info cuz why not
      Console.WriteLine(err.ToString());
    }
    catch (Exception oth)
    {
      // safety net for any other weird error
      Console.WriteLine("something else went wrong: " + oth.Message);
    }
    
    // keep going after the mess
    Console.WriteLine("still alive after catch");
  }
  
  
  public static void Main(string[] args)
  {
    /*
    
    6. Demonstrate ArgumentOutOfRangeException

    * Hint => 

      * Use string.Substring() with start index greater than the end index to generate an ArgumentOutOfRangeException.

      * Use try-catch to handle the exception.
    
    */
    
    Console.WriteLine("first trying the bad substring call");
    
    try
    {
      badsub ();   // this throws hard
    }
    catch (ArgumentOutOfRangeException e)
    {
      Console.WriteLine("caught the ArgumentOutOfRange from badsub");
      Console.WriteLine(e.Message);
    }
    
    Console.WriteLine() ;  
    
    Console.WriteLine("now the safe version with its own try catch");
    safesub ();
    
    // little pause so user can read everything
    Console.WriteLine("all done, press enter to exit..");
    Console.ReadLine();
    
  }
}
