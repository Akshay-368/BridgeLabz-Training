// Section: Custom Data Structures
// This section defines custom data structures since the use of collection framework is prohibited.
// We implement a basic singly linked list for general list operations, a queue using the linked list,
// and a hash map using an array of buckets where each bucket is a linked list of key-value entries.
// Relationships:
// - CustomQueue<T> has-a CustomLinkedList<T> (composition): The queue owns and delegates operations to the linked list for efficient enqueue/dequeue.
//   This is essential for implementing queue behavior without built-in collections.
// - CustomHashMap<K, V> has-a array of CustomLinkedList<Entry<K, V>> (composition): The hash map manages buckets as lists to handle collisions.
//   This is crucial for hash-based quick lookups and updates.
// - Entry<K, V> is-a simple class for holding key-value pairs (basic structure): Used internally by hash map.

using System;
using System.Collections; // Only for IEnumerator interface, no collections used.

// Internal Node class for linked list (encapsulated within the file for security)
internal class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }
    public Node(T data)
    {
        Data = data;
    }
}

public class CustomLinkedList<T> : IEnumerable<T>
{
    private Node<T> head;
    private Node<T> tail;
    private int count;

    public int Count => count;

    // Adds an item to the end of the list
    public void Add(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (head == null)
        {
            head = newNode;
        }
        if (tail != null)
        {
            tail.Next = newNode;
        }
        tail = newNode;
        count++;
    }

    // Removes and returns the first item in the list (for queue dequeue)
    public T RemoveFirst()
    {
        if (head == null)
        {
            throw new InvalidOperationException("List is empty");
        }
        T data = head.Data;
        head = head.Next;
        if (head == null)
        {
            tail = null;
        }
        count--;
        return data;
    }

