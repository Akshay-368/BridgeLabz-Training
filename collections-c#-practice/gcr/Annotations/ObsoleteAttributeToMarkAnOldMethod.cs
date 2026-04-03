using System;

public class legacy 
{
    public class LegacyAPI
    {
        [Obsolete("This method is old, use NewFeature() instead")]
        public void OldFeature()
        {
            Console.WriteLine("This is the old feature - don't use anymore");
        }

        public void NewFeature()
        {
            Console.WriteLine("This is the new improved feature!");
        }
    }

    public static void Main(string[] args) 
    {
        /*
        Exercise 2: Use Obsolete Attribute to Mark an Old Method
        Problem Statement: Create a class LegacyAPI with an old method OldFeature(), 
        which should not be used anymore. Instead, introduce a new method NewFeature().
        Steps to Follow:
        1. Define a class LegacyAPI.
        2. Mark OldFeature() as [Obsolete].
        3. Call both methods and observe the warning.
        */

        Console.WriteLine("Obsolete Attribute Demo ");

        LegacyAPI api = new LegacyAPI();

        Console.WriteLine("Calling old method :");
        api.OldFeature();

        Console.WriteLine(" Calling new method:");
        api.NewFeature();

        Console.WriteLine(" Press any key...");
        Console.ReadKey();
    }
}
