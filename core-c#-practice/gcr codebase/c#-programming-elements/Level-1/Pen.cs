using System;
class Pen {
    public static   void Main()
    {
        /*5. Suppose you have to divide 14 pens among 3 students equally. Write a program to find
        how many pens each student will get if the pens must be divided equally. Also, find the remaining non-distributed pens.
Hint:
Use Modulus Operator (%) to find the reminder.
Use Division Operator to find the Quantity of pens
I/P => NONE
O/P => The Pen Per Student is ___ and the remaining pen not distributed is ___
        */
        
        int tp = 14 ; // total pens
        int ns = 3 ; // number of students among whom pens are to be distributed
        int pps = tp / ns ; // pens per student
        int rp = tp % ns ; // remaining pens

        Console.WriteLine ( " The Pen Per Student is : " + pps + " and the remaining pen not distributed is : " + rp ) ;


    }
}