using System;

public class WordsLength
{
  
  public static int mylen (string s)
  {
    // count length without using .Length
    // convert to char array and loop till null basically
    
    char[] arr = s.ToCharArray();
    int cnt = 0;
    
    foreach(char c in arr)
    {
      cnt++;
    }
    
    return cnt;
  }
  
  
  public static string[][] getwords (string txt)
  {
    // split into words without Split()
    // find spaces manually and extract words
    
    int len = mylen(txt);
    string[] words = new string[20]; // assume not more than 20 words
    int wcnt = 0;
    
    int start = 0;
    
    for(int i=0; i<len; i++)
    {
      char c = txt[i];
      
      if(c == ' ' || i == len-1)
      {
        int end = (i == len-1 && c != ' ') ? i+1 : i;
        
        int wordlen = end - start;
        string word = "";
        
        for(int j=start; j<end; j++)
        {
          word += txt[j];
        }
        
        words[wcnt] = word;
        wcnt++;
        
        start = i+1; // skip the space
      }
    }
    
    // now make 2d array [word, length]
    string[][] res = new string[wcnt][];
    
    for(int k=0; k<wcnt; k++)
    {
      string wd = words[k];
      int wl = mylen(wd);
      
      res[k] = new string[]{ wd, wl.ToString() };
    }
    
    return res;
  }
  
  
  public static void Main(string[] args)
  {
    /*
    
    11. Split Text into Words and Display Word Lengths

    * Hint => 

    - Write a method to split text into words without using string.Split(). Use char comparison for spaces.

    - Write another method to calculate string length without string.Length.

    - Return a 2D array where each row contains the word and its length.
    
    */
    
    Console.WriteLine("enter a sentence with spaces pls...");
    string sent = Console.ReadLine();
    
    if(sent == null) sent = "";
    
    Console.WriteLine();
    
    string[][] data = getwords (sent);
    
    Console.WriteLine("words and their lengths:");
    Console.WriteLine();
    
    for(int i=0; i<data.Length; i++)
    {
      string word = data[i][0];
      string leng = data[i][1];
      
      Console.WriteLine("word: " + word + "   length: " + leng);
    }
    
    Console.WriteLine();
    Console.WriteLine("thats all, press enter to finish");
    Console.ReadLine();
    
  }
}
