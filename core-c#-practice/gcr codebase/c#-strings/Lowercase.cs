using System;

public class Lowercase
{
  
  public static string mylow (string s)
  {
    // manual lowercase using ascii diff
    // lowercase a=97 z=122, uppercase A=65 Z=90
    // add 32 to upper to get lower
    
    char[] chars = s.ToCharArray();
    
    for(int i=0; i<chars.Length; i++) 
    {
      char ch = chars[i];
      
      if(ch >= 'A' && ch <= 'Z')
      {
        chars[i] = (char)(ch + 32);
      }
      // leave others as is
    }
    
    return new string(chars);
  }
  
  
  public static void Main(string[] args)
  {
    /*
    
    10. Convert Text to Lowercase

    * Hint => 

    - Write a method to convert each character in a string to lowercase using ASCII logic (char manipulation).

    - Compare the result with the built-in string.ToLower().
    
    */
    
    Console.WriteLine("type whatever text you want...");
    string txt = Console.ReadLine();
    
    if(txt == null) txt = "";
    
    Console.WriteLine() ;
    
    string mine = mylow (txt);
    Console.WriteLine("my own lowercase: " + mine);
    
    string normal = txt.ToLower();
    Console.WriteLine("normal ToLower:   " + normal);
    
    Console.WriteLine();
    
    if(mine == normal)
    {
      Console.WriteLine("yep they are same");
    }
    else
    {
      Console.WriteLine("something wrong, not matching");
    }
    
    Console.WriteLine("all done, hit enter..");
    Console.ReadLine();
    
  }
}
