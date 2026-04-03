using System;
using System.Collections.Generic;

public class triage 
{
    // patient class with name and severity
    public class Patient
    {
        public string name;
        public int severity; // higher = more urgent

        public Patient(string n,int s)
        {
            name = n;
            severity = s;
        }
    }

    // priority queue for triage
    // higher severity first
    public static void hospitalTriage()
    {
        // priority queue - higher severity first
        // we use SortedSet with custom comparer (reverse order)
        SortedSet<Patient> queue = new SortedSet<Patient>(new PatientComparer());

        // add some patients
        queue.Add(new Patient("John", 3));
        queue.Add(new Patient("Alice", 5));
        queue.Add(new Patient("Bob", 2));

        Console.WriteLine("Triage order (highest severity first):");

        while(queue.Count > 0)
        {
            Patient p = queue.Max; // highest first
            queue.Remove(p);

            Console.WriteLine(p.name + " (severity " + p.severity + ")");
        }
    }

    // custom comparer - higher severity first
    public class PatientComparer : IComparer<Patient>
    {
        public int Compare(Patient a,Patient b)
        {
            return b.severity.CompareTo(a.severity); // reverse order
        }
    }

    public static void Main(string[] args) 
    {
        /*
        Queue Interface Problems
        3. Hospital Triage System
        Simulate a hospital triage system using a PriorityQueue where patients with higher severity are treated first.
        Example:
        Patients: [ ("John", 3), ("Alice", 5), ("Bob", 2) ]
        Order: Alice, John, Bob
        */

        Console.WriteLine("Hospital Triage System (higher severity first)\n");

        hospitalTriage();

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
