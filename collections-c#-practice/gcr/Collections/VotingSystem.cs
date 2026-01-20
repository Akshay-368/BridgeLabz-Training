using System;
using System.Collections.Generic;

public class voteSys 
{
    // dictionary for votes - candidate name -> count
    public static Dictionary<string,int> votesDict = new Dictionary<string,int>();

    // sorted dictionary - auto sorted by key (candidate name)
    public static SortedDictionary<string,int> sortedVotes = new SortedDictionary<string,int>();

    public static void addVote(string candidate)
    {
        if(votesDict.ContainsKey(candidate))
        {
            votesDict[candidate]++;
        }
        else
        {
            votesDict[candidate] = 1;
        }

        // also add to sorted
        sortedVotes[candidate] = votesDict[candidate];

        Console.WriteLine("vote added for " + candidate);
    }

    public static void showResults()
    {
        Console.WriteLine("Voting Results (normal order):");
        foreach(KeyValuePair<string,int> v in votesDict)
        {
            Console.WriteLine(v.Key + " : " + v.Value);
        }

        Console.WriteLine("\nSorted by candidate name:");
        foreach(KeyValuePair<string,int> v in sortedVotes)
        {
            Console.WriteLine(v.Key + " : " + v.Value);
        }
    }

    public static void Main(string[] args) 
    {
        /*
        Design a Voting System
        * Dictionary<string, int> to store votes.
        * SortedDictionary to display results in order.
        * LinkedHashMap to maintain the order of votes.
        */

        Console.WriteLine("Simple Voting System\n");

        int ch = 0;
        while(ch != 3)
        {
            Console.WriteLine("1 Cast vote");
            Console.WriteLine("2 Show results");
            Console.WriteLine("3 Exit");

            Console.Write("Waiting , for user to enter choice : ");
            ch = Convert.ToInt32(Console.ReadLine());

            if(ch == 1)
            {
                Console.Write("enter candidate name : ");
                string cand = Console.ReadLine();
                addVote(cand);
            }
            else if(ch == 2)
            {
                showResults();
            }
        }
    }
}
