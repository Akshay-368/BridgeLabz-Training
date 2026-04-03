using System;

class Area_rectangle
{
    public static void Main ()
    {
        int l ; // length
        int b ; // breadth
        Console.WriteLine ( " Enter the length of the rectanngle : ") ; // taking input from user for length
        // Using Parse method to convert string input to integer which is a static method that takes a string to target type.
        l = int.Parse(Console.ReadLine()) ; // converting string input ( length ) from user to integer using Parse method
        Console.WriteLine (" Enter the breadth of the rectangle : " ) ; // taking input from user for breadth
        b = int.Parse(Console.ReadLine()) ; // converting string input ( breadth ) from user to integer using Parse method

        // Now calculating perimeter of rectangle
        int perimeter = 2 * ( l + b ) ; // Using formula to calculate perimeter of rectangle
        Console.WriteLine ( " The perimeter of the rectangle ( as per the given length and breadth ) is : " + perimeter + " units " ) ;

        // Now calculating area of rectangle
        int area = l * b ; // using formula to calculate area of rectangle
        Console. WriteLine ( " The area of the rectangle is : " + area + " square units " ) ;
    }
}
