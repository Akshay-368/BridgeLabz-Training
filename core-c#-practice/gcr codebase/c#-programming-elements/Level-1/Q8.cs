using System;
class Kmtomiles
{
    public static void Main()
    {
        /*8. Create a program to convert distance in kilometers to miles.
Hint:
Create a variable km and assign type as double as in double km;
Create Scanner Object to take user input from Standard Input that is the Keyboard as in Scanner input = new Scanner(System.in);
Use Scanner Object to take user input for km as in km = input.nextInt();
Use 1 mile = 1.6 km formulae to calculate miles and show the output
I/P => km
O/P => The total miles is ___ mile for the given ___ km

        */

        Console.WriteLine ( " Enter dist in km : " ) ;
        double km = Convert.ToDouble ( Console.ReadLine() ) ;
        double miles = km / 1.6 ;
        Console.WriteLine ( " The total miles is " + miles + " mile for the given " + km + " km " ) ;
    
    }
}