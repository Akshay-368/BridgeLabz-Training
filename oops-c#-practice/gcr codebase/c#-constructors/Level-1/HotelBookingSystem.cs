using System;

public class htl
{
    string guest;
    string room;
    int nights;
    
    // default
    public htl()
    {
        guest = " No Guest";
        room =  "Standard";
        nights = 1;
    }
    
    // parameterized
    public  htl(string g , string r , int n)
    {
        guest = g;
        room = r;
        nights = n;
    }
    
    // copy
    public htl(htl old)
    {
        guest = old.guest ;
        room = old.room;
        nights = old.nights;
    }
    
    public void print()
    {
        Console.WriteLine( "Guest   : " + guest);
        Console.WriteLine(" Room    : " + room);
        Console.WriteLine ("Nights  : " + nights);
    }
    
    public static void Main(string[] args)
    {
        /*
        4. Hotel Booking System
           * Create a HotelBooking class with attributes guestName, roomType, and nights.
           * Use default, parameterized, and copy constructors to initialize bookings.
        */
        
        htl b1 = new htl();
        b1.print();
        
        Console.WriteLine ();
        
        htl b2 = new htl ("Sara", "Deluxe", 3);
        b2.print();
        
        Console.WriteLine();
        
        htl b3 = new htl(b2); // copy
        Console.WriteLine  ( " copied booking");
        b3.print();
        
        Console.WriteLine( "all done, enter to close");
        Console.ReadLine();
    }
}
