using System;

public static class PcmScore
{
    public static void Main ()
    {
        /* Q12.
        Create a program to take input marks of students in 3 subjects physics, chemistry, and maths. Compute the total, average, and the percentage score 
        Hint =>
        Take input for the number of students
        Write a method to generate random 2-digit scores for Physics, Chemistry, and Math (PCM) for the students and return the scores. 
        This method returns a 2D array with PCM scores for all students
        Write a Method to calculate the total, average, and percentages for each student and return a 2D array with the corresponding values. 
        Please ensure to round off the values to 2 Digits using the Math.Round() method. 
        Finally, write a Method to display the scorecard of all students with their scores, total, average, and percentage in a tabular format using "\t". 
        */

        // Asking for  number of students
        Console.Write ( " Enter number of students : " );
        int n = int.Parse ( Console.ReadLine () );

        // Ti stir ad create random PCM scores
        int[][] pcm = gen ( n );

        // Calculating total, average and percentage
        double[][] res = calc ( pcm );

        // Printing final scorecard
        show ( pcm , res );
    }

    public static int[][] gen ( int n )
    {
        // To generate random 2 digit PCM marks as instructed in question
        // Column 0 is Physics , 1 is Chemistry , 2 is Maths

        int[][] a = new int[n][];
        Random r = new Random ();

        for ( int i = 0 ; i < n ; i++ )
        {
            a[i] = new int[3];

            a[i][0] = r.Next ( 10 , 100 ); // Physics
            a[i][1] = r.Next ( 10 , 100 ); // Chemistry
            a[i][2] = r.Next ( 10 , 100 ); // Maths
        }

        return a;
    }

    public static double[][] calc ( int[][] a )
    {
        // This method calculates total, average and percentage
        // Column 0 is Total , 1 is Average , 2 is Percentage

        double[][] b = new double[a.Length][];

        for ( int i = 0 ; i < a.Length ; i++ )
        {
            b[i] = new double[3];

            int t = 0;
            t = t + a[i][0];
            t = t + a[i][1];
            t = t + a[i][2];

            double avg = t / 3.0;
            double per = ( t / 300.0 ) * 100;

            // Rounding to 2 decimal places
            b[i][0] = Math.Round ( t , 2 );
            b[i][1] = Math.Round ( avg , 2 );
            b[i][2] = Math.Round ( per , 2 );
        }

        return b;
    }

    public static void show ( int[][] a , double[][] b )
    {
        // This method displays the scorecard in tabular format

        Console.WriteLine ();
        Console.WriteLine ( "Phy\tChem\tMath\tTotal\tAvg\tPer\tGrade\tRemarks" );

        for ( int i = 0 ; i < a.Length ; i++ )
        {
            var g = fun ( b[i][2] );

            Console.WriteLine (a[i][0] + "\t" + a[i][1] + "\t" + a[i][2] + "\t" + b[i][0] + "\t" + b[i][1] + "\t" + b[i][2] + "\t" + g.Item1 + "\t" + g.Item2 );
        }
    }

    //helper method for grading and remarks
    private static ( string , string ) fun ( double p )
    {
        // Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        if ( p <= 39 )
        {
            return ( "R" , "Remedial Standards " );
        }
        else if ( p >= 40 && p <= 49 )
        {
            return ( "E" , "Level - 1- ,too below agency-normalise standards " );
        }
        else if ( p >= 50 && p <= 59 )
        {
            return ( "D" , "Level -1 , well below agency normalised standards " );
        }
        else if ( p >= 60 && p <= 69 )
        {
            return ( "C" , "Level - 2 below  but approaching agency normalised standards " );
        }
        else if ( p >= 70 && p <= 79 )
        {
            return ( "B" , "Level - 3,  at agency normalised standards " );
        }
        else
        {
            return ( "A" , "Level - 4 above agency normalised standards " );
        }
    }
}
