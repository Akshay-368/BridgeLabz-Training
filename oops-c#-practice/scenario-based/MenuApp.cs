using System;

public class caf
{
  
  public static string[] menu = new string[10];
  
  public static void setupmenu()
  {
    // filling the menu with 10 fixed items, doing it here so its ready
    
    menu[0] = "Burger - 150";
    menu[1] = "Pizza Slice - 120";
    menu[2] = "French Fries - 80";
    menu[3] = "Sandwich - 100";
    menu[4] = "Pasta - 180";
    menu[5] = "Cold Coffee - 90";
    menu[6] = "Lemonade - 50";
    menu[7] = "Ice Cream - 70";
    menu[8] = "Brownie - 100";
    menu[9] = "Wrap - 130";
  }
  
  
  public static void dispmenu()
  {
    // printing the full menu with numbers
    
    Console.WriteLine("Cafeteria Menu ");
    Console.WriteLine();
    
    for (int i = 0; i < menu.Length; i++)
    {
      Console.WriteLine( (i+1) + ". " + menu[i] );
    }
    
    Console.WriteLine();
  }
  
  
  public static string getitembyidx(int idx)
  {
    // return the item at given index (user types 1-10 so adjust)
    
    int realidx = idx - 1;
    
    if (realidx < 0 || realidx >= menu.Length)
    {
      return "Invalid choice! No such item";
    }
    
    return menu[realidx];
  }
  
  
  public static void Main()
  {
    /*
    Cafeteria Menu App
    Focus: Arrays, Methods
    ● Scenario: The campus cafeteria offers 10 fixed items daily. You need to build a system to display menu items and take orders based on user input.
    ● Requirements:
    ● Store items in a string[] array.
    ● Print the menu with index numbers.
    ● Allow the user to select an item by index.
    ● Use methods like DisplayMenu(), GetItemByIndex().
    */
    
    setupmenu(); // load the items first
    
    Console.WriteLine("Welcome to Campus Cafeteria!");
    Console.WriteLine();
    
    dispmenu();
    
    Console.WriteLine();
    Console.WriteLine("enter the number of item you want to order (1-10)");
    Console.WriteLine("or type 0 to exit");
    Console.WriteLine();
    
    bool ordering = true;
    
    while (ordering)
    {
      Console.WriteLine("waiting for your choice...");
      string inp = Console.ReadLine();
      
      if (int.TryParse(inp, out int choice))
      {
        if (choice == 0)
        {
          Console.WriteLine("thanks for visiting! come again");
          ordering = false;
        }
        else if (choice >= 1 && choice <= 10)
        {
          string selected = getitembyidx(choice);
          Console.WriteLine("you ordered: " + selected);
          Console.WriteLine("enjoy your meal!");
          Console.WriteLine();
        }
        else
        {
          Console.WriteLine("please choose between 1 and 10 only");
        }
      }
      else
      {
        Console.WriteLine("thats not a number, try again");
      }
      
      Console.WriteLine();
    }
    
    Console.WriteLine("press enter to close the app..");
    Console.ReadLine();
    
  }
}
