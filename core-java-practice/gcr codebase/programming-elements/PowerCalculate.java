import java.util.Scanner;

public class PowerCalculate {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

    // Ask the user for the base number
        System.out.println("Enter the base number: ");
    double n = sc.nextDouble(); // base number

  // Ask the user for the exponent
          System.out.println("Enter the exponent: ");
        double e = sc.nextDouble(); // exponent

  // Using formula and variables entered from user for power function of the library Math in java
          double p = Math.pow(n, e); // power formula

        // result
             System.out.println("The result of " + n + " raised to the power " + e + " is: " + p);

  sc.close();
    }
}
