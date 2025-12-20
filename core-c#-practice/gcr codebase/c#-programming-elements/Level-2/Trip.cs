using System ;
class Trip
{
    public static void Main()
    {
        /* 8. Rewrite the Sample Program 2 with user inputs
        Hint:
        Create variables and take user inputs for name, fromCity, viaCity, toCity.
        Create variables and take user inputs for distances: fromToVia and viaToFinalCity in miles.
        Create variables and take the time taken for the journey.
        Finally, print the results and try to understand operator precedence.
        I/P => name, fromCity, viaCity, toCity, fromToVia, viaToFinalCity, timeTaken
        O/P => The results of the trip are: ___, ___, and ___
        */

        // user inputs for the trip details and creating variables as per the question given
        Console.WriteLine (" Enter your name: " ) ;
        string name = Console.ReadLine();

        Console.WriteLine( " Enter the starting city ( intital point of the journey ) : " ) ;
        string fromCity = Console.ReadLine();

        Console.WriteLine ( " Enter the via city : " ) ;
        string viaCity = Console.ReadLine() ;

        Console.WriteLine( " Enter the destination city ( final city of the journey ) : " ) ;
        string toCity = Console.ReadLine();

        // Now user inputs for distances
        Console.WriteLine( " Enter the distance from starting city to via city ( in miles ) : " ) ;
        double fromToVia = Convert.ToDouble ( Console.ReadLine());

        Console.WriteLine( " Enter the distance from via city to final city (in miles ) : " ) ;
        double viaToFinalCity = double.Parse( Console.ReadLine() );

        // Now another user input for time taken
        Console.WriteLine( " Enter the total time taken for the journey ( in hours): " ) ;
        double timeTaken = double.Parse(Console.ReadLine());

        // Now final calculations and we follow BODMAS ( Brackets , Orders , Division / Multiplication , Addition , Subtraction )

        double totalDistance = fromToVia + viaToFinalCity;   // operator precedence : + evaluated left to right
        double averageSpeed = totalDistance / timeTaken;     // division has higher precedence than addition

        // Now ouputing the reults
        Console.WriteLine( " The results of the trip are: " );
        Console.WriteLine(" Traveler: {0} ", name ) ;
        Console.WriteLine( " Route: {0} -> {1} -> {2} ", fromCity, viaCity, toCity ) ;
        Console.WriteLine( " Total Distance: {0} miles ", totalDistance );
        Console.WriteLine(" Time Taken: {0} hours ", timeTaken );
        Console.WriteLine( " Average Speed: {0} miles/hour ", averageSpeed);
    }
}