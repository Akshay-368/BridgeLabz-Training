using System ;
class MaxHandshakes
{
    static void Main()
    {
        /* 16. Create a program to find the maximum number of handshakes among N number of students.
Hint:
Get integer input for numberOfStudents variable.
Use the combination = (n * (n - 1)) / 2 formula to calculate the maximum number of possible handshakes.
Display the number of possible handshakes.

*/
        Console.Write( " Enter the number of students : " ) ;
        int n = int.Parse(Console.ReadLine()); // number of students

        int mh = (n * (n - 1)) / 2; // formula to calculate maximum handshakes as given in the hint of the question itself

        Console.WriteLine("The maximum number of handshakes among {0} students is: {1}", n, mh);
    }
}