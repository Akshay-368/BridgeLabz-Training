using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class listToJson 
{
    public class Product
    {
        public int id;
        public string name;
        public double price;
    }

    public static void Main(string[] args)
    {
        /*
        6. Convert a list of C# objects into a JSON array.
        */

        Console.WriteLine("List of Objects → JSON Array\n");

        List<Product> products = new List<Product>();

        products.Add(new Product { id = 1, name = "Laptop", price = 75000 });
        products.Add(new Product { id = 2, name = "Mouse", price = 1200 });
        products.Add(new Product { id = 3, name = "Keyboard", price = 2500 });
        products.Add(new Product { id = 4, name = "Monitor", price = 18000 });

        string jsonArray = JsonConvert.SerializeObject(products, Formatting.Indented);

        Console.WriteLine("JSON Array:");
        Console.WriteLine(jsonArray);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
