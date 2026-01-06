using System;
using System.Collections.Generic;

// class to hold one call log
public class clog
{
   private string phn;     
   private string msg;     
   private DateTime tm;    

   // properties for encapsulation
   public string phon
   { 
      get { return phn;}
      set { phn = value;}
   }

   public string mesg
   { 
      get { return msg;}
      set { msg = value;}
   }

   public DateTime timp
   { 
      get { return tm;}
      set { tm = value;}
   }

   // method to print this log
   public void prnt()
   {
      Console.WriteLine("Phone: "+phn);
      Console.WriteLine("Time : "+tm);
      Console.WriteLine("Message: "+msg);

   }
}

// manager class for all logs
public class clman
{
   private List<clog> logs = new List<clog>();   // using List as array concept , easy to add

   // add new call log
   public void addl(clog c)
   {
      logs.Add(c);     // simple add
   }

   // search by keyword in message
   public void srck(string key)
   {
      Console.WriteLine("Search results for keyword: \""+key+"\"\n");

      bool fnd = false;
      foreach(clog c in logs)
      {
         if(c.mesg.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0)   // contains ignore case
         {
            c.prnt();
            fnd = true;
         }
      }

      if(!fnd)
         Console.WriteLine("No logs found with that keyword.");
   }

   // filter by time range
   public void filtr(DateTime st, DateTime en)
   {
      Console.WriteLine("Logs between "+st+" and "+en+"\n");

      bool fnd = false;
      foreach(clog c in logs)
      {
         if(c.timp >= st && c.timp <= en)
         {
            c.prnt();
            fnd = true;
         }
      }

      if(!fnd)
         Console.WriteLine("No logs in this time range.");
   }

   // just to show all logs , extra helper
   public void allp()
   {
      Console.WriteLine("All Call Logs:\n");
      foreach(clog c in logs)
      {
         c.prnt();
      }
   }
}

public class telcom
{
   public static void Main(string[] args)
   {
      /*
      Customer Service Call Log Manager
      Scenario: Telecom company tracking call logs. Requirements:
      ● Store logs in a Array of CallLogs.
      ● Each log contains PhoneNumber, Message, Timestamp.
      ● Filter logs by time range, search by keywords in message (string.Contains).
      ● Methods: AddCallLog(), SearchByKeyword(), FilterByTime().
      */

      clman man = new clman();   // manager object

      // creating some sample logs
      clog l1 = new clog();
      l1.phon = "9876543210";
      l1.mesg = "Customer complained about network issue in Delhi area";
      l1.timp = new DateTime(2026, 1, 5, 10, 30, 0);

      clog l2 = new clog();
      l2.phon = "9123456789";
      l2.mesg = "Billing query regarding last month recharge";
      l2.timp = new DateTime(2026, 1, 5, 14, 15, 0);

      clog l3 = new clog();
      l3.phon = "9988776655";
      l3.mesg = "Port out request received from customer";
      l3.timp = new DateTime(2026, 1, 6, 9, 45, 0);

      clog l4 = new clog();
      l4.phon = "9765432109";
      l4.mesg = "Network complaint - no signal in basement";
      l4.timp = new DateTime(2026, 1, 6, 11, 20, 0);

      clog l5 = new clog();
      l5.phon = "9555112233";
      l5.mesg = "Happy with service, gave positive feedback";
      l5.timp = new DateTime(2026, 1, 6, 16, 50, 0);

      // adding them
      man.addl(l1);
      man.addl(l2);
      man.addl(l3);
      man.addl(l4);
      man.addl(l5);

      // show all first
      man.allp();

      // search demo
      man.srck("network");

      man.srck("billing");

      // time filter demo
      DateTime startt = new DateTime(2026, 1, 6, 0, 0, 0);
      DateTime endd = new DateTime(2026, 1, 6, 23, 59, 59);

      man.filtr(startt, endd);

      // waitng , for user to enter the inupt before closng
      Console.WriteLine("Press any key to exit call log manager...");
      Console.ReadKey();
   }
}
