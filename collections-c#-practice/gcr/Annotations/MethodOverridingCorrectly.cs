using System;

public class animal 
{
    public class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Some generic animal sound...");
        }
    }

    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Woof Woof!");
        }
    }

    public static void Main(string[] args) 
    {
        /*
        Exercise 1: Use Method Overriding Correctly
        Problem Statement: Create a parent class Animal with a method MakeSound(). 
        Then, create a Dog class that overrides this method using override.
        Steps to Follow:
        1. Define a MakeSound() method in the Animal class.
        2. Override it in the Dog class with override.
        3. Instantiate Dog and call MakeSound().
        */

        Console.WriteLine("Method Overriding Demo");

        Animal generic = new Animal();
        Console.Write("Generic animal: ");
        generic.MakeSound();

        Dog myDog = new Dog();
        Console.Write("Dog: ");
        myDog.MakeSound();

        // polymorphic call
        Animal dogAsAnimal = new Dog();
        Console.Write("Dog as Animal: ");
        dogAsAnimal.MakeSound();

        Console.WriteLine(" Press any key...");
        Console.ReadKey();
    }
}
