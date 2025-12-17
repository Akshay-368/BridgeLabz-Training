import java.util.Scanner;

public class AverageOfThreeNumbers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        // Ask the user for first number
        System.out.println("Enter the first number: ");
        double n1 = sc.nextDouble(); // first number

        // Ask the user for second number
        System.out.println("Enter the second number: ");
        double n2 = sc.nextDouble(); // second number

        // Ask the user for third number
        System.out.println("Enter the third number: ");
        double n3 = sc.nextDouble(); // third number

        // Using formula and variables entered from user for average
        double avg = (n1 + n2 + n3) / 3; // average formula

        // result
        System.out.println("The Average of the three numbers is: " + avg);

        sc.close();
    }
}
