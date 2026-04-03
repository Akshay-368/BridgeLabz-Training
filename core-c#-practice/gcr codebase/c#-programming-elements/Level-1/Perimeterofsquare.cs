using System ;
class PerimeterOfSquare
{
    static void Main()
    {
        /*
        13. Write a program to find the side of the square whose perimeter you read from user
Hint: Perimeter of Square is 4 times side
I/P => perimeter
O/P => The length of the side is ___ whose perimeter is ____

        */

        Console.WriteLine(" Enter the perimeter of the square ( units ) : ");
        double perimeter = double.Parse(Console.ReadLine()) ;
        double sideLength = perimeter / 4.0 ;
        Console.WriteLine(" The length of the side is : " +sideLength + " units and the perimeter is : " +  perimeter + " units" ) ;
    }
}