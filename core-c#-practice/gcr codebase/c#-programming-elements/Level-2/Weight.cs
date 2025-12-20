using System ;
class Weight
{
    public static void Main()
    {
        /*12. Create a program to convert weight in pounds to kilograms.
        Hint:
        1 pound = 2.2 kg
        I/P => weight (in pounds)
        O/P => The weight of the person in pounds is ___ and in kg is ___
        */

        Console.WriteLine( " enter the weight in kg : " );
        double weightKg = double.Parse ( Console.ReadLine() ) ;
        double weightPound = weightKg * 2.2 ;

        Console.WriteLine ( $" The weight of the person in pounds is {weightPound} and in kg is {weightKg}");
    }
}