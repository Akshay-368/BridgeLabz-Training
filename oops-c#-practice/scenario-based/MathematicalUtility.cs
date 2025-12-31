using System;

public class MathUtil
{
  
  public static long fact(int n)
  {
    // calculate factorial, but careful with negative and big numbers
    
    if (n < 0)
    {
      Console.WriteLine ( " cant do factorial for negative number " ) ;
      return -1 ; // some indicator its wrong
    }
    
    if (n == 0 || n == 1)
    {
      return 1 ;
    }
    
    long res = 1 ;
    
    for (int i = 2 ; i <= n ; i++)
    {
      res = res * i ;
      
      // if gets too big might overflow but ok for small n
    }
    
    return res ;
  }
  
  
  public static bool isprime(int n)
  {
    // check if number is prime
    
    if (n <= 1)
    {
      return false; // 0 and 1 not prime, negative also no
    }
    
    if (n == 2)
    {
      return true;
    }
    
    if (n % 2 == 0)
    {
      return false; // even numbers except 2 not prime
    }
    
    // check odd divisors up to sqrt(n)
    for (int i = 3; i * i <= n; i = i + 2)
    {
      if (n % i == 0)
      {
        return false;
      }
    }
    
    return true;
  }
  
  
  public static int gcd(int a, int b)
  {
    // find greatest common divisor using euclidean
    
    // make them positive first
    a = a < 0 ? -a : a;
    b = b < 0 ? -b : b;
    
    while (b != 0)
    {
      int temp = b;
      b = a % b;
      a = temp;
    }
    
    return a;
  }
  
  
  public static long fib(int n)
  {
    // nth fibonacci, simple recursive way but slow for big n
    // but since we testing small, its fine
    
    if (n < 0)
    {
      Console.WriteLine("fibonacci not defined for negative");
      return -1;
    }
    
    if (n == 0)
    {
      return 0;
    }
    
    if (n == 1 || n == 2)
    {
      return 1;
    }
    
    return fib(n-1) + fib(n-2);
  }
  
  
  public static void Main(string[] args)
  {
    /*
    2. Scenario: You are tasked with creating a utility class for mathematical operations.
    Implement the following functionalities using separate methods:
    ● A method to calculate the factorial of a number.
    ● A method to check if a number is prime.
    ● A method to find the greatest common divisor (GCD) of two numbers.
    ● A method to find the nth Fibonacci number.
    ● Test your methods with various inputs, including edge cases like zero, one, and negative numbers.
    */
    
    Console.WriteLine("testing the math utility methods");
    Console.WriteLine();
    
    // factorial tests
    Console.WriteLine("Factorial tests:");
    Console.WriteLine("fact(0) = " + fact(0));
    Console.WriteLine("fact(1) = " + fact(1));
    Console.WriteLine("fact(5) = " + fact(5));
    Console.WriteLine("fact(10)= " + fact(10));
    fact(-5); // should print error msg
    Console.WriteLine();
    
    // prime tests
    Console.WriteLine("Prime checks:");
    Console.WriteLine("2 is prime? " + isprime(2));
    Console.WriteLine("4 is prime? " + isprime(4));
    Console.WriteLine("17 is prime? " + isprime(17));
    Console.WriteLine("19 is prime? " + isprime(19));
    Console.WriteLine("1 is prime? " + isprime(1));
    Console.WriteLine("0 is prime? " + isprime(0));
    Console.WriteLine("-7 is prime? " + isprime(-7));
    Console.WriteLine();
    
    // gcd tests
    Console.WriteLine("GCD tests:");
    Console.WriteLine("gcd(48, 18) = " + gcd(48, 18));
    Console.WriteLine("gcd(7, 13) = " + gcd(7, 13));
    Console.WriteLine("gcd(100, 25) = " + gcd(100, 25));
    Console.WriteLine("gcd(-12, 18) = " + gcd(-12, 18));
    Console.WriteLine("gcd(0, 5) = " + gcd(0, 5));
    Console.WriteLine();
    
    // fibonacci tests
    Console.WriteLine("Fibonacci tests:");
    Console.WriteLine("fib(0) = " + fib(0));
    Console.WriteLine("fib(1) = " + fib(1));
    Console.WriteLine("fib(5) = " + fib(5));
    Console.WriteLine("fib(8) = " + fib(8));
    Console.WriteLine("fib(10)= " + fib(10));
    fib(-3); // error msg
    Console.WriteLine();
    
    Console.WriteLine("all tests done, press enter to close...");
    Console.ReadLine();
    
  }
}
