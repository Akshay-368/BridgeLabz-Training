using System;

public class prod 
{
    // simple product class with generic type T for category
    // T can be BookCategory or ClothingCategory
    // we use generic here so we can have different categories safely
    public static class Product<T>
    {
        public static string name;
        public static double price;
        public static T category;

        public static void setProduct(string n,double p,T cat)
        {
            name = n;
            price = p;
            category = cat;
            Console.WriteLine("product added: " + name);
        }

        public static void printProduct()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Price: " + price);
            Console.WriteLine("Category: " + category);
        }
    }

    // generic discount method
    // T must be some category type
    public static void applyDisc<T>(double percent)
    {
        if(percent < 0 || percent > 100)
        {
            Console.WriteLine("wrong discount , using 0");
            return;
        }

        double discAmount = Product<T>.price * (percent / 100);
        Product<T>.price = Product<T>.price - discAmount;

        Console.WriteLine("discount applied " + percent + "%");
        Console.WriteLine("new price: " + Product<T>.price);
    }

    public static void Main(string[] args)
    {
        /*
        2. Dynamic Online Marketplace
        o Concepts: Type Parameters, Generic Methods, Constraints
        o Problem Statement: Build a generic product catalog for an online
        marketplace supporting various product types.
        o Hints:
         Define a generic class Product<T> where T is restricted to a
        category (BookCategory, ClothingCategory).
         Implement a generic method void ApplyDiscount<T>(T
        product, double percentage) where T : Product.
         Ensure type safety while allowing multiple product
        categories in the catalog.
        */

        Console.WriteLine("Dynamic Marketplace\n");

        // dummy category classes (just markers)
        class BookCategory { public override string ToString() { return "Book"; } }
        class ClothingCategory { public override string ToString() { return "Clothing"; } }

        int ch = 0;
        while(ch != 5)
        {
            Console.WriteLine("1 Add book");
            Console.WriteLine("2 Add clothing");
            Console.WriteLine("3 Apply discount");
            Console.WriteLine("4 Print current product");
            Console.WriteLine("5 Exit");

            Console.Write("Waiting , for user to enter choice : ");
            ch = Convert.ToInt32(Console.ReadLine());

            if(ch == 1)
            {
                Console.Write("enter book name : ");
                string nm = Console.ReadLine();
                Console.Write("enter price : ");
                double pr = Convert.ToDouble(Console.ReadLine());

                Product<BookCategory>.setProduct(nm, pr, new BookCategory());
            }
            else if(ch == 2)
            {
                Console.Write("enter clothing name : ");
                string nm = Console.ReadLine();
                Console.Write("enter price : ");
                double pr = Convert.ToDouble(Console.ReadLine());

                Product<ClothingCategory>.setProduct(nm, pr, new ClothingCategory());
            }
            else if(ch == 3)
            {
                Console.Write("enter discount % : ");
                double disc = Convert.ToDouble(Console.ReadLine());

                // apply to current product (last added)
                applyDisc<BookCategory>(disc); // or ClothingCategory , depends on last
            }
            else if(ch == 4)
            {
                Product<BookCategory>.printProduct(); // last added will show
            }
        }
    }
}
