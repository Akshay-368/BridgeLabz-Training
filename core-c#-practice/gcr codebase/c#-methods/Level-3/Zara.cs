using System;

public static class Zara
{
    public static void Main()
    {
        /*11.Create a program to find the bonus of 10 employees based on their years of service as well as the total bonus amount
        the 10-year-old company Zara has to pay as a bonus, along with the old and new salary.
        Hint => 
        Zara decides to give a bonus of 5% to employees whose year of service is more than 5 years or 2% if less than 5 years
        Create a Method to determine the Salary and years of service and return the same. Use the Math.Random() method to determine the 5-digit salary for 
        each employee and also use the random method to determine the years of service. Define 2D Array to save the salary and years of service.
        Write a Method to Calculate the sum of the Old Salary, the Sum of the New Salary, and the Total Bonus Amount and display it in a Tabular Format
        */

        // calling helper method to get old salary and years of service
        int[,] old = get();

        // calling helper method to calculate new salary and bonus
        int[,] nw = cal(old);

        // calling helper method to display totals and table
        sum(old, nw);
    }


    // method name: get
    // what: generates salary and years of service
    // how: uses Random class
    // why: data is needed for bonus calculation

    public static int[,] get()
    {
        // creating 2D array
        // row = employees (10)
        // col = 0 -> salary , 1 -> years
        int[,] arr = new int[10, 2];

        Random r = new Random();

        for (int i = 0; i < 10; i++)
        {
            // generating 5 digit salary
            arr[i, 0] = r.Next(10000, 99999);

            // generating years of service (0 to 10)
            arr[i, 1] = r.Next(1, 11);
        }

        return arr;
    }


    // method name: cal
    // what: calculates bonus and new salary
    // how: checks years and applies percentage
    // why: company needs updated salary data

    private static int[,] cal(int[,] old)
    {
        // new 2D array
        // col = 0 is new salary , 1 is bonus
        // Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        int[,] nw = new int[10, 2];

        for (int i = 0; i < 10; i++)
        {
            int sal = old[i, 0];
            int yrs = old[i, 1];
            int bon = 0;

            // checking service years
            if (yrs > 5)
            {
                // 5 % bonus
                bon = (sal * 5) / 100;
            }
            else
            {
                // 2 % bonus
                bon = (sal * 2) / 100;
            }

            // storing bonus
            nw[i, 1] = bon;

            //  new salary will be
            nw[i, 0] = sal + bon;
        }

        return nw;
    }


    // method name: sum
    // what: calculates totals and prints table
    // how: loops through arrays
    // why: management needs final report

    public static void sum(int[,] old, int[,] nw)
    {
        int os = 0; // old salary sum
        int ns = 0; // new salary sum
        int tb = 0; // total bonus

        // table header
        Console.WriteLine("Emp\tOldSal\tYears\tBonus\tNewSal");
        Console.WriteLine();

        for (int i = 0; i < 10; i++)
        {
            int sal = old[i, 0];
            int yrs = old[i, 1];
            int bon = nw[i, 1];
            int nsl = nw[i, 0];

            // adding totals
            os = os + sal;
            ns = ns + nsl;
            tb = tb + bon;

            // printing row
            Console.WriteLine(
                (i + 1) + "\t" +
                sal + "\t" +
                yrs + "\t" +
                bon + "\t" +
                nsl
            );
        }

        Console.WriteLine();

        // printing final totals
        Console.WriteLine("Tot\t" + os + "\t-\t" + tb + "\t" + ns);
    }
}
