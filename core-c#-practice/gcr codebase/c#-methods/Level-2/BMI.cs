using System;

public static class BMI
{
    public static void Main ()
    {
        /*Q10.
        An organization took up the exercise to find the Body Mass Index (BMI)
        of all the persons in the team of 10 members.

        Hint =>
        a. Take user input in double for weight (kg) and height (cm)
        Store it in a 2D array of 10 rows and 3 columns
        Col 0 -> weight , Col 1 -> height (cm) , Col 2 -> BMI

        b. Create a Method to find BMI and populate the array
           BMI = weight / ( height * height ) , height in meters

        c. Create a Method to determine BMI status and return status array
        */

        const int total = 10; // fixing it as it would not change throughout the program and thus fixing it is a good practice to avoid any unnecessary changes
        // As per question team size is fixed to 10 members

        double[][] Data = new double[total][];
        // 2D array to store weight, height and BMI

        string[] status = new string[total];
        // Array to store BMI status of each person

        for ( int i = 0 ; i < total ; i++ )
        {
            Data[i] = new double[3];
            // Each row will store 3 values : weight, height and BMI

            Console.WriteLine ( " Enter details for person " + ( i + 1 ) + "th person :" );

            Console.WriteLine ( " Enter weight in kg : " );
            Data[i][0] = double.Parse ( Console.ReadLine() );
            // Storing weight in first column

            Console.WriteLine ( " Enter height in cm : " );
            Data[i][1] = double.Parse ( Console.ReadLine() );
            // Storing height in second column
        }

        Calculate ( Data );
        // Calling helper method to calculate BMI and fill the third column

        status = Find ( Data );
        // Calling the helper method to determine BMI status of all persons

        Console.WriteLine ( " BMI Details  : " );

        for ( int i = 0 ; i < total ; i++ )
        {
            Console.WriteLine ( " Person " + ( i + 1 ) );
            Console.WriteLine ( " Weight (kg) : " + Data[i][0] );
            Console.WriteLine ( " Height (cm) : " + Data[i][1] );
            Console.WriteLine ( " BMI : " + Data[i][2].ToString("F2") );
            Console.WriteLine ( " Status : " + status[i] );
        }
    }

    private static void Calculate ( double[][] arr )
    {
        // This method calculates BMI of every person
        // and stores it in the third column of the 2D array
        // Making this method private so that only this class can call it , just one of the best practices
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        for ( int i = 0 ; i < arr.Length ; i++ )
        {
            double weight = arr[i][0];
            double heightCm = arr[i][1];

            double heightM = heightCm / 100.0;
            // Converting height from cm to meters

            double bmi = weight / ( heightM * heightM );
            // Using BMI formula

            arr[i][2] = bmi;
            // Storing BMI in third column
        }
    }

    private static string[] Find ( double[][] a )
    {
        // This method determines BMI status of each person
        // and returns an array of status strings
        // Making this method private so that only this class can call it , just one of the best practices
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        string[] res = new string[a.Length];

        for ( int i = 0 ; i < a.Length ; i++ )
        {
            double bmi = a[i][2];

            if ( bmi <= 18.4 )
            {
                res[i] = "Underweight";
            }
            else if ( bmi >= 25.0 && bmi <= 39.9 )
            {
                res[i] = "Overweight";
            }
            else if ( bmi >= 40 )
            {
                res[i] = "Obese";
            }
            else
            {
                res[i] = "Normal";
                // Whatever is left falls under normal category
            }
        }

        return res;
        // Returning the BMI status array
    }
}
