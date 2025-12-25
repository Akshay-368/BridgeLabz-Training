using System;

public class Col
{
    public static void Main ( )
    {
        /*10.Write a program to find the 3 points that are collinear using the slope formulae and 
        area of triangle formulae. check  A (2, 4), B (4, 6) and C (6, 8) are Collinear for sampling. 
        Hint => 
        Take inputs for 3 points x1, y1, x2, y2, and x3, y3
        Write a Method to find the 3 points that are collinear using the slope formula. 
        The 3 points A(x1,y1), b(x2,y2), and c(x3,y3) are collinear if the slopes formed by 3 points ab, bc, and cd are equal. 
        slope AB = (y2 - y1)/(x2 - x1), slope BC = (y3 - y2)/(x3 - x3)
        slope AC = (y3 - y1)/(x3 - x1) Points are collinear if
        slope AB = slope BC = slope Ac
        c.  The method to find the three points is collinear using the area of the triangle formula. 
        The Three points are collinear if the area of the triangle formed by three points is 0. The area of a triangle is 
        */

        // sample values given in ques, and can be  change later if needed
        double x1 = 2 ;
        double y1 = 4 ;

        double x2 = 4  ;
        double y2 = 6 ;

        double x3 = 6 ;
        double y3 = 8  ;

        //  using slope logic
        bool s = slp ( x1 , y1 , x2 , y2 , x3 , y3 ) ;

        //  using area logic also
        bool a = ara ( x1 , y1 , x2 , y2 , x3 , y3 ) ;

        // printing final result
        if ( s == true && a == true )
        {
            Console.WriteLine ( "Points are collinear " ) ;
        }
        else
        {
            Console.WriteLine ( "Points are NOT collinear " ) ;
        }
    }

    public static bool slp ( double x1 , double y1 , double x2 , double y2 , double x3 , double y3 )
    {
        // finding slope ab , basic formula
        double m1 = ( y2 - y1 ) / ( x2 - x1 ) ;

        // finding slope bc , hopfully no divide by zero 
        double m2 = ( y3 - y2 ) / ( x3 - x2 ) ;

        // finding slope ac also just to be extra sure
        double m3 = ( y3 - y1 ) / ( x3 - x1 ) ;

        // if all slopes same then line is same i think
        if ( m1 == m2 && m2 == m3 )
        {
            return true ;
        }
        else
        {
            return false ;
        }
    }

    private static bool ara ( double x1 , double y1 , double x2 , double y2 , double x3 , double y3 )
    {
        // Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        // area formula of triangle , looks scary but works
        double p1 = x1 * ( y2 - y3 ) ;
        double p2 = x2 * ( y3 - y1 ) ;
        double p3 = x3 * ( y1 - y2 ) ;

        // adding all parts now
        double ar = p1 + p2 + p3 ;

        // making area positive just in case sign flips
        ar = Math.Abs ( ar ) ;

        // if area is zero then all points on same line
        if ( ar == 0 )
        {
            return true ;
        }
        else
        {
            return false ;
        }
    }
}