    // Enumerator for foreach support (implements IEnumerable for iteration)
    public IEnumerator<T> GetEnumerator()
    {
        Node<T> current = head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class CustomQueue<T>
{
    private CustomLinkedList<T> internalList = new CustomLinkedList<T>();

    public void Enqueue(T item)
    {
        internalList.Add(item);
    }

    public T Dequeue()
    {
        return internalList.RemoveFirst();
    }

    public bool IsEmpty()
    {
        return internalList.Count == 0;
    }
}

internal class Entry<K, V>
{
    public K Key { get; set; }
    public V Value { get; set; }
    public Entry(K key, V value)
    {
        Key = key;
        Value = value;
    }
}

public class CustomHashMap<K, V>
{
    private const int NumberOfBuckets = 100; // Fixed size for simplicity (KISS)
    private CustomLinkedList<Entry<K, V>>[] buckets;

    public CustomHashMap()
    {
        buckets = new CustomLinkedList<Entry<K, V>>[NumberOfBuckets];
        for (int i = 0; i < NumberOfBuckets; i++)
        {
            buckets[i] = new CustomLinkedList<Entry<K, V>>();
        }
    }

    private int CalculateHash(K key)
    {
        return Math.Abs(key.GetHashCode() % NumberOfBuckets);
    }

    // Puts a key-value pair; updates if key exists (encapsulated mutation)
    public void Put(K key, V value)
    {
        int hashIndex = CalculateHash(key);
        CustomLinkedList<Entry<K, V>> bucket = buckets[hashIndex];
        bool keyExists = false;
        foreach (Entry<K, V> entry in bucket)
        {
            if (entry.Key.Equals(key))
            {
                entry.Value = value; // Update existing (since class reference)
                keyExists = true;
                break;
            }
        }
        if (!keyExists)
        {
            bucket.Add(new Entry<K, V>(key, value));
        }
    }

    // Tries to get value by key; returns true if found
    public bool TryGetValue(K key, out V value)
    {
        value = default(V);
        int hashIndex = CalculateHash(key);
        CustomLinkedList<Entry<K, V>> bucket = buckets[hashIndex];
        foreach (Entry<K, V> entry in bucket)
        {
            if (entry.Key.Equals(key))
            {
                value = entry.Value;
                return true;
            }
        }
        return false;
    }
}

// Section: Domain Classes
// This section defines domain-specific classes like ItemInfo and Customer.
// Relationships:
// - ItemInfo is-a simple data holder (basic structure): Holds price and stock for encapsulation.
// - Customer has-a CustomLinkedList<string> for Items (composition): Customer owns and manages their list of purchased items.
//   This is essential because a customer can have multiple items, and the list is private for encapsulation.

internal class ItemInfo
{
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public ItemInfo(decimal price, int stock)
    {
        Price = price;
        Stock = stock;
    }
}

public class Customer
{
    public string CustomerName { get; private set; } // Encapsulated, read-only
    protected CustomLinkedList<string> ItemsList { get; private set; } // Protected for potential inheritance, but private set for encapsulation

    public Customer(string customerName)
    {
        CustomerName = customerName;
        ItemsList = new CustomLinkedList<string>();
    }

    // Public method to add item (encapsulation: no direct access to list)
    public void AddItemToCustomerList(string itemName)
    {
        ItemsList.Add(itemName);
    }

    // Expose items for iteration (without allowing modification)
    public IEnumerable<string> GetItems()
    {
        return ItemsList;
    }
}

// Section: Interface and Abstract Base Class
// Interface defines the contract (SOLID: Dependency Inversion).
// Abstract base class provides common logic and central storage (DRY, centralization).
// Child classes will implement customizable logic like processing checkout.
// Relationships:
// - AbstractSupermarketCheckoutSystem implements ISupermarketCheckoutSystem (is-a): Conforms to the interface contract.
// - AbstractSupermarketCheckoutSystem has-a CustomQueue<Customer> for customerQueue (composition): Owns the queue for managing customers.
//   Essential for add/remove operations.
// - AbstractSupermarketCheckoutSystem has-a CustomHashMap<string, ItemInfo> for inventoryMap (composition): Central storage for items.
//   Essential for quick price/stock access and updates, kept central to avoid duplication (DRY).
// Fields are protected for child access (encapsulation, inheritance support).

public interface ISupermarketCheckoutSystem
{
    void AddCustomerToQueue(Customer customer);
    Customer RemoveCustomerFromQueue();
    decimal GetItemPrice(string itemName);
    void UpdateStockOnPurchase(string itemName, int quantity);
    void AddItemToInventory(string itemName, decimal price, int stock);
    void ProcessCheckout(); // Customizable
}

public abstract class AbstractSupermarketCheckoutSystem : ISupermarketCheckoutSystem
{
    protected CustomQueue<Customer> customerQueue;
    protected CustomHashMap<string, ItemInfo> inventoryMap;

    // Constructor initializes central storage (passed non-primitives if needed, but here self-initialized)
    public AbstractSupermarketCheckoutSystem()
    {
        customerQueue = new CustomQueue<Customer>();
        inventoryMap = new CustomHashMap<string, ItemInfo>();
    }

    public void AddCustomerToQueue(Customer customer)
    {
        customerQueue.Enqueue(customer);
    }

    public Customer RemoveCustomerFromQueue()
    {
        return customerQueue.Dequeue();
    }

    public decimal GetItemPrice(string itemName)
    {
        if (inventoryMap.TryGetValue(itemName, out ItemInfo itemInfo))
        {
            return itemInfo.Price;
        }
        else
        {
            // Ask user for input with defaults (no hardcode)
            Console.WriteLine($"Item '{itemName}' not found in inventory.");
            Console.Write("Enter price (press Enter for default 0.00): ");
            string priceInput = Console.ReadLine();
            decimal price = string.IsNullOrEmpty(priceInput) ? 0.00m : decimal.Parse(priceInput);

            Console.Write("Enter stock (press Enter for default 0): ");
            string stockInput = Console.ReadLine();
            int stock = string.IsNullOrEmpty(stockInput) ? 0 : int.Parse(stockInput);

            inventoryMap.Put(itemName, new ItemInfo(price, stock));
            return price;
        }
    }

    public void UpdateStockOnPurchase(string itemName, int quantity)
    {
        if (inventoryMap.TryGetValue(itemName, out ItemInfo itemInfo))
        {
            if (itemInfo.Stock >= quantity)
            {
                itemInfo.Stock -= quantity; // Mutate since class reference
                // No need to put again as reference is updated
            }
            else
            {
                throw new InvalidOperationException($"Insufficient stock for '{itemName}'. Available: {itemInfo.Stock}");
            }
        }
        else
        {
            throw new KeyNotFoundException($"Item '{itemName}' not found in inventory.");
        }
    }

    public void AddItemToInventory(string itemName, decimal price, int stock)
    {
        inventoryMap.Put(itemName, new ItemInfo(price, stock));
    }

    // Abstract method for customizable logic (open for extension: SOLID Open-Closed)
    public abstract void ProcessCheckout();
}

// Section: Concrete Child Class
// This class extends the abstract base and implements the customizable ProcessCheckout.
// It processes the customer's items, calculates total, updates stock (assumes quantity 1 per item instance).
// Relationships:
// - ConcreteSupermarketCheckoutSystem is-a AbstractSupermarketCheckoutSystem (inheritance): Extends common logic.
//   Essential for customization without modifying base (SOLID: Liskov, Open-Closed).

public class ConcreteSupermarketCheckoutSystem : AbstractSupermarketCheckoutSystem
{
    // Implements abstract method in its own way (not just override for show)
    public override void ProcessCheckout()
    {
        if (customerQueue.IsEmpty())
        {
            Console.WriteLine("No customers in queue.");
            return;
        }

        Customer currentCustomer = RemoveCustomerFromQueue();
        decimal totalBillAmount = 0m;

        // Process each item (assumes each list entry is one unit; duplicates for multiples)
        foreach (string itemName in currentCustomer.GetItems())
        {
            decimal itemPrice = GetItemPrice(itemName);
            totalBillAmount += itemPrice;
            UpdateStockOnPurchase(itemName, 1); // Update for one unit
        }

        Console.WriteLine($"Processed checkout for {currentCustomer.CustomerName}. Total bill: {totalBillAmount:C}");
    }
}

// Section: Program Entry Point
// Static Main method (only static as required for entry point).
// Provides interactive menu for user input (no hardcode).
// Relationships: Program uses ConcreteSupermarketCheckoutSystem (dependency): To demonstrate the system.

public class Program
{
    public static void Main(string[] args)
    {
        ISupermarketCheckoutSystem checkoutSystem = new ConcreteSupermarketCheckoutSystem(); // Depend on interface (SOLID: D)

        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\nSmartCheckout Menu:");
            Console.WriteLine("1. Add Customer to Queue");
            Console.WriteLine("2. Process Checkout for Next Customer");
            Console.WriteLine("3. Add Item to Inventory");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    Console.Write("Enter customer name: ");
                    string customerName = Console.ReadLine();
                    Customer newCustomer = new Customer(customerName);
                    bool isAddingItems = true;
                    while (isAddingItems)
                    {
                        Console.Write("Enter item name (press Enter to stop adding items): ");
                        string itemName = Console.ReadLine();
                        if (string.IsNullOrEmpty(itemName))
                        {
                            isAddingItems = false;
                        }
                        else
                        {
                            newCustomer.AddItemToCustomerList(itemName);
                        }
                    }
                    checkoutSystem.AddCustomerToQueue(newCustomer);
                    Console.WriteLine("Customer added to queue.");
                    break;

                case "2":
                    checkoutSystem.ProcessCheckout();
                    break;

                case "3":
                    Console.Write("Enter item name: ");
                    string newItemName = Console.ReadLine();
                    Console.Write("Enter price (default 0.00 if empty): ");
                    string newPriceInput = Console.ReadLine();
                    decimal newPrice = string.IsNullOrEmpty(newPriceInput) ? 0.00m : decimal.Parse(newPriceInput);
                    Console.Write("Enter stock (default 0 if empty): ");
                    string newStockInput = Console.ReadLine();
                    int newStock = string.IsNullOrEmpty(newStockInput) ? 0 : int.Parse(newStockInput);
                    checkoutSystem.AddItemToInventory(newItemName, newPrice, newStock);
                    Console.WriteLine("Item added to inventory.");
                    break;

                case "4":
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
