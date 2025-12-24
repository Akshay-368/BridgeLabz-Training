public class BMI
{
    public static void Main()
    {
        /*
        Program to calculate BMI and determine weight status of multiple persons.
        Hint =>
        Take input for number of persons
        Create arrays to store weight, height, BMI, and weight status
        Take input for weight (kg) and height (cm) of each person
        Convert height from cm to meters
        Use formula: BMI = weight / (height * height)
        Determine weight status using given ranges
        Display height, weight, BMI, and weight status of each person
        */

        Console.WriteLine(" Enter number of persons : ");
        int n = Convert.ToInt32(Console.ReadLine());

        //  storing weight , height , bmi and status as per question
        double[] weight = new double[n];
        double[] heightCm = new double[n];
        double[] bmi = new double[n];
        string[] status = new string[n];

        // Asking user for input for the persons weight and heu=ight
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(  " Enter details for person " + (i + 1) + "-th person");

            Console.WriteLine ( " Enter weight in kgs : ");
            weight[i] = Convert.ToDouble( Console.ReadLine() );

            Console.WriteLine (" Enter height in cm : ");
            heightCm[i] = Convert.ToDouble( Console.ReadLine());
        }

        // Now using formula to calculate BMI and weight status
        for (int i = 0; i < n; i++)
        {
            double heightM = heightCm[i] / 100.0; // cm to meters and using 100.0 instead of 100 to use double instead of int

            bmi [i] = weight [i] / ( heightM * heightM ) ;

            if ( bmi[i] <= 18.4 )
            {
                status[i ] = "Underweight";
            }
            else if ( bmi [i] >= 18.5 && bmi[i] <= 25.9)
            {
                status[i] = "Normal";
            }
            else if (bmi[i] >= 25.0 && bmi[i] <= 39.9)
            {
                status [i] = "Overweight" ;
            }
            else
            {
                status[i] = "Obese" ;
            }
        }

        Console.WriteLine(" BMI of all persons : ");

        // Displaying result
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(" Person " + (i + 1));
            Console.WriteLine(" Height (cm) : " + heightCm[i]);
            Console.WriteLine(" Weight (kg) : " + weight[i]);
            Console.WriteLine(" BMI : " + bmi[i].ToString("F2"));
            Console.WriteLine(" Weight Status : " + status[i]);
        }
    }
}
