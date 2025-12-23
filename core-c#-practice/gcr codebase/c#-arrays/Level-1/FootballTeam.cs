using System ;
public static class FootballTeam
{
    public static void Main()
    {
        /* Create a program to find the mean height of players present in a football team.
        Hint =>
        The formula to calculate the mean is: mean = sum of all elements / number of elements
        Create a double array named heights of size 11 and get input values from the user.
        Find the sum of all the elements present in the array.
        Divide the sum by 11 to find the mean height and print the mean height of the football team
        */

        const int size = 11 ; // Number of players are fixed
        double[] heights = new double[size] ; // Array to store heights of players
        double sum = 0 ; // Variable to store sum of heights

        Console.WriteLine("Enter the height of the players one by one:");


        for (int i = 0 ; i < size ; i++)
        {
            while (true) {
                if(! double.TryParse(Console.ReadLine() , out double number))
            {
                Console.WriteLine ("Invalid value.");
                continue ; // Exit the loop if invalid input is entered
            } else
            {
                heights[i] = number ;
                sum += heights[i] ; // Adding the height to the sum
                break ;
            }
            }
        }
        double mean = sum / size ; // Calculating the mean height
        Console.WriteLine($"The mean height of the football team is: {mean:F2} ") ; // Printing the mean height
    }
}
