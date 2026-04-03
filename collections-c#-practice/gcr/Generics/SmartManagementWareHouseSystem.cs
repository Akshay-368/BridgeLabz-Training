using System;
using System.Collections.Generic;

// abstract class for all warehouse items
// this is base for all types like electronics , groceries etc
// why abstract: so we can have common properties but force children to implement specifics
// Relationship: Electronics is-a WarehouseItem (inheritance)
// same for others
// essential cuz all items share id , name but differ in details
public abstract class WarehouseItem
{
    public int ItemId { get; set; }
    public string ItemName { get; set; }

    public WarehouseItem(int id, string name)
    {
        ItemId = id;
        ItemName = name;
    }

    // abstract method to show details , children must override
    public abstract void ShowItemDetails();
}

// concrete class for electronics item
// inherits from WarehouseItem
// adds battery life as extra
public class Electronics : WarehouseItem
{
    public int BatteryLifeHours { get; set; }

    public Electronics(int id, string name, int battery) : base(id, name)
    {
        BatteryLifeHours = battery;
    }

    public override void ShowItemDetails()
    {
        Console.WriteLine("Electronics: " + ItemName + " (ID " + ItemId + ") Battery: " + BatteryLifeHours + " hours");
    }
}

// concrete class for groceries
// inherits from WarehouseItem
// adds expiry date
public class Groceries : WarehouseItem
{
    public string ExpiryDate { get; set; }

    public Groceries(int id, string name, string expiry) : base(id, name)
    {
        ExpiryDate = expiry;
    }

    public override void ShowItemDetails()
    {
        Console.WriteLine("Groceries: " + ItemName + " (ID " + ItemId + ") Expiry: " + ExpiryDate);
    }
}

// concrete class for furniture
// inherits from WarehouseItem
// adds material type
public class Furniture : WarehouseItem
{
    public string MaterialType { get; set; }

    public Furniture(int id, string name, string material) : base(id, name)
    {
        MaterialType = material;
    }

    public override void ShowItemDetails()
    {
        Console.WriteLine("Furniture: " + ItemName + " (ID " + ItemId + ") Material: " + MaterialType);
    }
}

// generic class Storage<T> with constraint T must be WarehouseItem
// this means T has to be WarehouseItem or its child
// generics allow us to reuse code for different types safely
// under the hood: generics are compile time , at runtime its specific type
// value type vs reference type: for value types like int , generics use separate class
// for reference like classes , shared code but type safe
// variance: contravariance/invariance/covariance - here invariant cuz no in/out
// List<T> inside is generic collection
// List<T> is resizable array , under hood uses array , doubles size when full
// functions: Add , Remove , Count , etc
// why use List: dynamic size , easy add/remove
// essential for storing items without fixed size
public class Storage<T> where T : WarehouseItem
{
    // List<T> to store items
    // List<T> is from System.Collections.Generic
    // its a dynamic array , starts with capacity 0 or 4 , grows by doubling
    // stores reference types on heap , value types boxed if needed but here T is class so reference
    // key functions: Add (appends) , RemoveAt (by index) , Count (size)
    // we use it cuz array fixed size , list grows
    private List<T> itemsList;

    public Storage()
    {
        itemsList = new List<T>();
    }

    // add item to storage
    public void AddItemToStorage(T item)
    {
        itemsList.Add(item);
        Console.WriteLine("added item " + item.ItemName);
    }

    // display all items
    public void DisplayAllItems()
    {
        if (itemsList.Count == 0)
        {
            Console.WriteLine("no items yet");
            return;
        }

        Console.WriteLine("All items:");
        for (int i = 0; i < itemsList.Count ; i++ )
        {
            itemsList[i].ShowItemDetails();
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        /*
        Smart Warehouse Management System
        o Concepts: Generic Classes, Constraints, Variance
        o Problem Statement: Develop a warehouse system that manages
        different types of items (Electronics, Groceries, Furniture).
        o Hints:
         Create an abstract class WarehouseItem that all items
        extend (Electronics, Groceries, Furniture).
         Implement a generic class Storage<T> where T :
        WarehouseItem to store items safely.
         Implement a method to display all items using List<T>.
        */

        Console.WriteLine("Smart Warehouse System\n");

        // create storage for electronics
        Storage<Electronics> elecStorage = new Storage<Electronics>();

        // create storage for groceries
        Storage<Groceries> grocStorage = new Storage<Groceries>();

        // create storage for furniture
        Storage<Furniture> furnStorage = new Storage<Furniture>();

        int ch = 0;
        while(ch != 4)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1 Add electronics");
            Console.WriteLine("2 Add groceries");
            Console.WriteLine("3 Add furniture");
            Console.WriteLine("4 Print all");
            Console.WriteLine("5 Exit");

            Console.Write("Waiting , for user to enter choice : ");
            ch = Convert.ToInt32(Console.ReadLine());

            if(ch == 1)
            {
                Console.Write("Enter id : ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter name : ");
                string nam = Console.ReadLine();
                Console.Write("Enter battery hours : ");
                int bat = Convert.ToInt32(Console.ReadLine());

                Electronics elec = new Electronics(id, nam, bat);
                elecStorage.AddItemToStorage(elec);
            }
            else if(ch == 2)
            {
                Console.Write("Enter id : ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter name : ");
                string nam = Console.ReadLine();
                Console.Write("Enter expiry date : ");
                string exp = Console.ReadLine();

                Groceries groc = new Groceries(id, nam, exp);
                grocStorage.AddItemToStorage(groc);
            }
            else if(ch == 3)
            {
                Console.Write("Enter id : ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter name : ");
                string nam = Console.ReadLine();
                Console.Write("Enter material : ");
                string mat = Console.ReadLine();

                Furniture furn = new Furniture(id, nam, mat);
                furnStorage.AddItemToStorage(furn);
            }
            else if(ch == 4)
            {
                Console.WriteLine("\nElectronics:");
                elecStorage.DisplayAllItems();

                Console.WriteLine("\nGroceries:");
                grocStorage.DisplayAllItems();

                Console.WriteLine("\nFurniture:");
                furnStorage.DisplayAllItems();
            }
        }
    }
}
