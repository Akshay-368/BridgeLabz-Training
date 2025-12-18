import java.util.Scanner ;

public class VolumeOfCylinder {
  public static void main(String[] args ) {
    Scanner sc = new Scanner(System.in) ;

  // Asking user for radius
  System.out.println("Enter the radius of the cylinder : " ) ;
  double r = sc.nextDouble(); // radius

  // Asking user for height
  System.out.println ( " Enter the height of the cynlinder : " ) ;
  double h = sc.nextDouble () ; // height

    // Calculating the volume 
    double vol = Math.PI * r * r * h ;

  // Print the reult
  System.out.println ( " The volume of the cylinder is : " + vol ) ;
    sc.close () ; // close the scanner object
  }
}
