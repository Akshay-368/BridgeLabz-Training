import java.util.Scanner;

public class RectanglePerimeter {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        // Ask the user for length
        System.out.println("Enter the length of the rectangle: ");
        double l = sc.nextDouble(); // length

        // Ask the user for width
        System.out.println("Enter the width of the rectangle: ");
        double w = sc.nextDouble(); // width

        // Using formula and variables entered from user for  perimeter
        double p = 2 * (l + w); // perimeter formula

        // result
        System.out.println("The Perimeter of the rectangle is: " + p);

        sc.close();
    }
}
