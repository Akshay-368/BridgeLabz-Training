using System;

public class FormatException
{
  
  public static void badparse ()
  {
    // this will throw FormatException cuz we try to parse letters as number
    
    string val = "notanumber";
    
    // trying to turn string into int but it has letters, boom
    int num = int.Parse(val);
    
    // wont reach here
    Console.WriteLine("parsed: " + num);
  }
  
  
  public static void safeparse ()
  {
    // same bad parse but now inside try catch so we handle it nicely
    
    string txt = "abc123";
    
    try
    {
      // this is gonna fail hard
      int res = int.Parse(txt);
      
      // only prints if somehow works (it wont)
      Console.WriteLine("success got number: " + res);
    }
    catch (FormatException fe)
    {
      // yep caught the format error
      Console.WriteLine("hey! thats not a valid number dude");
      Console.WriteLine("error says: " + fe.Message);
      
      // print whole thing for more details
      Console.WriteLine(fe.ToString());
    }
    catch (Exception ex)
    {
      // just in case something else
      Console.WriteLine("other error: " + ex.Message);
    }
    
    // program continues
    Console.WriteLine("moving on after the mess");
  }
  
  
  public static void Main(string[] args)
  {
    /*
    
    7. Demonstrate FormatException

    * Hint => 

      * Use int.Parse() on a non-numeric string to generate FormatException.

      * Use try-catch to handle the exception.
    
    */
    
    Console.WriteLine("trying the bad parse first");
    
    try
    {
      badparse ();   // throws format exception
    }
    catch (FormatException e)
    {
      Console.WriteLine("caught format error from badparse");
      Console.WriteLine(e.Message);
    }
    
    Console.WriteLine() ;
    
    Console.WriteLine("now safe parse with own try catch");
    safeparse ();
    
    Console.WriteLine("done with demo, press enter to quit..");
    Console.ReadLine();
    
  }
}
