using System;

public class IndexOutOfRange
{
    
    public static void bad()
    {
      // this method will throw the IndexOutOfRangeException on purpose
      // we have a small string and try to get char at position that doesnt exist
      
      string s = "hi";
      
      // s has length 2, indexes 0 and 1 are ok, 5 is way out
      char c = s[5];   // boom! exception here
      
      // we never reach this line actually
      Console.WriteLine(c);
    }
    
    
    public static void safe()
    {
      // here we try the bad thing but catch the error so program doesnt crash
      
      string txt = "hello";
      
      try 
      {
        // trying to get char at index 10 but string is only 5 chars long
        char ch = txt[10];
        
        // if no error, print it (wont happen)
        Console.WriteLine("got char: " + ch);
      }
      catch (IndexOutOfRangeException ex) 
      {
        // ok caught the error, now print something useful
        Console.WriteLine("oops! tried to read past the end of string");
        Console.WriteLine("error message: " + ex.Message);
        
        // maybe print the whole exception for more info
        Console.WriteLine(ex.ToString());
      }
      catch (Exception gen) 
      {
        // just in case something else goes wrong, catch it too
        Console.WriteLine("some other error happened: " + gen.Message);
      }
      
      // after catch we continue normally
      Console.WriteLine("program keeps running fine");
    }
    
    
    public static void Main(string[] args) 
    {
      /*
      
      5. Demonstrate IndexOutOfRangeException

      * Hint => 

      - Access an invalid index of a string using charAt() (string[index] in C#) to generate the exception.

      - Write another method with try-catch to handle the exception.
      
      */
      
      Console.WriteLine("first we run the bad method (will crash if not called carefully)");
      
      // we gonna call bad inside try catch so whole program doesnt die
      try 
      {
        bad();   // this throws
      }
      catch (IndexOutOfRangeException e) 
      {
        Console.WriteLine("caught the out of range error from bad method");
        Console.WriteLine(e.Message);
      }
      
      Console.WriteLine(); // empty line for nicer look
      
      Console.WriteLine("now running the safe method");
      safe();
      
      // wait for user to press enter before closing
      Console.WriteLine("press enter to finish...");
      Console.ReadLine();
      
    }
}
