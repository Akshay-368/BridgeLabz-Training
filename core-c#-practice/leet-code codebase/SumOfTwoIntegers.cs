// Leetcode - 371 Sum of Two Integers
/*
Given two integers a and b, return the sum of the two integers without using the operators + and -.

 

Example 1:

Input: a = 1, b = 2
Output: 3
Example 2:

Input: a = 2, b = 3
Output: 5
 

Constraints:

-1000 <= a, b <= 1000
*/

public class Solution {
    public int GetSum(int a, int b) {
        int XorResult , AndResult , AndResultLeftShiftedByOne  ;
        int Result = a | b ; // in case if b is 0
        if (b == 0) return a; // Quick exit for 0 carry
        do {
        XorResult = a ^ b ;
        Result = XorResult  ;
        // using xor since with the help of xor we get 
        // 0 ^ 0 = 0 ; 0 ^ 1 = 1 ; 1 ^ 1 = 0 ...
        // all that's what we need except the carry. 
        // so let's say a = 2 => 10 , b = 3 => 11 , a + b = 5 = 101
        // XorResult = 01 ;
        // AndResult = ( 10 ) ( which comes from a & b ) ;
        // Result = XorResult ^ ( AndResult ) [ as we want basically to have 100 
        // instead of 10 as that's the exact spot where the carry should have been added] 
        // Result = 001 ^ 100 = 101
        // and now if we further tried 001 & 100 = 000 => stop .
        AndResult =  a & b ;
        if ( AndResult == 0 ) break ;
        AndResultLeftShiftedByOne = AndResult << 1;
        a = XorResult ;
        b = AndResultLeftShiftedByOne ;

        } while ( b != 0 );

        return Result ;
    }
}

// Or another simpler way to write this code would be like this :
public class Solution {
    public int GetSum(int a, int b) {
        while ( b != 0 ){
            // XOR handles the addition and AND + Left Shift handles the carry.
            int XorResult = a ^ b ;
            int Carry = ( a & b ) << 1 ;

            a = XorResult ;
            b = Carry ;
        }
         return a ;
    }
}
