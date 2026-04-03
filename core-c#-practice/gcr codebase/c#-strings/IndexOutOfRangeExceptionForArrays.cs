using System;

public class IndexOutOfRangeExceptionForArrays
{
  
  public static void badarr ()
  {
    // gonna throw IndexOutOfRangeException by accessing wrong index in array
    
    int[] nums = {10, 20, 30, 40};
    
    // array has 4 elements, indexes 0 to 3, we try 8
    int val = nums[8];
    
    // never prints
    Console.WriteLine(val);
  }
  
  
  public static void safearr ()
  {
    // same bad access but wrapped in try catch
    
    string[] words = {"one", "two", "three"};
    
    try
    {
      // words has length 3, index 5 is too far
      string w = words[5];
      
      // wont print
      Console.WriteLine("found word: " + w);
    }
    catch (IndexOutOfRangeException ire)
    {
      // caught the index error
      Console.WriteLine("tried to read outside the array bounds!");
      Console.WriteLine("message: " + ire.Message);
      
      // full dump
      Console.WriteLine(ire.ToString());
    }
    catch (Exception gen)
    {
      Console.WriteLine("other problem: " + gen.Message);
    }
    
    // keeps running
    Console.WriteLine("still good after catching");
  }
  
  
  public static void Main(string[] args)
  {
    /*
    
    8. Demonstrate IndexOutOfRangeException for Arrays

    * Hint => 

    - Access an invalid index of an array to generate an IndexOutOfRangeException.

    - Use try-catch to handle the exception.
    
    */
    
    Console.WriteLine("first the bad array access");
    
    try
    {
      badarr ();   // throws index out of range
    }
    catch (IndexOutOfRangeException e)
    {
      Console.WriteLine("caught array index error");
      Console.WriteLine(e.Message);
    }
    
    Console.WriteLine();
    
    Console.WriteLine("now the safe version");
    safearr ();
    
    Console.WriteLine("all finished, hit enter to close...");
    Console.ReadLine();
    
  }
}
