using System;

public class inv
{
  
  public static string[] parsinv(string inp)
  {
    // this method splits the messy input into tasks only
    // we gonna find the amounts and cut them out with dash and after
    
    string[] parts = inp.Split(','); // first rough split by comma
    
    string[] tasks = new string[parts.Length];
    int cnt = 0;
    
    for (int i = 0; i < parts.Length; i++)
    {
      string bit = parts[i].Trim(); // remove extra spaces
      
      // find where the amount starts - look for " - " pattern
      int dashpos = bit.LastIndexOf(" - ");
      
      if (dashpos != -1)
      {
        // take only the left part before " - "
        string taskname = bit.Substring(0, dashpos).Trim();
        tasks[cnt] = taskname;
        cnt++;
      }
      else
      {
        // if no dash maybe whole thing is task? kind of rare  but keep it
        tasks[cnt] = bit;
        cnt++;
      }
    }
    
    // resize array to actual count (bit unconventional but works)
    string[] realtasks = new string[cnt];
    for (int j = 0; j < cnt; j++)
    {
      realtasks[j] = tasks[j];
    }
    
    return realtasks;
  }
  
  
  public static double gettot(string inp)
  {
    // extract all amounts and add them up
    // amounts are after " - " and before INR or end
    
    double total = 0;
    
    string[] parts = inp.Split(',');
    
    foreach (string p in parts)
    {
      string trimmed = p.Trim();
      
      int dash = trimmed.LastIndexOf(" - ");
      
      if (dash != -1)
      {
        string rightpart = trimmed.Substring(dash + 3).Trim();
        
        // remove " INR" if present
        if (rightpart.EndsWith(" INR"))
        {
          rightpart = rightpart.Substring(0, rightpart.Length - 4).Trim();
        }
        
        // now try to parse the number
        if (double.TryParse(rightpart, out double amt))
        {
          total = total + amt;
        }
      }
    }
    
    return total;
  }
  
  
  public static void Main(string[] args)
  {
    /*
    Invoice Generator for Freelancers
    Focus: Strings, Methods
    ● Scenario: You're building an app for freelancers to generate invoice descriptions.
      Requirements:
    ● Accept input like: "Logo Design - 3000 INR, Web Page - 4500 INR".
    ● Split the string to extract task names and amounts.
    ● Calculate total invoice amount.
    ● Example Methods:
    ● ParseInvoice(string input)
    ● GetTotalAmount(string[] tasks)
    */
    
    Console.WriteLine("Freelancer Invoice Generator");
    Console.WriteLine();
    
    Console.WriteLine("enter your services like: Task Name - amount INR, another - amount INR");
    Console.WriteLine("example: Logo Design - 3000 INR, Web Page - 4500 INR");
    Console.WriteLine();
    
    Console.WriteLine("waiting for you to type the invoice line...");
    string line = Console.ReadLine();
    
    if (line == null || line.Trim() == "")
    {
      Console.WriteLine("nothing entered, using demo data");
      line = "Logo Design - 3000 INR, Web Page - 4500 INR, Banner - 1500 INR";
    }
    
    Console.WriteLine();
    Console.WriteLine("=== Invoice Breakdown ===");
    
    string[] tasklist = parsinv(line);
    
    for (int i = 0; i < tasklist.Length; i++)
    {
      Console.WriteLine("Task " + (i+1) + ": " + tasklist[i]);
    }
    
    Console.WriteLine();
    
    double totamt = gettot(line);
    
    Console.WriteLine("Total Amount: " + totamt + " INR");
    Console.WriteLine();
    
    Console.WriteLine("invoice ready! you can send this to client");
    
    Console.WriteLine("press enter to exit..");
    Console.ReadLine();
    
  }
}
