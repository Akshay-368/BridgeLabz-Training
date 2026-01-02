using System;
using System.Collections.Generic;

public static class prog
{
    public static void Main( string[] args )
    {
        /*
        Problem 3: Hospital, Doctors, and Patients (Association and Communication)
        Description: Model a Hospital where Doctor and Patient objects interact through consultations. A doctor can see multiple patients, and each patient can consult multiple doctors.
        Tasks:

        * Define a Hospital class containing Doctor and Patient classes.

        * Create a method Consult() in the Doctor class to show communication, which would display the consultation between a doctor and a patient.

        * Model an association between doctors and patients to show that doctors and patients can have multiple relationships.

        Goal: Practice creating an association with communication between objects by modeling doctor-patient consultations.
        */
        
        hos h = new hos("City Hospital");
        
        doc d1 = new doc("dr brown");
        doc d2 = new doc("dr white");
        
        pat p1 = new pat("john");
        pat p2 = new pat("mary");
        pat p3 = new pat("tom");
        
        h.ad(d1);
        h.ad(d2);
        h.ap(p1);
        h.ap(p2);
        h.ap(p3);
        
        // consultations , many to many
        d1.cn(p1 , "fever check");
        d1.cn(p2 , "back pain");
        d2.cn(p1 , "follow up");
        d2.cn(p3 , "surgery consult");
        
        h.sh();
    }
}

public static class hos
{
    public string nm;
    public List<doc> dl;
    public List<pat> pl;
    
    public hos(string n)
    {
        this.nm = n;
        dl = new List<doc>();
        pl = new List<pat>();
    }
    
    public void ad(doc d)
    {
        dl.Add(d);
    }
    
    public void ap(pat p)
    {
        pl.Add(p);
    }
    
    public void sh()
    {
        Console.WriteLine("Hospital : " + nm );
        Console.WriteLine("Doctors :");
        foreach(doc d in dl)
        {
            Console.WriteLine("  " + d.nm );
        }
        Console.WriteLine("Patients :");
        foreach(pat p in pl)
        {
            Console.WriteLine("  " + p.nm );
        }
    }
}

public static class doc
{
    public string nm;
    public List<string> cl; // consultation notes
    
    public doc(string n)
    {
        this.nm = n;
        cl = new List<string>();
    }
    
    public void cn(pat p , string rs)
    {
        string note = "Consulted " + p.nm + " for " + rs;
        cl.Add(note);
        Console.WriteLine(nm + " : " + note );
        // communication happens here
    }
}

public static class pat
{
    public string nm;
    
    public pat(string n)
    {
        this.nm = n;
    }
}
