using System;

public class UpperCase
{
  
  public static string myup (string s)
  {
    // this converts whole string to uppercase using ascii stuff
    // no using ToUpper, doing it manual like the hint says
    
    char[] arr = s.ToCharArray();  // get chars to mess with
    
    for (int i = 0; i < arr.Length; i++)
    {
      char c = arr[i];
      
      // only change if its lowercase letter
      // a=97 to z=122 in ascii
      if (c >= 'a' && c <= 'z')
      {
        // subtract 32 to get uppercase
        arr[i] = (char)(c - 32);
      }
      // else leave it alone (numbers, symbols, already upper)
    }
    
    // turn back to string
    return new string(arr);
  }
  
  
  public static void Main(string[] args)
  {
    /*
    
    9. Convert Text to Uppercase

    * Hint => 

    - Write a method to convert each character in a string to uppercase using ASCII logic (char manipulation).

    - Compare the result with the built-in string.ToUpper().
    
    */
    
    Console.WriteLine("waiting for user to type some text...");
    string inp = Console.ReadLine();
    
    if (inp == null) inp = ""; // safety tho unlikely
    
    Console.WriteLine();
    
    string manual = myup (inp);
    
    Console.WriteLine("my manual uppercase: " + manual);
    
    string built = inp.ToUpper();
    
    Console.WriteLine("built in ToUpper:    " + built);
    
    // compare them
    if (manual == built)
    {
      Console.WriteLine("both match! good job");
    }
    else
    {
      Console.WriteLine("uh oh they different");
    }
    
    Console.WriteLine("press enter to exit..");
    Console.ReadLine();
    
  }
}
