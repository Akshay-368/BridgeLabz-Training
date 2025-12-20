using System ;
class AtheletRun
{
    public static void Main ()
    {
        /*
        9. An athlete runs in a triangular park with sides provided as input by the user in meters.
        If the athlete wants to complete a 5 km run, then how many rounds must the athlete complete?
        Hint:
        The perimeter of a triangle is the addition of all sides.
        Rounds = distance / perimeter
        I/P => side1, side2, side3
        O/P => The total number of rounds the athlete will run is ___ to complete 5 km
        */

        Console.WriteLine (" Enter the length of the sides of the triangular park where the athelete is running ( in metres )");
        string s = Console.ReadLine();
        string [] i = s.Split() ;
        double s1 , s2 , s3 ; // sides of the trinagle
        ( s1 , s2 , s3 ) = ( Convert.ToDouble (i[0]) , Convert.ToDouble (i[1]) , double.Parse (i [2]) ) ; // using tuple assignment again

        // Now perimeter of traingle will be :
        double perimeter = s1 + s2 + s3 ;
        // Now rounds will be
        Console.WriteLine (" Enter the distance to be convered ( in metres )  ( default is 5000 m ): " );
        string input = Console.ReadLine();
        double distance = string.IsNullOrWhiteSpace(input ) ? 5000 : double.Parse( input );
        double rounds = distance / perimeter ;

        // Output
        Console.WriteLine ( " The total number of rounds the athlete will run is {0} to complete distance of {1} km ." , rounds , distance / 1000 );

        


    }
}