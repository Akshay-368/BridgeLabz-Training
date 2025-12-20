using System ;
class Doubleoperations
{
    public static void Main()
    {
        /*3. Similarly, write the DoubleOpt program by taking double values and doing the same operations.
I/P => a, b, c
O/P => The results of Double Operations are ___, ___, and ___

The operations are : a + b * c, a * b + c, c + a / b, and a % b + c.
        */

        Console.WriteLine (" Enter the first double number a : ");
        double a = double.Parse (Console.ReadLine());
        // Using different way to take the input just for practice purpose
        Console.WriteLine( " Enter the second double number b  and c (seperated by space in a single Line ) : ");
        string i = Console.ReadLine();
        string[] s = i.Split();
        double b = Convert.ToDouble ( s[0] );
        double c = double.Parse  ( s[1] ) ; // trying parse function  as it takes string input and convert it to target type mentioned using . operater

        // Now doing the operations : as per the question
        double o1 = Convert.ToDouble ( a + b * c ) ; // operation 1
        double o2 = (double) ( a * b + c ) ; // operation 2
        double o3 = c + a / b ; // operation 3 since the answer will be in int and the target storing variable is in double ,
        // so no explicit conversion is required
        double o4 = a % b + c ; // operation 4

        // Now printing

        Console.WriteLine ($"The results of Double Operations are {o1} , {o2} , {o3} and {o4}");



    }
}