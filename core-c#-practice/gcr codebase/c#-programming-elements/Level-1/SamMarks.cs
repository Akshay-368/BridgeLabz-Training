using System;
class SamMarks {
    public static void Main(){

        /*2. Sam’s mark in Maths is 94, Physics is 95, and Chemistry is 96 out of 100. Find the average percent mark in PCM
I/P => NONE
O/P => Sam’s average mark in PCM is ___
        */



        int Maths = 94 ;
        int Physics = 95 ;
        int Chemistry = 96 ;

        int Total = Maths + Physics + Chemistry ;

        double Average_Marks =  Total / 3.0; // Since we want floating point otherwise it would end up being int div and
        // answer will be incorrectly 0
        Console.WriteLine("Total Marks: " + Total);
        Console.WriteLine("Sam's average Marks in PCM is : " + Average_Marks + "%");
    }
}