using System;

public class meal 
{
    // interface for all meal types
    // every meal plan must tell what it is
    public interface IMealPlan
    {
        string getMealType();
    }

    // vegetarian meal type
    public class VegetarianMeal : IMealPlan
    {
        public string getMealType()
        {
            return "Vegetarian";
        }
    }

    // vegan meal type
    public class VeganMeal : IMealPlan
    {
        public string getMealType()
        {
            return "Vegan";
        }
    }

    // keto meal type
    public class KetoMeal : IMealPlan
    {
        public string getMealType()
        {
            return "Keto";
        }
    }

    // high protein meal type
    public class HighProteinMeal : IMealPlan
    {
        public string getMealType()
        {
            return "High-Protein";
        }
    }

    // generic class for meal plan
    // T must be some IMealPlan type
    // generic means we can reuse same class for different meal types
    public static class Meal<T> where T : IMealPlan
    {
        public static string mealName;
        public static int calories;

        public static void setMeal(string name,int cal)
        {
            mealName = name;
            calories = cal;
            Console.WriteLine("meal set: " + name);
        }

        // generic method to validate and print
        // T must be IMealPlan
        public static void validateAndShow(T mealType)
        {
            Console.WriteLine("Meal type: " + mealType.getMealType());
            Console.WriteLine("Name: " + mealName);
            Console.WriteLine("Calories: " + calories);

            // simple validation (just example)
            if(calories < 300)
            {
                Console.WriteLine("low calorie meal - good for diet");
            }
            else if(calories > 800)
            {
                Console.WriteLine("high calorie - good for bulking");
            }
            else
            {
                Console.WriteLine("balanced meal");
            }
        }
    }

    public static void Main(string[] args)
    {
        /*
        1. Personalized Meal Plan Generator
        * Concepts: Generic Methods, Constraints, Interfaces
        * Problem Statement: Design a system where users can choose different meal categories like Vegetarian, Vegan, Keto, or High-Protein.
        * Hints: 
          * Define an interface IMealPlan with subtypes (VegetarianMeal, VeganMeal).
          * Implement a generic class Meal<T> where T : IMealPlan.
          * Use a generic method to validate and generate meal plans dynamically.
        */

        Console.WriteLine("Personalized Meal Plan Generator\n");

        int ch = 0;
        while(ch != 5)
        {
            Console.WriteLine("1 Vegetarian");
            Console.WriteLine("2 Vegan");
            Console.WriteLine("3 Keto");
            Console.WriteLine("4 High Protein");
            Console.WriteLine("5 Exit");

            Console.Write("Waiting , for user to enter choice : ");
            ch = Convert.ToInt32(Console.ReadLine());

            if(ch == 1)
            {
                Console.Write("enter meal name : ");
                string nm = Console.ReadLine();
                Console.Write("enter calories : ");
                int cal = Convert.ToInt32(Console.ReadLine());

                VegetarianMeal veg = new VegetarianMeal();
                Meal<VegetarianMeal>.setMeal(nm, cal);
                Meal<VegetarianMeal>.validateAndShow(veg);
            }
            else if(ch == 2)
            {
                Console.Write("enter meal name : ");
                string nm = Console.ReadLine();
                Console.Write("enter calories : ");
                int cal = Convert.ToInt32(Console.ReadLine());

                VeganMeal vgn = new VeganMeal();
                Meal<VeganMeal>.setMeal(nm, cal);
                Meal<VeganMeal>.validateAndShow(vgn);
            }
            else if(ch == 3)
            {
                Console.Write("enter meal name : ");
                string nm = Console.ReadLine();
                Console.Write("enter calories : ");
                int cal = Convert.ToInt32(Console.ReadLine());

                KetoMeal kt = new KetoMeal();
                Meal<KetoMeal>.setMeal(nm, cal);
                Meal<KetoMeal>.validateAndShow(kt);
            }
            else if(ch == 4)
            {
                Console.Write("enter meal name : ");
                string nm = Console.ReadLine();
                Console.Write("enter calories : ");
                int cal = Convert.ToInt32(Console.ReadLine());

                HighProteinMeal hp = new HighProteinMeal();
                Meal<HighProteinMeal>.setMeal(nm, cal);
                Meal<HighProteinMeal>.validateAndShow(hp);
            }
        }
    }
}
