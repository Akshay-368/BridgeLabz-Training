using System;
using System.Collections.Generic;

public class invMap 
{
    // invert dictionary K->V to V->List<K>
    // example: {A=1, B=2, C=1} → {1=[A,C], 2=[B]}
    public static void invertDictionary(Dictionary<string,int> originalMap)
    {
        // new dictionary: value -> list of keys
        Dictionary<int,List<string>> inverted = new Dictionary<int,List<string>>();

        // go through each key-value pair
        foreach(KeyValuePair<string,int> pair in originalMap)
        {
            string key = pair.Key;
            int value = pair.Value;

            // if value already in inverted
            if(inverted.ContainsKey(value))
            {
                inverted[value].Add(key);
            }
            else
            {
                // create new list
                List<string> keyList = new List<string>();
                keyList.Add(key);
                inverted[value] = keyList;
            }
        }

        Console.WriteLine("Inverted map:");
        foreach(KeyValuePair<int,List<string>> pair in inverted)
        {
            Console.Write(pair.Key + " = [");
            for(int i=0; i<pair.Value.Count ; i++)
            {
                Console.Write(pair.Value[i]);
                if(i < pair.Value.Count-1) Console.Write(", ");
            }
            Console.WriteLine("]");
        }
    }

    public static void Main(string[] args) 
    {
        /*
        2. Invert a Map
        Invert a Dictionary<K, V> to produce a Dictionary<V, List<K>>.
        Example:
        Input: { A=1, B=2, C=1 }
        Output: { 1=[A, C], 2=[B] }
        */

        Console.WriteLine("Invert Dictionary (Key -> Value) to (Value -> List of Keys)\n");

        Console.Write("Waiting , for user to enter how many entries : ");
        int n = Convert.ToInt32(Console.ReadLine());

        Dictionary<string,int> orig = new Dictionary<string,int>();

        Console.WriteLine("enter key-value pairs (key string , value number):");
        for(int i=0; i<n ; i++)
        {
            Console.Write("key " + (i+1) + " : ");
            string k = Console.ReadLine();

            Console.Write("value for " + k + " : ");
            int v = Convert.ToInt32(Console.ReadLine());

            orig[k] = v;
        }

        Console.WriteLine("\nOriginal map:");
        foreach(KeyValuePair<string,int> p in orig)
        {
            Console.WriteLine(p.Key + " = " + p.Value);
        }

        invertDictionary(orig);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
