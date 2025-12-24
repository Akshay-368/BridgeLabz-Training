public class BMI
{
    public static void Main()
    {
        /* Rewrite the above program using multi-dimensional array to store height, weight, and BMI in 2D array for all the persons
        Hint => 
        Take input for a number of persons
        Create a multi-dimensional array to store weight, height and BMI. Also create an to store the weight status of the persons
        double[][] personData = new double[number][3];
        String[] weightStatus = new String[number];
        Take input for weight and height of the persons and for negative values, ask the user to enter positive values
        Calculate BMI of all the persons and store them in the personData array and also find the weight status and put them in the weightStatus array
        Display the height, weight, BMI and status of each person

        And the previous question was this :

        Program to calculate BMI and determine weight status of multiple persons.
        Hint =>
        Take input for number of persons
        Create a multi-dimensional array to store weight, height and BMI
        Also create an array to store weight status of the persons
        Take input for weight and height of the persons and for negative values,
        ask the user to enter positive values
        Calculate BMI and store it in the array
        Display height, weight, BMI and weight status of each person
        */

        Console.WriteLine(" Enter number of persons : ");
        int n = Convert.ToInt32(Console.ReadLine());

        // personData[row][col]
        // col 0 - weight , col 1 - height , col 2 - bmi
        double[][] personData = new double[n][]; // creating a 2 d array personData as per the instructions where we define for this array to hold n elements which obviously are array themselves
        string[] weightStatus = new string[n];

        for (int i = 0; i < n; i++)
        {
            personData[i] = new double[3]; // array i in the personData to be holding 3 elements with height, weight and BMI
        }

        //  input
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(" Enter details for person " + (i + 1) );

            double w;
            do
            {
                Console.WriteLine(" Enter weight in kg : " );
                w = Convert.ToDouble(Console.ReadLine());

                if (w < 0)
                {
                    Console.WriteLine(" Weight cannot be negative. ") ;
                }
            } while (w < 0);

            personData[i][0] = w;

            double h;
            do
            {
                Console.WriteLine(" Enter height in cm : ") ;
                h = Convert.ToDouble(Console.ReadLine()) ;

                if (h < 0)
                {
                    Console.WriteLine(" Height cannot be negative . ") ;
                }
            } while (h < 0);

            personData[i][1] = h;
        }

        // Using formula for  BMI and status
        for (int i = 0; i < n; i++)
        {
            double heightM = personData[i][1] / 100.0;

            personData[i][2] = personData[i][0] / ( heightM * heightM) ;

            double bmi = personData[i][2] ;

            if (bmi <= 18.4)
            {
                weightStatus[i] = "Underweight" ;
            }
            else if (bmi >= 18.5 && bmi <= 25.9)
            {
                weightStatus[i] = "Normal";
            }
            else if (bmi >= 25.0 && bmi <= 39.9)
            {
                weightStatus[i] = "Overweight";
            }
            else
            {
                weightStatus[i] = "Obese";
            }
        }

        Console.WriteLine(" BMI details of all persons : ");

        // Printing
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(" Person " + (i + 1));
            Console.WriteLine(" Height in cm  : " + personData[i][1] );
            Console.WriteLine(" Weight (kg) : " + personData[i][0] ) ;
            Console.WriteLine(" BMI : " + personData[i][2].ToString ( "F2"));
            Console.WriteLine(" Weight Status : " + weightStatus[i]) ; 
        }
    }
}
