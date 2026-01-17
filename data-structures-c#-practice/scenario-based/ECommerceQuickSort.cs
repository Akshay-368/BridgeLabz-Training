using System;

// Section: Product Class Definition
// This class represents a product in the e-commerce platform.
// It has-a relationship with string (for ProductName) and double (for DiscountPercentage), 
// which are essential for storing the core attributes of a product: its identifier and discount value.
// Encapsulation is used via private setters to ensure data integrity and prevent unauthorized modifications.
// This follows KISS (simple immutable data holder), YAGNI (no extra features), and Single Responsibility Principle (SRP) from SOLID (only handles product data).

class Product
{
    public string ProductName { get; private set; }
    public double DiscountPercentage { get; private set; }

    public Product(string productName, double discountPercentage)
    {
        ProductName = productName;
        DiscountPercentage = discountPercentage;
    }
}

// Section: Interface Definition
// This interface defines the contract for any product sorter.
// It specifies that implementers must provide a way to sort products.
// This follows the Interface Segregation Principle (ISP) from SOLID by keeping the contract minimal.
// No relationships here beyond defining a can-do (can sort products) capability.

interface IProductSorter
{
    void SortProducts();
}

// Section: Abstract Base Class Definition
// This abstract class provides common properties and logic for product sorters.
// It implements the IProductSorter interface (is-a relationship with IProductSorter), 
// essential for enforcing the sorting contract while allowing extension.
// It has-a relationship with Product[] (ProductsArray), essential for centralizing storage 
// of the data to be sorted, as child classes and methods will read/write to it.
// This centralization follows DRY (avoid duplicating storage in children) and SRP (base handles storage).
// The constructor passes non-primitive data (Product[]), as required.
// Access: Protected field for child access, abstract method for customization.
// This leaves customizable logic (actual sorting implementation) to children, following Open-Closed Principle (OCP) from SOLID.

abstract class AbstractProductSorter : IProductSorter
{
    protected Product[] ProductsArray; // Central storage, accessible to derived classes.

    public AbstractProductSorter(Product[] productsArray)
    {
        ProductsArray = productsArray;
    }

    public abstract void SortProducts(); // Customizable logic left for children to implement.
}

// Section: Child Class Definition (Quick Sort Implementation)
// This class specializes the abstract base for Quick Sort algorithm.
// It is-a relationship with AbstractProductSorter, essential for inheriting central storage 
// and contract while providing specific sorting behavior.
// The SortProducts method is overridden meaningfully with Quick Sort logic, not just for show.
// Private helper methods (QuickSortRecursive, PartitionProducts, SwapProducts) ensure encapsulation 
// and security by restricting access to only within this class.
// This follows Liskov Substitution Principle (LSP) from SOLID (can replace base without issues), 
// DRY (reuses base storage), and KISS (straightforward recursive Quick Sort).
// Sorting is by discount descending (higher discounts first), as per "top discounted products".
// No unnecessary statics; everything instance-based to avoid memory waste.

class QuickSortProductSorter : AbstractProductSorter
{
    public QuickSortProductSorter(Product[] productsArray) : base(productsArray)
    {
    }

    public override void SortProducts()
    {
        if (ProductsArray == null || ProductsArray.Length <= 1)
        {
            return; // No sort needed for empty or single element.
        }
        QuickSortRecursive(0, ProductsArray.Length - 1);
    }

    private void QuickSortRecursive(int lowIndex, int highIndex)
    {
        if (lowIndex < highIndex)
        {
            int partitionIndex = PartitionProducts(lowIndex, highIndex);
            QuickSortRecursive(lowIndex, partitionIndex - 1);
            QuickSortRecursive(partitionIndex + 1, highIndex);
        }
    }

    private int PartitionProducts(int lowIndex, int highIndex)
    {
        double pivotDiscount = ProductsArray[highIndex].DiscountPercentage;
        int smallerIndex = lowIndex - 1;

        for (int currentIndex = lowIndex; currentIndex < highIndex; currentIndex++)
        {
            if (ProductsArray[currentIndex].DiscountPercentage > pivotDiscount) // Descending order.
            {
                smallerIndex++;
                SwapProducts(smallerIndex, currentIndex);
            }
        }

        SwapProducts(smallerIndex + 1, highIndex);
        return smallerIndex + 1;
    }

    private void SwapProducts(int firstIndex, int secondIndex)
    {
        Product temporaryProduct = ProductsArray[firstIndex];
        ProductsArray[firstIndex] = ProductsArray[secondIndex];
        ProductsArray[secondIndex] = temporaryProduct;
    }
}

// Section: Main Program Entry Point
// This contains the static Main method (necessary static for program entry).
// It handles user input with defaults (no hardcoding), creates products array, 
// uses the sorter classes, and displays results.
// Relationships: Uses QuickSortProductSorter (has-a temporary reference), which is-a AbstractProductSorter.
// This follows Dependency Inversion Principle (DIP) from SOLID by depending on abstraction (IProductSorter).
// No collections; only arrays. Input validation minimal for KISS/YAGNI.

class FlashDealzProductSorterProgram
{
    static void Main(string[] args)
    {
        // Prompt for number of products with default.
        Console.Write("Enter the number of products to sort (default is 5): ");
        string numberInput = Console.ReadLine();
        int numberOfProducts = string.IsNullOrEmpty(numberInput) ? 5 : int.Parse(numberInput);

        Product[] productsArray = new Product[numberOfProducts];

        // Gather product details from user.
        for (int index = 0; index < numberOfProducts; index++)
        {
            Console.Write($"Enter the name for product {index + 1}: ");
            string productName = Console.ReadLine();

            Console.Write($"Enter the discount percentage for {productName} (0-100): ");
            string discountInput = Console.ReadLine();
            double discountPercentage = string.IsNullOrEmpty(discountInput) ? 0.0 : double.Parse(discountInput);

            productsArray[index] = new Product(productName, discountPercentage);
        }

        // Create sorter and perform sort.
        IProductSorter productSorter = new QuickSortProductSorter(productsArray);
        productSorter.SortProducts();

        // Display sorted results.
        Console.WriteLine(" Sorted products by discount percentage (descending order - top discounts will be first):");
        for (int index = 0; index < productsArray.Length; index++)
        {
            Console.WriteLine($"{productsArray[index].ProductName}: {productsArray[index].DiscountPercentage}%");
        }
    }
}
