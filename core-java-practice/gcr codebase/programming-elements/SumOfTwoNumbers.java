import java.util.Scanner;
// Importing the scanner class , for taking user input 

public class SumOfTwoNumbers {
    public static void main(String[] args) {
        // Create a Scanner object to read input
        Scanner sc = new Scanner(System.in);

        // Asking the user for two numbers
        System.out.print("Enter the first number: ");
        int n1 = sc.nextInt();

        System.out.print("Enter the second number: ");
        int n2 = sc.nextInt();

        // Calculate the sum
        int sum = n1 + n2;

        // Print the result
        System.out.println("The sum of " + n1 + " and " + n2 + " is: " + sum);

        // Close the scanner
        sc.close();
    }
}
