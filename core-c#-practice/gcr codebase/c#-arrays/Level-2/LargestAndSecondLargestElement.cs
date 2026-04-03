using System;
using System.Linq.Expressions;
public static class LargestAndSecondLargestElement
{
    public static void Main()
    {
        /*Create a program to store the digits of the number in an array and find the largest and second largest element of the array.
        Hint =>
        Create a number variable and take user input.
        Define an array to store the digits. Set the size of the array to maxDigit variable initially set to 10
        Create an integer variable index with the value 0 to reflect the array index.
        Use a loop to iterate until the number is not equal to 0.
        Remove the last digit from the number in each iteration and add it to the array.
        Increment the index by 1 in each iteration and if the index count equals maxDigit then break out of the loop and the remaining digits are not added to the array
        Define variable to store largest and second largest digit and initialize it to zero
        Loop through the array and use conditional statements to find the largest and second largest number in the array
        Finally display the largest  and second-largest number
        */

        Console.WriteLine (" Enter the number : ");
        int n = int.Parse(Console.ReadLine()) ;
        int size = n.ToString().Length;
        int[] arr = new int[size]; // initializing a new array of the size 
        int index = 0; // index of the arrray where we are currently at
        while(n != 0)
        {
            arr[index] = n % 10 ; // storing the last digit of n in the array
            n = n / 10 ; // removing the last digit of n
            index ++ ; // moving the index ahead
            if(index == size ) // if the index count equals size of the array, then break out of the loop
                break; // we can't add any more element in the array and thus we have to break out
        }
        int largest = 0 ; // initializing largest to 0 as we don't have it with us right now
        int secondLargest = -1 ; // initializing secondLargest to -1 just in case if we don't find any second largest elment
        for(int i = 0 ; i < arr.Length ; i++)
        {
            if(arr[i] > largest) { // if the current element is greater than largest, then update largest
                secondLargest = largest ;
                largest = arr[i]; // this means we have got something greater than our curr_assumed largest and thus updating it get the new largest
            }
            else if(arr[i] > secondLargest && arr[i] != largest ) {// if the current element is greater than secondLargest and not equal to largest, then update secondLargest
                secondLargest = arr[i]; // this means we get our new second largest , b/c it's greater than our current assumed version but not equal to largest
            }
            else {
                continue; // if the current element is not greater than secondLargest or equal to largest, then skip it
            }
        }

        Console.WriteLine ( $" The largest element in the array is : {largest} and the second largest element in the array is : {( secondLargest == -1 ? "Not FOund" : secondLargest )} " );
    }
}
