public class YoungestFriends
{
    public static void Main()
    {
        /*Create a program to find the youngest friends among 3 Amar, Akbar, and Anthony based on their ages and the tallest among the friends based on their heights
        Hint =>
        Take user input for age and height for the 3 friends and store it in two arrays each to store the values for age and height of the 3 friends
        Loop through the array and find the youngest of the 3 friends and the tallest of the 3 friends
        Finally display the youngest and tallest of the 3 friends
        */

        /* And instead of doing this , let's make the necessary changes in here
        // Asking user details for Amar
        Console.WriteLine("Enter the age and height of Amar ( with space sperated in a single line )");
        string s = Console.ReadLine ();
        string[] a = s.Split();
        int ageAmar = Convert.ToInt32 ( a[0]  );
        int heightAmar = Convert.ToInt32 ( a[1] ) ;

        // Asking user details for Akbar
        Console.WriteLine(" Enter the age and height of Akbar (space separated in a single line ) ") ;
        s = Console.ReadLine();
        a = s.Split();
        int ageAkbar = Convert.ToInt32(a[0]);
        int heightAkbar = Convert.ToInt32(a[1]);

        // Asking user details for Anthony
        Console.WriteLine(" Enter the age and height of Anthony ( with space sperated in a single line ) ");
        s = Console.ReadLine();
        a = s.Split();
        int ageAnthony = Convert.ToInt32( a[0] );
        int heightAnthony = Convert.ToInt32( a[1] );

        */

        string[] names = { "Amar", "Akbar", "Anthony" };
        int[] ages = new int[3];
        int[] heights = new int[3];

        // Taking the input for all 3 friends
        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine($"Enter the age and height of {names[i]} (space separated in a single line):");
            string s = Console.ReadLine();
            string[] parts = s.Split();
            ages[i] = Convert.ToInt32(parts[0]);
            heights[i] = Convert.ToInt32(parts[1]);
        }

        // Now Finding the youngest friend
        int youngestIndex = 0;
        for (int i = 1; i < ages.Length; i++)
        {
            if (ages[i] < ages[youngestIndex])
            {
                youngestIndex = i;
            }
        }
        Console.WriteLine($"The youngest of the 3 is: {names[youngestIndex]} with age {ages[youngestIndex]}");

        // Now Finding the tallest friend
        int tallestIndex = 0;
        for (int i = 1; i < heights.Length; i++)
        {
            if (heights[i] > heights[tallestIndex])
            {
                tallestIndex = i;
            }
        }
        Console.WriteLine($"The tallest of the 3 is: {names[tallestIndex]} with height {heights[tallestIndex]}");



    }
}
