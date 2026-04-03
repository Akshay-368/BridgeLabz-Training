using System;

public static class OtpGen
{
    public static void Main ()
    {
        /*7. Write a program to generate a six-digit OTP number using Math.Random() method.
        Validate the numbers are unique by generating the OTP number 10 times and ensuring all the 10 OTPs are not the same
        Hint => 
        Write a method to Generate a 6-digit OTP number using Math.Random() 
        Create an array to save the OTP numbers generated 10 times
        Write a method to ensure that the OTP numbers generated are unique. If unique return true else return false
        */

        // Array to store 10 OTP values
        int[] otp = new int[10];

        // Generate OTPs 10 times
        for ( int i = 0 ; i < otp.Length ; i++ )
        {
            otp[i] = genOtp ();
        }

        // Display generated OTPs
        Console.WriteLine ( " Generated OTPs : " );

        for ( int i = 0 ; i < otp.Length ; i++ )
        {
            Console.WriteLine ( otp[i] );
        }

        // Check uniqueness
        bool u = chkUni ( otp );

        if ( u == true )
        {
            Console.WriteLine ( " All OTPs are UNIQUE " );
        }
        else
        {
            Console.WriteLine ( " Duplicate OTPs found " );
        }
    }

    public static int genOtp ()
    {
        // This method if to generate a 6 digit OTP
        // Math.Random() gives value between 0.0 and 1.0
        // Multiply by 900000 and add 100000 to ensure 6 digits

        Random r = new Random (); // Creating an object of Random as r.

        double v = r.NextDouble (); // gives a double ( decimal ) number which is greater than  or equal to 0.0 and less than 1.0n ( thus exc;lusive)
        double n = v * 900000; // for eg : even multiplying by 0.9 will give 8,10,000 thus we can safely have a six digit number
        // After all the min num that NextDOuble() can gen is 0.0 and max  is 1.0 ( by rough estimation , though obviously it is not proper )
        // so the range is -  i.e. 0 to 899,999
        // This ensures we have a wide spread of possible values, but they are not guaranteed to be six digits yet (some could be less than 100,000).
        // and if we would ave multiplied by 1M directly then - Range would be 0 to 999,999. and thus there could be a lot of numbers less than 100,000. and at that point even adding
        // 0.1M would be tricky.
        // Now we add 0.1M here  we shift the range upward , as remember the smallest value above could be 0 , so by adding 0.1M we are making sure the OTP ranges between
        // 100,000 and 999,999( and obviously since the highest was 899,999 , thus adding 0.1M is just increasing our range all together while making sure we get 6 digits).
        // and thus we are sure that all the numbers are unique.
        int o = (int) n + 100000;

        return o;
    }

    public static bool chkUni ( int[] a )
    {
        // TTo check whether all OTP values are unique
        // We compare each element with every other element
        // If any two are same, OTP is NOT unique

        for ( int i = 0 ; i < a.Length ; i++ )
        {
            for ( int j = i + 1 ; j < a.Length ; j++ )
            {
                if ( a[i] == a[j] )
                {
                    // Duplicate found
                    return false;
                }
            }
        }

        // No duplicates found
        return true;
    }
}
