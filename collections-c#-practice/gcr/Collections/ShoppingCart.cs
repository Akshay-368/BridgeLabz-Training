using System;
using System.Collections.Generic;

public class shopCart 
{
    // dictionary for product -> price
    public static Dictionary<string,double> cartItems = new Dictionary<string,double>();

    // sorted dictionary - sorted by price
    public static SortedDictionary<double,string> sortedByPrice = new SortedDictionary<double,string>();

    public static void addToCart(string product,double price)
    {
        if(cartItems.ContainsKey(product))
        {
            Console.WriteLine(product + " already in cart");
        }
        else
        {
            cartItems[product] = price;
            sortedByPrice[price] = product;
            Console.WriteLine(product + " added to cart");
        }
    }

    public static void showCart()
    {
        Console.WriteLine("Shopping Cart (normal):");
        foreach(KeyValuePair<string,double> item in cartItems)
        {
            Console.WriteLine(item.Key + " - Rs." + item.Value);
        }

        Console.WriteLine("\nSorted by price:");
        foreach(KeyValuePair<double,string> item in sortedByPrice)
        {
            Console.WriteLine(item.Value + " - Rs." + item.Key);
        }
    }

    public static void Main(string[] args) 
    {
        /*
        Implement a Shopping Cart
        * Dictionary<string, double> to store product prices.
        * LinkedDictionary to maintain order.
        * SortedDictionary to display items sorted by price.
        */

        Console.WriteLine("Simple Shopping Cart\n");

        int ch = 0;
        while(ch != 3)
        {
            Console.WriteLine("1 Add product");
            Console.WriteLine("2 Show cart");
            Console.WriteLine("3 Exit");

            Console.Write("Waiting , for user to enter choice : ");
            ch = Convert.ToInt32(Console.ReadLine());

            if(ch == 1)
            {
                Console.Write("enter product name : ");
                string prod = Console.ReadLine();
                Console.Write("enter price : ");
                double pr = Convert.ToDouble(Console.ReadLine());

                addToCart(prod, pr);
            }
            else if(ch == 2)
            {
                showCart();
            }
        }
    }
}
