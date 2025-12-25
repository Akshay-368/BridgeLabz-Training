using System;

public class Mat
{
    public static void Main ( )
    {
        /*
        13. Write a program to perform matrix manipulation operations like addition,
        subtraction, multiplication, and transpose. Also finding the determinant
        and inverse of a matrix. The program should take random matrices as input
        and display the result of the operations.

        Hint =>
        a. Write a Method to create a random matrix taking rows and columns as parameters
        b. Write a Method to add two matrices
        c. Write a Method to subtract two matrices
        d. Write a Method to multiply two matrices
        */

        int r = 2 ;
        int c = 2 ;

        // creating two random matrices
        int[,] a = crt ( r , c ) ;
        int[,] b = crt ( r , c ) ;

        // printing both matrices
        Console.WriteLine ( "Matrix A" ) ;
        sho ( a ) ;

        Console.WriteLine ( "\nMatrix B" ) ; // \n is an escape sequence and will move the cursor to next line
        sho ( b ) ;

        // Just like we \t which  inserts a horizontal tab space.and is  equivalent to pressing the Tab key.

        // addition
        Console.WriteLine ( "\nAddition" ) ;
        sho ( add ( a , b ) ) ;

        // subtraction
        Console.WriteLine ( "\nSubtraction" ) ;
        sho ( sub ( a , b ) ) ;

        // multiplication
        Console.WriteLine ( "\nMultiplication" ) ;
        sho ( mul ( a , b ) ) ;

        // transpose
        Console.WriteLine ( "\nTranspose of A" ) ;
        sho ( trn ( a ) ) ;

        // determinant
        int d = det ( a ) ;
        Console.WriteLine ( "\nDeterminant of A = " + d ) ;

        // inverse (only if det not zero plz)
        if ( d != 0 )
        {
            Console.WriteLine ( "\nInverse of A" ) ;
            inv ( a , d ) ;
        }
        else
        {
            Console.WriteLine ( "\nInverse not possble , det is zero " ) ;
        }
    }

    public static int[,] crt ( int r , int c )
    {
        // making random matrix with small values so math dont explode
        int[,] m = new int[r , c] ;
        Random rd = new Random ( ) ;

        for ( int i = 0 ; i < r ; i++ )
        {
            for ( int j = 0 ; j < c ; j++ )
            {
                m[i , j] = rd.Next ( 1 , 9 ) ;
            }
        }

        return m ;
    }

    private static int[,] add ( int[,] a , int[,] b )
    {
        // Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        int[,] r = new int[2 , 2] ;

        for ( int i = 0 ; i < 2 ; i++ )
        {
            for ( int j = 0 ; j < 2 ; j++ )
            {
                r[i , j] = a[i , j] + b[i , j] ;
            }
        }

        return r ;
    }

    public static int[,] sub ( int[,] a , int[,] b )
    {
        int[,] r = new int[2 , 2] ;

        for ( int i = 0 ; i < 2 ; i++ )
        {
            for ( int j = 0 ; j < 2 ; j++ )
            {
                r[i , j] = a[i , j] - b[i , j] ;
            }
        }

        return r ;
    }

    public static int[,] mul ( int[,] a , int[,] b )
    {
        int[,] r = new int[2 , 2] ;

        for ( int i = 0 ; i < 2 ; i++ )
        {
            for ( int j = 0 ; j < 2 ; j++ )
            {
                r[i , j] = 0 ;

                for ( int k = 0 ; k < 2 ; k++ )
                {
                    r[i , j] = r[i , j] + a[i , k] * b[k , j] ;
                }
            }
        }

        return r ;
    }

    public static int[,] trn ( int[,] a )
    {
        int[,] r = new int[2 , 2] ;

        for ( int i = 0 ; i < 2 ; i++ )
        {
            for ( int j = 0 ; j < 2 ; j++ )
            {
                r[j , i] = a[i , j] ;
            }
        }

        return r ;
    }

    public static int det ( int[,] a )
    {
        // formula for 2x2 matrix det
        int d = ( a[0 , 0] * a[1 , 1] ) - ( a[0 , 1] * a[1 , 0] ) ;
        return d ;
    }

    public static void inv ( int[,] a , int d )
    {
        // inverse formula for 2x2 
        double i00 =  a[1 , 1] / (double)d ;
        double i01 = -a[0 , 1] / (double)d ;
        double i10 = -a[1 , 0] / (double)d ;
        double i11 =  a[0 , 0] / (double)d ;

        Console.WriteLine ( i00 + "   " + i01 ) ;
        Console.WriteLine ( i10 + "   " + i11 ) ;
    }

    public static void sho ( int[,] a )
    {
        for ( int i = 0 ; i < 2 ; i++ )
        {
            for ( int j = 0 ; j < 2 ; j++ )
            {
                Console.Write ( a[i , j] + "   " ) ;
            }
            Console.WriteLine ( ) ;
        }
    }
}
