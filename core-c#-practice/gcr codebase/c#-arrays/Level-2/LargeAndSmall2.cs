using System;
using System.Linq.Expressions;
public static class LargestAndSecondLargestElement
{
    public static void Main()
    {
        /*Rework the program 2, especially the Hint: if index equals maxDigit, we break from the loop. Here we want to modify to
        increase the size of the array i,e maxDigit by 10 if the index is equal to maxDigit. This is done to consider all digits to find the largest and second-largest number 
        Hint => 
        In Hint f inside the loop if the index is equal to maxDigit, increase maxDigit and make digits array to store more elements. 
        To do this, we need to create a new temp array of size maxDigit, copy from the current digits array the digits into the temp array,
        and assign the current digits array to the temp array
        Now the digits array will be able to store all digits of the number in the array and then find the largest and second largest number

        and that earlier question was as follows :
        Create a program to store the digits of the number in an array and find the largest and second largest element of the array.
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
        
        // Define an array to store the digits. Set the size of the array to maxDigit variable initially set to 10
        int maxDigit = 10; // initial size of the array
        int[] arr = new int[maxDigit] ; // initializing a new array of the initial size 
        int index = 0 ; // index of the arrray where we are currently at
        
        while(n != 0 )
        {
            // Check if we need to resize the array
            if(index == maxDigit )
            {
                // Increase maxDigit by 10
                maxDigit += 10 ;
                
                // Create a new temp array of size maxDigit
                int[] temp = new int[maxDigit] ;
                
                // Copy from the current arr array the digits into the temp array
                for(int i = 0; i < index; i++)
                {
                    temp[i] = arr[i];
                }
                
                // Assign the current arr array to the temp array
                arr = temp;
                
                // Now the arr array will be able to store more elements
            }
            
            arr[index] = n % 10 ; // storing the last digit of n in the array
            n = n / 10 ; // removing the last digit of n
            index ++ ; // moving the index ahead
            
            // Note: We removed the break condition since we now resize the array dynamically
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

        Console.WriteLine ( $" The largest element in the array is : {largest} and the second largest element in the array is : {( secondLargest == -1 ? "Not Found" : secondLargest )} " );
    }
}
