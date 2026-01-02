using System;

public static class prog
{
    public static void Main( string[] args )
    {
        /*
        *Bus Route Distance Tracker 🚌
        Each stop adds distance.
        ● Ask if the passenger wants to get off at a stop.
        ● Use a while-loop with a total distance tracker.
        ● Exit on user confirmation.
        */
        
        // this is the bus distance tracker thingy
        
        double td = 0; // total distance so far
        int sc = 1; // stop count
        
        Console.WriteLine("Bus started , welcome aboard !");
        
        bool st = true; // stay on bus
        
        while(st)
        {
            // each stop adds some distance , lets say random but here fixed for simple
            double ad = 5.5; // distance to next stop
            td = td + ad;
            
            Console.WriteLine("Reached stop number " + sc );
            Console.WriteLine("Total distance traveled : " + td + " km");
            
            // now ask passenger
            Console.WriteLine("Do you want to get off here ? (type yes or no)");
            
            string ans = Console.ReadLine();
            ans = ans.Trim().ToLower(); // make it easy
            
            if(ans == "yes" || ans == "y")
            {
                st = false; // get off
                Console.WriteLine("Okay , getting off at stop " + sc );
                Console.WriteLine("Final distance : " + td + " km");
            }
            else if(ans == "no" || ans == "n")
            {
                Console.WriteLine("Cool , staying on bus");
                sc++; // next stop
            }
            else
            {
                Console.WriteLine("didnt understand , assuming you stay");
                sc++; // continue anyway
            }
            // why we do this loop ? coz passenger decides when to stop
        }
        
        Console.WriteLine("Bus tracker part over");
    }
}
