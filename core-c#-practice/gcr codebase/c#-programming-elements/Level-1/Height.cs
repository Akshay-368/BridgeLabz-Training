using System ;
class Height {
    public static void Main()
    {
        /*10. Write a program that takes your height in centimeters and converts it into feet and inches
Hint: 1 foot = 12 inches and 1 inch = 2.54 cm
I/P => height
O/P => Your Height in cm is ___ while in feet is ___ and inches is ___
        */
        Console.WriteLine ( " Enter your height in cm : " ) ;
        double hcm = Convert.ToDouble ( Console.ReadLine () ) ;
        double hinch = hcm / 2.54 ;
        int f = (int)hinch / 12 ;
        double inch = hinch % 12 ;
        Console.WriteLine ( " Your Height in cm is " + hcm + " while in feet is " + f + " and inches is " + inch ) ;
    }
}