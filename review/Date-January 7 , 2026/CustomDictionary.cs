using System;

namespace CustomDictionary
{
    // First using  Interface to define the storage container and having the functionailty to display as well
    interface IWordStorage
    {
        void AddWord(string word ); // method to take the word and add it
        void DisplayWords(); // to display the words
    }

    // Base class with encapsulation and abstraction to keep it safe and secure and hide implementation details
    abstract class WordManager : IWordStorage
    {
        private string[] words = new string[0]; // using array

        // trying to keep it secure by exposing only required methods
        public void AddWord(string word)
        {
            // first checking if the word is empty or null or not.
            if (string.IsNullOrWhiteSpace(word)) return;
            word = word.Trim(); // to remove any extra space

            // Resize array
            string[] newWords = new string[words.Length + 1]; // this array is a temporary and local and has a scope for only the method
            // creating the new array for storing the words
            for (int i = 0; i < words.Length; i++){
                // loop through the array one by one and storing it in the array
                newWords[i] = words[i];
            }
            newWords [words.Length ] = word ;
            words = newWords ; // to update the words string array
        }

        // Using protected get for child class
        protected string [] GetWords()
        {
            return words ;
            // Now returning the words array for the caller method
        }
    

    // Now using abstract method  to have the child to implement display

    public abstract void DisplayWords();


    }

    // Child class to Group by first letter
    class AlphabetSectionStorage : WordManager
    {

        public override void DisplayWords() // uding the concept of polymorphism by overriding to use the method we described in base class
        {
            string[] words = GetWords();
            Console.WriteLine(" Words Grouped by First Letter ");
            for (char c = 'A'; c <= 'Z'; c++)
            {
                bool found = false;
                foreach (string word in words)
                {
                    if (word.ToUpper()[0] == c) // checking if the very first word of the letter to uppercase is the word to be searched for
                    {
                        if (!found) // sine we kept it as false so to make sure it run for the first time to print the section heading
                        {
                            Console.WriteLine($"\nSection {c}:"); // using escape sequence to go to next line while traversing
                            found = true;
                        }
                        Console.WriteLine("  " + word);
                    }
                }
            }
        }
    }

    // Child for Sorting alphabetically
    // This is for sorting the dictionary
    class SortedStorage : WordManager
    {
        public override void DisplayWords()
        {
            string[] words = GetWords();
            // using simple sort by comparing adjacent elements continuously
            for (int i = 0; i < words.Length - 1; i++)
            {
                for (int j = 0; j < words.Length - i - 1; j++)
                {
                    if (string.Compare(words[j], words[j + 1], true) > 0)
                    {
                        string temp = words[j]; // making a tempeorary variable to store the current next word to not loose it during swapping
                        words[j] = words[j + 1]; // now we can simply swap them with each other
                        words[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("Words Sorted Alphabetically");
            foreach (string word in words) // traversing through the word and simply printing them
                Console.WriteLine("  " + word);
        }
    }


    class DictionaryProgram
    {
        public static void Run()
        {
            Console.WriteLine(" Choose method: 1 = Alphabet Sections, 2 = Sorted " );
            string choice = Console.ReadLine();

            IWordStorage storage; // Polymorphism to do  interface reference
            if (choice == "1")
                storage = new AlphabetSectionStorage(); // have two different section for the storage
            else
                storage = new SortedStorage(); // if user called for storage then we will do the storing

            Console.WriteLine("Enter words (typing  'exit'or 'Exit' to stop):");
            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "exit") break; // converting the input from the user into lowercase firstly to break
                storage.AddWord(input);
            }

            storage.DisplayWords();
        }
    }
}
