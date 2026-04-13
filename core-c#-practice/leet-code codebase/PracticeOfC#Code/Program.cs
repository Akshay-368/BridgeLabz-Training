// See https://aka.ms/new-console-template for more information
namespace Playground;
using EmailVerification;
using QuizRankingSystem;
using KeyGeneration;
using SupermarketInventory;
public class Program
{
    public static void Main(string[] args)
    {
        /* int n = Convert.ToInt32( Console.ReadLine());
        for ( int i = 0 ; i < n ; i++){ 
            string s = Console.ReadLine();
            EmailVerification email = new EmailVerification();
            if (email.isEmailValid(s)) Console.WriteLine("Acess Granted");
            else Console.WriteLine("Access Denied"); 
        }
        */
        /* Console.WriteLine(char.IsUpper('A'));
        Console.WriteLine(char.IsUpper('9'));
        Console.WriteLine(char.IsUpper('a'));
        Console.WriteLine(char.IsUpper('&')); */

        /* int n = Convert.ToInt32(Console.ReadLine());

        QuizRankingManager manager = new QuizRankingManager();

        manager.processCommands(n); */

        /* int n = Convert.ToInt32 (Console.ReadLine());
        for ( int i = 0 ; i < n ; i++)
        {
            KeyGeneration key = new KeyGeneration();
            string s = Console.ReadLine();
            key.Run(s);
        } */

        int n = Convert.ToInt32(Console.ReadLine());

        InventoryManager manager = new InventoryManager();

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            // Example:
            // Electronics, Laptop, 800.00, 5, 12

            string[] parts = input.Split(',');

            // Trim spaces manually
            for (int j = 0; j < parts.Length; j++)
            {
                parts[j] = parts[j].Trim();
            }

            string type = parts[0];

            // TODO: Create objects based on type
            if (type == "Electronics")
            {
                // string name = ?
                // double price = ?
                // int quantity = ?
                // int warranty = ?

                string name = parts[1];
                double price = Convert.ToDouble(parts[2]);
                int quantity = Convert.ToInt32(parts[3]);
                int warranty = Convert.ToInt32(parts[4]);
                Electronics e = new Electronics (name , price , quantity , warranty);
                manager.addProduct(e);

                // Electronics e = new Electronics(...);
                // manager.addProduct(e);
            }
            else if (type == "Clothing")
            {
                // string name = ?
                // double price = ?
                // int quantity = ?
                // string size = ?

                string name = parts[1];
                double price = Convert.ToDouble(parts[2]);
                int quantity = Convert.ToInt32(parts[3]);
                string size = parts[4];
                Clothing c = new Clothing ( name ,price , quantity , size);
                manager.addProduct(c);

                // Clothing c = new Clothing(...);
                // manager.addProduct(c);
            }
        }

        // After input processing
        
        manager.displayInventory();

        manager.calculateTotalValue();
        
        
    }
}