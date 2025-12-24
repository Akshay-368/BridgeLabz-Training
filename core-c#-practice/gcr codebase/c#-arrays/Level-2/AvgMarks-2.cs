public class AverageMarks
{
    public static void Main()
    {
        /*Rewrite the above program to store the marks of the students in physics, chemistry, and maths in a 2D array and then compute the percentage and grade
Hint => 
All the steps are the same as the problem 8 except the marks are stored in a 2D array
Use the 2D array to calculate the percentages, and grades of the students
        */
        Console.Write ( "Enter the number of students: ") ;
        int n = int.Parse(Console.ReadLine().ToString() ) ;

        // 2D array for marks
        // row = student , column = subject
        // 0 - physics , 1 - chemi , 2 - maths
        double[,] m = new double[n, 3];

        double[] per = new double[n]; // for percentange
        string[] gr = new string[n]; // for grades
        string[] rem = new string[n]; // for remakrs

        for (int i = 0; i < n; i++)
        {
            bool ok = false;

            while (!ok)
            {
                Console.WriteLine(" Enter marks for student " + (i + 1) + " (phy chem maths): ");
                string s = Console.ReadLine();
                string[] arr = s.Split(' ');

                if (arr.Length != 3)
                {
                    Console.WriteLine(" please enter only 3 values ");
                    continue;
                }

                double p = Convert.ToDouble (arr[0].ToString());
                double c = Convert.ToDouble(arr[1].ToString());
                double ma = Convert.ToDouble(arr[2].ToString());

                if (p < 0 || c < 0 || ma < 0)
                {
                    Console.WriteLine(" marks can't be negative  ");
                    continue;
                }

                // in 2D array
                m[i, 0] = p;
                m[i, 1] = c;
                m[i, 2] = ma;

                ok = true;
            }
        }

        // percentage and grade
        for (int i = 0; i < n; i++)
        {
            double sum = 0;

            for ( int j = 0; j < 3; j++ )
            {
                sum = sum + m[i, j];
            }

            per[i] = sum / 3;
            ( gr[i], rem[i] ) = fun(per[i]);
        }



        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(" Student " + (i + 1) + " details ");
            Console.WriteLine(" Physics : " + m[i, 0]);
            Console.WriteLine(" Chemistry : " + m[i, 1]);
            Console.WriteLine(" Maths : " + m[i, 2]);
            Console.WriteLine(" Average marks : " + per[i].ToString("F2"));
            Console.WriteLine(" Grade : " + gr[i]);
            Console.WriteLine(" Remarks : " + rem[i]);

        }
    }

    private static (string, string) fun(double percentage)
    {
        if (percentage <= 39)
        {
            return ( "R",  "Remedial Standards");
        }
        else if ( percentage >= 40 && percentage <= 49)
        {
            return ("E", "Level - 1-, too below agency-normalise standards") ;
        }
        else if (percentage >= 50 && percentage <= 59)
        {
            return ("D", "Level -1, well below agency normalised standards");
        }
        else if (percentage >= 60 && percentage <= 69 )
        {
            return ("C", "Level - 2 below but approaching agency normalised standards ");
        }
        else if (percentage >= 70 && percentage <= 79)
        {
            return ("B", "Level - 3, at agency normalised standards");
        }
        else
        {
            return ("A", "Level - 4 above agency normalised standards" );
        }
    }
}
