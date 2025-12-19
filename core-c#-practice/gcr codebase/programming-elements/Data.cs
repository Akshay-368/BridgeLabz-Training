using System;
class Data {
    public static void Main() {
        Console.WriteLine("Data types of C# and their conversions.");

        int i = 10;
        long l = i; // Implicit conversion from int to long
        float f = i ; // Implicit conversion from int to float
        double d = f; // Implicit conversion from float to double

        Console.WriteLine ( " Implicit COnversions: " );
        Console.WriteLine ( "int i : " + i + " Conversion : int to long: " + l );
        Console.WriteLine ( "int i : " + i + " Conversion : int to float: " + f );
        Console.WriteLine ( "float f : " + f + " Conversion : float to double: " + d );

        // Explicit conversion
        Console.WriteLine ( " Explicit Conversions: " );
        double d1 = 9.8 ;
        float f1 = (float ) d1 ; // Explicit conversion from double to float
        long l1 = (long ) f1 ; // Explicit conversion from float to long
        int i1 = (int ) l1 ; // Explicit conversion from long to int

        // Main reason we need to mention explicit conversion is to avoid data loss
        // for when we convert from a larger data type to a smaller data type.

        Console.WriteLine ( "double d1 : " + d1 + " Conversion : double to float: " + f1 );
        Console.WriteLine ( "float f1 : " + f1 + " Conversion : float   to long: " + l1 );
        Console.WriteLine ( "long l1 : " + l1 + " Conversion : long   to int: " + i1 );

        
    }
}