using System ;
namespace Temperature_Analyzer ;
/*
Arrays – Temperature Analyzer
1. Scenario: You're analyzing a week’s worth of hourly temperature data stored in a 2D array
(float[7][24]).
Problem:
Write a method to:
● Find the hottest and coldest day,
● Return average temperature per day.


*/

public class TemperatureAnalyzer
{
    private static Random random = new Random() ;
    public static void Main()
    {
        float [][] weeklyTemps = new float[7][] ; // initializing the jagged array of 7 rows and 24 columns . rows denoting each day of the week and columns representing hours in a day

        for (int i = 0; i < 7; i++)
        {
            weeklyTemps[i] = new float[24];
            for (int j = 0; j < 24; j++)
            {
                weeklyTemps[i][j] = (float)(random.NextDouble() * (45 - 10) + 10); // Temps between 10 and 45 as it only gives values between 0.0 to 1.0 ( where 1.0 is not inclusive)
            }
        }

        AnalyzeTemperatures(weeklyTemps);

        

        

    }

    public static void AnalyzeTemperatures(float[][] data)
    {
        string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        float globalMax = float.MinValue;
        float globalMin = float.MaxValue;
        int hottestDayIdx = 0;
        int coldestDayIdx = 0;

        Console.WriteLine( " Daily Average Temperatures are : " ) ;

        for (int d = 0; d < data.Length; d++)
        {
            float daySum = 0;
            foreach (float temp in data[d])
            {
                daySum += temp; // adding temperature of a day .
                
                // hottest/coldest
                if (temp > globalMax)
                {
                    globalMax = temp;
                    hottestDayIdx = d; // storing the idx of the day with the hottest temp so far
                }
                if (temp < globalMin)
                {
                    globalMin = temp;
                    coldestDayIdx = d; // storing the index of the day with min temp
                }
            }

            float average = daySum / data[d].Length;
            Console.WriteLine($"{days[d]}: {average:F2}°C");
        }

        Console.WriteLine(" Extremes ");
        Console.WriteLine($"Hottest Day: {days[hottestDayIdx]} ({globalMax:F2}°C)");
        Console.WriteLine($"Coldest Day: {days[coldestDayIdx]} ({globalMin:F2}°C)");
    }
}
