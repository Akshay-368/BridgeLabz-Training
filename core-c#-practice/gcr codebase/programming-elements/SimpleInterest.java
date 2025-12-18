import java.util.Scanner;

public class SimpleInterest {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        // Ask the user for  principal
        System.out.println("Enter the principal amount: ");
        double pr = sc.nextDouble(); // principal

        // Ask the user for  rate of interest
        System.out.println("Enter the rate of interest (per annum): ");
        double r = sc.nextDouble(); // rate 

        // Ask the user for  time in years
        System.out.println("Enter the time (in years): ");
        double t = sc.nextDouble(); // time

        // Calculate simple interest
        double si = (pr * r* t) / 100;

        //  result
        System.out.println("The Simple Interest is: " + si);

        sc.close();
    }
}
