using System;
using Newtonsoft.Json;

public class carJson 
{
    public class Car
    {
        public string brand;
        public string model;
        public int year;
        public double price;
    }

    public static void Main(string[] args)
    {
        /*
        2. Convert a C# object (Car class) into JSON format.
        */

        Console.WriteLine("C# Object -> JSON (Car)\n");

        Car myCar = new Car();
        myCar.brand = "Toyota";
        myCar.model = "Fortuner";
        myCar.year = 2022;
        myCar.price = 4500000.50;

        string json = JsonConvert.SerializeObject(myCar, Formatting.Indented);

        Console.WriteLine("Car JSON:");
        Console.WriteLine(json);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
