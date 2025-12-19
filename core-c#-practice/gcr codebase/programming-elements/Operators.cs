using System ;
class Operators
{
    public static void Main()
    // Here public is an access modifier which makes the Main method accessible from outside the class and it has to be public for it is an entry point ( only single one here)
    // The static keyword means that the method belongs to the class itself rather than to any specific instance of the class 
    // and it can be called without creating an instance of the class
    // Void is the return type of the method which means that this method does not return any value as remember Main method is the entry point of the program
    // and it is the compiler which calls this method to start the execution of the program and thus there is no need to return any value from this method directly to that compiler
    // though we do have a way to return an integer value from Main method to the operating system to indicate the exit status of the program
    // but that is done using another syntax public static int Main() and then returning an integer value at the end of the method such as return 0 ;
    // and Main is the name of the method which is predefined and recognized by the C# compiler as the entry point of the program
    // for strings[] args is an array of strings which can be used to pass command-line arguments to the program when it is executed from the command line interface
    // as string can take multiple words with spaces and thus it is defined as an array of strings and args is just a name given to that array which can be any valid identifier name
    {
        int a = 10 ;
        int b = 2 ;
        
        // Arithemetic Operators are mathemetical operators use for performing basic arithmetic operators 
        // such as addition (+) , subtraction (-) , multiplication (*) , division (/) , modulus (%) , etc.

        Console.WriteLine ( " Addition arithmentic operator :  a + b = " + ( a + b ) ) ; // Addition
        Console.WriteLine ( " Subtraction arthimetic operator : a - b = " + (a - b ) ) ; // Subtraction
        Console.WriteLine ( " Multiplication arithmetic operator : a * b = " + ( a * b ) ) ; // Multiplication
        Console.WriteLine ( " Division arithmetic operator : a / b = " + ( a / b ) ) ; // Division
        Console.WriteLine ( " Moduluos arithmetic operator is : a % b = " + ( a % b ) ) ; // Modulus

        // Assignment Operators , are used for assigning values to variables
        // Such as  equal to (=) , plus equal to ( += ) , minus equal to ( -= ) , multiply equal to ( *= ) , divide equal to ( /= ) , 
        // modulus equal to ( %= )
        // Example of assignment operators
        int c = 5 ; // equal to operator
        Console.WriteLine ( " Value of c using equal to operator is : c = " + c ) ;

        c += 2 ; // plus equal to operator , which can be expressed as c = c + 2
        Console.WriteLine ( " Value of c using plus equal to opertaor is : "  + c) ;
        c -= 2 ; // minus equal to operator , which can be expressed as c = c - 2
        Console.WriteLine ( " Value of c using minus equal to operator is : " + c ) ;
        c *= 2 ; // multiply equal to operator , which can be expressed as c = c * 2
        Console.WriteLine ( " Value of c using multiply equal to operator is : " + c ) ;
        c /= 2 ; // divide equal to operator , which can be expressed as c = c / 2
        Console.WriteLine ( " Value of c using divide equal to operator is : " + c ) ;
        c %= 2 ; // modulus equal to operator , which can be expressed as c = c % 2
        Console.WriteLine ( " Value of c using modulus equal to operator is : " + c ) ;

        // Comparison Operators , are used for comparing two values
        // Such as equal to ( == ) , not equal to ( != ) , greater than ( > ) , less than ( < ) , greater than or equal to ( >= ) , less than or equal to ( <= )
        // Now let's see examples of comaparison operators
        Console.WriteLine ( " Is a equal to be ? : a == b = " + ( a == b )) ; // equal to operator
        Console.WriteLine ( " Is a not equal to b ? : a != b = " + ( a != b ) )  ; // not equal to operator
        Console.WriteLine ( " Is a greater than b ? : a > b = " + ( a > b ) ) ; // greater than operator
        Console.WriteLine ( " Is a less than b ? : a < b = " + ( a < b ) ) ; // less than operator
        Console.WriteLine ( " Is a greater than or equal to b ? : a >= b = " + ( a >= b ) ) ; // greater than or equal to operator
        Console.WriteLine ( " Is a less than or equal to b ? : a <= b = " + ( a <= b ) ) ; // less than or equal to operator

        // Logical Operators , are used for combining multiple boolean expressions
        // Such as AND ( && ) , OR ( || ) , NOT ( ! )
        // Now let's see examples of logical operators
        bool x = true ;
        bool y = false ;
        Console.WriteLine ( " Logical AND ( && ) operator : x && y = " + ( x && y ) ) ; // AND operator
        Console.WriteLine ( " Logical OR ( || ) operator : x || y = " + ( x || y ) ) ; // OR operator
        Console.WriteLine ( " Logical NOT ( ! ) operator : !x = " + ( !x ) ) ; // NOT operator

        // Now let's see what will happen if we combine comparison and logical operators
        int m = 5 ;
        Console.WriteLine ( " Value of m is : " + m ) ;
        int n = 10 ;
        Console.WriteLine ( " Value of n is : " + n ) ;
        Console.WriteLine ( " Combining comparison and logical operators : ( m < n ) && ( n > a ) = " + ( ( m < n ) && ( n > a ) ) ) ;
        Console.WriteLine ( " Combining comparison and logical operators : ( m > n ) || ( n > a ) = " + ( ( m > n ) || ( n > a ) ) ) ;  

        // Bitwise Operators , are used for performing bit-level operations on integers
        // Such as AND ( & ) , OR ( | ) ,
        // XOR ( ^ ) : which returns true if only one of the operands is true or if one bit is 1 , such as a ^ 0 = 1 and a ^ a = 0
        // , NOT ( ~ ) , left shift ( << )  which means multiply by 2, right shift ( >> ) which is equal to divide by 2

        // Now let's see some examples of bitwise opertaors
        int p = 5 ; // In binary :  0101
        int q = 4 ; // In binary :  0100
        Console.WriteLine ( " Bitwise AND ( & ) operator : p & q = " + ( p & q ) ) ; // AND operator , result is 4 ( 0100 )
        Console.WriteLine ( " Bitwise OR ( | ) operator : p | q = " + ( p | q ) ) ; // OR operator , result is 5 ( 0101 )
        Console.WriteLine ( " Bitwise XOR ( ^ ) operator : p ^ q = " + ( p ^ q ) ) ; // XOR operator , result is 1 ( 0001 )
        Console.WriteLine ( " Bitwise NOT ( ~ ) operator : ~p = " + ( ~p ) ) ; // NOT operator , result is -6 ( in binary : 1010 )
        Console.WriteLine ( " Bitwise left shift ( << ) operator : p << 1 = " + ( p << 1 ) ) ; // left shift operator , result is 10 ( 1010 )
        Console.WriteLine ( " Bitwise right shift ( >> ) operator : p >> 1 = " + ( p >> 1 ) ) ; // right shift operator , result is 2 ( 0010 )

        // Ternary Operator , is a shorthand way of writing an if-else statement thus it's a conditional operator
        // It takes three operands : a condition , a value if the condition is true ( execution when true), and a value if the condition is false ( this will execute if condition is false). 

        Console.WriteLine ( " Ternary operator : m > n ? m : n = " + ( m > n ? m : n ) ) ;
        // returns the value of m if m is greater than n, otherwise returns the value of n

        // Unary Operators , are operators that operate on a single operand
        // Such as increment ( ++ ) , decrement ( -- ) , unary plus ( + ) , unary minus ( - ) , logical NOT ( ! ) , bitwise NOT ( ~ )
        // Now let's see some examples of unary operators
        Console.WriteLine ( " Unary increment ( ++ ) operator : ++m = " + ( ++m ) ) ; // increment operator
        Console.WriteLine ( " Unary decrement ( -- ) operator : --n = " + ( --n ) ) ; // decrement operator
        Console.WriteLine ( " Unary plus ( + ) operator : +a = " + ( +a ) ) ; // unary plus operator
        Console.WriteLine ( " Unary minus ( - ) operator : -a = " + ( -a ) ) ; // unary minus operator
        Console.WriteLine ( " Unary logical NOT ( ! ) operator : !x = " + ( !x ) ) ; // logical NOT operator
        Console.WriteLine ( " Unary bitwise NOT ( ~ ) operator : ~b = " + ( ~b ) ) ; // bitwise NOT operator
        // Let's discuss the difference increment operator when used as prefix and postfix
        int r = 5 ;
        Console.WriteLine ( " Value of r is : " + r ) ;
        Console.WriteLine ( " Prefix increment operator : ++r = " + ( ++r ) ) ; // increments r by 1 and then returns the value of r
        r = 5 ; // resetting value of r
        Console.WriteLine ( " Postfix increment operator : r++ = " + ( r++ ) ) ; // returns the value of r and then increments r by 1
        Console.WriteLine ( " Value of r after postfix increment is : ( only now it will show the incremented value of r) " + r ) ; // showing the value of r after postfix increment

        // Now the difference between unary plus and increment operator
        Console.WriteLine ( " Unary plus operator : + m = " + ( +m ) ) ; // simply returns the value of m without any change
        Console.WriteLine ( " Increment operator : ++m = " + ( ++m ) ) ; // increments the value of m by 1 and then returns the value of m


        // Now another advance operator called Typeof Operator , which is used to get the System.Type object for a type
        Console.WriteLine ( " Typeof Operator : typeof( int ) = " + ( typeof( int ) ) ) ;
        Console.WriteLine ( " Typeof Operator : typeof( string ) = " + ( typeof( string ) ) ) ;

        // Another advanced operator called Sizeof Operator , which is used to get the size in bytes of a value type
        Console.WriteLine ( " Sizeof Operator : sizeof( int ) = " + ( sizeof( int ) ) + " bytes " ) ;
        Console.WriteLine ( " Sizeof Operator : sizeof( double ) = " + ( sizeof( double ) ) + " bytes " ) ;
        Console.WriteLine ( " Sizeof Operator : sizeof( char ) = " + ( sizeof( char ) ) + " bytes " ) ;
        Console.WriteLine ( " Sizeof Operator : sizeof( bool ) = " + ( sizeof( bool ) ) + " bytes " ) ;
        Console.WriteLine ( " Sizeof Operator : sizeof(float ) = " + ( sizeof ( float ) ) + " bytes " ) ;
        // It and typeof operator are compile-time operators
        // and they are written as small letters unlike other operators or functions which are written in camel case or pascal case
        // are they fucntions or methods ? No , they are operators . Why ? Because they operate on types rather than values
        // As both typeof and sizeof operators return information about types rather than performing actions on values
        // are they keywords ? Yes , they are keywords in C# programming language

        // Now let's do Type Casting Operator , which is used to convert a variable from one type to another
        double d = 9.8 ;
        Console.WriteLine ( " Value of d is : " + d ) ;
        int i = (int)d ; // casting double to int
        Console.WriteLine ( " Value of i after casting d to int is : " + i ) ; // showing the value of i after casting

        // Now let's do 'is' operator , which is used to check if an object is of a specific type and it is called as type testing operator
        string s2 = "wudasuga"; // Note : '' is for char type and "" is for string type;
        Console.WriteLine ( " 'is' operator : s2 is string? = " + ( s2 is string ) ) ;

        // Now let's do 'as' operator , which is used to perform type conversion between compatible reference types 
        // and these reference types can be user-defined types or built-in types which are classes, interfaces, delegates, or arrays
        // and it is called as type conversion operator
        // Also, if the cast fails, 'as' returns null instead of throwing an exception.

        string s = "Hello";
        Console.WriteLine ( "s is " + s + " , Type of s is : " + s.GetType() ) ;
        object o = s as object ; // converting string to object using 'as' operator
        Console.WriteLine ( " 'as' operator : o = " + o ) ;
        Console.WriteLine ( " Type of o is : " + o.GetType() ) ;
        
        // So what is GetType() method ? It is a method of System.Object class which returns the runtime type of the current instance
        // so one is an operator and other is a method ( function ) of object class
        // So both 'is' and 'as' operators are keywords in C# programming language
        // So can GetType() method be used on value types as well ? Yes , it can be used on both value types and reference types
        // such as int, double, char, bool, etc for value types and string, object, arrays, classes, interfaces, delegates, etc for reference types
        // but typeof operator is used with type names directly and 'is' and 'as' operators are used with variables or objects
        // So in short the difference between typeof operator and GetType() method is that typeof is a compile-time operator used with type names
        // whereas GetType() is a runtime method used with instances of types ( objects or variables

        // So let's see a difference where only typeof operator can be used and GetType() method cannot be used
        Console.WriteLine ( " Typeof operator with type name : typeof( double ) = " + ( typeof( double ) ) ) ;
        // Now can we use GetType() method with type name directly ? No , we cannot
        // Console.WriteLine ( " GetType() method with type name : double.GetType() = " + ( double.GetType() ) ) ; 
        // This will give error because GetType() method cannot be used with type names directly 

        // Now let's see a difference where only GetType() method can be used and typeof operator cannot be used
        double num = 7.5 ;
        Console.WriteLine ( " Value of num is : " + num ) ;
        Console.WriteLine ( " GetType() method on variable num : num.GetType() = " + ( num.GetType() ) ) ;
        // Now can we use typeof operator with variables ? No , we cannot
        // Console.WriteLine ( " Typeof operator on variable num : typeof( num ) = " + ( typeof( num ) ) ) ;
        // This will give error because typeof operator cannot be used with variables directly

        // Though now you must be wondering why even use typeof operator on these typeof int, double, string, etc as we already know their types
        // The typeof operator is particularly useful in scenarios involving reflection, where you need to obtain type information at runtime
        // It can also be used in generic programming to get type information about type parameters
        // Example of generic programming using typeof operator
        
        DisplayTypeInfo<int>() ;
        DisplayTypeInfo<string>() ;

        // A quick overview on how to define what is this DispplayTypeInfo<T>() method
        // Here first things first it's a method named DisplayTypeInfo , yeah you can call it a function as well ,
        // with null type defined by that void keyword
        // but instead of just any function or method it's a generic method
        // and the difference between a generic method and a regular method is that a generic method can operate on different data types
        // as for other regular method you would have written someting like void DisplayTypeInfoInt(int T ) for int type
        // and void DisplayTypeInfoString(string T ) for string type and so on for other data types
        // but with generic method you can define a single method that can work with any data type
        // and the <T> syntax indicates that T is a type parameter that will be specified when the method is called
        // So when we call DisplayTypeInfo<int>() , we are specifying that T should be replaced with int type
        // and when we call DisplayTypeInfo<string>() , we are specifying that T should be replaced with string type
        // This allows for code reusability and type safety in C# programming language
        // So T is a placeholder type parameter.
        // When we call DisplayTypeInfo<int>(), the compiler substitutes int for T.
        // When we call DisplayTypeInfo<string>(), it substitutes string.
        // That’s why it’s not “just a function” — it’s a template for functions across many types.

        // Now one thing we should note is that Console.WriteLine() is a method of Console class in System namespace and it straiht up remove the unenecessary complexity of writing to the console
        // Hence if we a varibale : int i = 6 ; 
        // if we do float f = (float)i ; // Explicit conversion from int to float using type casting operator
        // but when we print it using Console.WriteLine( f ) ; // It will automatically convert print 6 only and not 6.0
        // and we do float f = i ; // Implicit conversion from int to float
        // but if we do int j = f ; // This will give error as it is a compilation error due to possible loss of data
        // So we have to do int j = (int)f ; // Explicit conversion from float to int using type casting operator
        int ni = 6 ;
        float f = (float)ni ;
        Console.WriteLine ( " Value of f after implicit conversion from int to float is : " + f ) ;
    }
    public static void DisplayTypeInfo<T>()
        {
            Console.WriteLine ( " Typeof operator in generic programming : typeof( T ) = " + ( typeof( T ) ) ) ;
        }
}