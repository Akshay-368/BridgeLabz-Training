using System;
using System.Collections.Generic;
using System.Text.RegularExpressions ;
using System.Linq;
namespace SupermarketInventory;

/*
Question #2: Supermarket Store 
Joseph is the owner of a Supermarket Store. He wants to implement a simple inventory system for his Supermarket Store. 
The program should be able to handle 3 parts: 
● Add products 
● Display product details 
● Calculate the total value of products in the inventory 
1. Add Product 
Given: 
For electronics: 
"Electronics", <ProductName(string)> <price (double)>, <quantity (integer)>, <warranty period (integer)> 
For clothing: 
"Clothing", <name (string)>, <price (double)>, <quantity (integer)>, <size (string)> 
Output: 
When adding a product, print: 
"Product added to inventory: <product name>" 
(The sequence of the product names will be the same as given in the input.) 2. Display Inventory
Display the inventory details after adding the product, one product per line. Output: 
For Electronic Product: 
<Product Name> - Price: <Product price>, Quantity: <Product quantity>, Warranty: <product warranty period> months 
For Clothing Product: 
<Product Name> - Price: <Product price>, Quantity: <Product quantity>, Size: <size as S/M/L/XL> 
3. Calculate Total Value 
Calculates the total value (up to 2 decimal places) of all products in the inventory by summing: 
price * quantity for each product. 
Output: 
Print: 
Total value of the inventory: <total value> 
Implementation Requirement 
Implement the inventory system for his retail store using Object-Oriented Programming (OOP) concepts. 
Function Description 
Class: Product (abstract class)
Represents a general product. 
Attributes 
● String name 
● double price 
● int quantity 
Methods 
abstract void display() 
→ Displays product details. 
double calculateValue() 
→ Returns price × quantity. 
Class: Electronics (extends Product) Additional Attribute 
● int warranty 
Overrides 
display() → Prints electronic product details, including warranty. 
Class: Clothing (extends Product) Additional Attribute 
● String size 
Overrides
display() → Prints clothing product details including size. 
Class: InventoryManager 
Maintains a List<Product> inventory. 
Methods 
void addProduct(Product product) 
→ Adds product and prints confirmation message. 
void displayInventory() 
→ Displays all product details. 
void calculateTotalValue() 
→ Calculates and prints total inventory value (2 decimal places). 
Input Format 
The first line contains a single integer num, denoting the number of products to be added. The next num lines will contain information about each product as follows: 
For electronics: 
"Electronics", <ProductName(string)> <price (double)>, <quantity (integer)>, <warranty period (integer)> 
For clothing: 
"Clothing", <name (string)>, <price (double)>, <quantity (integer)>, <size (string)> 
Sample Input 
3 
Electronics, Laptop, 800.00, 5, 12
Clothing, T-shirt, 15.99, 20, M 
Electronics, Smartphone, 400.00, 10, 24 
Output Format 
The output will be in 3 parts. For each operation (add, display, calculate), print the corresponding output as described below. 
1. addProduct(product) 
When adding a product, print: 
Product added to inventory: <product name> 
(The sequence of the product names will be the same as given in the input) 
2. displayInventory() 
When displaying the inventory, print the details of all products in the inventory as specified above. 
3. calculateTotalValue() 
Calculates the total value of all products in the inventory by summing price × quantity for each product. 
Print: 
Total value of the inventory: <total value> 
Sample Output 
Product added to inventory: Laptop 
Product added to inventory: T-shirt 
Product added to inventory: Smartphone
Inventory: 
Laptop - Price: 800.0, Quantity: 5, Warranty: 12 months 
T-shirt - Price: 15.99, Quantity: 20, Size: M 
Smartphone - Price: 400.0, Quantity: 10, Warranty: 24 months 
Total value of the inventory: 11047.00 
Explanation 
In the sample input, we add three products to the inventory: a laptop, a T-shirt, and a smartphone. 
1. Add Product 
Product added to inventory: Laptop 
Product added to inventory: T-shirt 
Product added to inventory: Smartphone 
2. Display Inventory 
Inventory: 
Laptop - Price: 800.0, Quantity: 5, Warranty: 12 months 
T-shirt - Price: 15.99, Quantity: 20, Size: M 
Smartphone - Price: 400.0, Quantity: 10, Warranty: 24 months 
3. Calculate Total Value (up to 2 decimal places) 
Total value of the inventory: 11047.00

*/

// 🔷 Abstract Base Class
public abstract class Product
{
    protected string name;
    protected double price;
    protected int quantity;

    public Product(string name, double price, int quantity)
    {
        this.name = name;
        this.price = price;
        this.quantity = quantity;
    }

    // TODO: Override in child classes
    public abstract void display();

    // Already implemented for you
    public double calculateValue()
    {
        return price * quantity;
    }

    public string getName()
    {
        return name;
    }
}

// 🔷 Electronics Class
public class Electronics : Product
{
    private int warranty;

    public Electronics(string name, double price, int quantity, int warranty)
        : base(name, price, quantity)
    {
        this.warranty = warranty;
    }

    public override void display()
    {
        // WRITE YOUR CODE HERE
        Console.WriteLine($"{name} - Price: {price}, Quantity: {quantity}, Warranty: {warranty} months");
    }
}

// 🔷 Clothing Class
public class Clothing : Product
{
    private string size;

    public Clothing(string name, double price, int quantity, string size)
        : base(name, price, quantity)
    {
        this.size = size;
    }

    public override void display()
    {
        // WRITE YOUR CODE HERE
        Console.WriteLine($"{name} - Price: {price}, Quantity: {quantity}, Size: {size}");
    }
}

// 🔷 Inventory Manager
public class InventoryManager
{
    private List<Product> inventory = new List<Product>();

    public void addProduct(Product product)
    {
        // WRITE YOUR CODE HERE
        inventory.Add(product);
        Console.WriteLine($"Product added to inventory: {product.getName()}");
    }

    public void displayInventory()
    {
        // WRITE YOUR CODE HERE
        Console.WriteLine("Inventory:");
        foreach ( Product p in inventory)
        {
            p.display();
        }

    }

    public void calculateTotalValue()
    {
        // WRITE YOUR CODE HERE
        double totalvalue = 0 ;

        foreach (Product p in inventory)
        {
            totalvalue += p.calculateValue();
        }

        Console.WriteLine($"Total value of the inventory: {totalvalue:F2}" );
    }
}

