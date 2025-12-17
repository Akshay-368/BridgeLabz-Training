import java.util.Scanner;

public class KmToMiles {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        // Ask the user for distance in kilometers
           System.out.println("Enter the distance in kilometers: ");
        double km = sc.nextDouble(); // kilometers

        // Using formula and variable entered from user for conversion
           double mi = km * 0.621371; // conversion formula (1 km = 0.621371 miles as per the standard conversion rates I checked online)

        // result
        System.out.println("The distance in miles is: " + mi);

          sc.close();
    }
}
