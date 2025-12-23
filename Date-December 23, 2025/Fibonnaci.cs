using System;

class Fibonacci
{
    public static void Main()
    {
        Console.Write(" Enter the minimum value of the range : ");
        int start = int.Parse(Console.ReadLine());

        Console.Write("Enter the maximum value of the range: ");
        int stop = Convert.ToInt32(Console.ReadLine());
        
        // The entire fibonnaci lies in a , b , a + b , ... 
        // As next number is just the sum of the previous two values

        if (start < 0 || stop < 0 || start > stop )
        {
            // Both values should be greater than 0 and start should be greater than stop.
            Console.WriteLine("Invalid range...");
            return ;
        }

        Console.WriteLine($"Fibonacci sequence in range {start} to {stop} :"); // using string interpolation , which will help compiler to consider the value in curved paranthesis.

        int a = 0, b = 1; // Intiliaizing the basic values of the fibonnaci sequence
        
        // Intializing the loop till we reach stop from a
        while (a <= stop )
        {
            if (a >= start)
                Console.Write(a + " "); // Including a in the output if it lies in the range

            int temp = a + b; // Intiliazzing the temporary var and adding them to go to next fibonnaci number as required
            // Now swapping the values , a will go to next value that is in b
            // Now b will go to next number that is in temp.
            a = b ;
            b = temp ;
        }

        Console.WriteLine();
    }
}
