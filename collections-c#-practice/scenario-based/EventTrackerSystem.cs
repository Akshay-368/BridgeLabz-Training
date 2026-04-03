using System;
using System.Reflection;
using System.Text;
using System.Collections.Generic;


//  Custom attribute to mark methods that should be audited

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class AuditTrailAttribute : Attribute
{
    // Optional description of what this action does
    public string ActionDescription { get; set; }

    public AuditTrailAttribute(string description = "User action")
    {
        ActionDescription = description;
    }
}


//  Example business/service classes that use the attribute

public class UserService
{
    [AuditTrail("User logged in to the system")]
    public void Login(string username)
    {
        Console.WriteLine($"[BUSINESS] {username} logged in");
        // pretend some work...
    }

    [AuditTrail("User uploaded a document")]
    public void UploadDocument(string filename, string user)
    {
        Console.WriteLine($"[BUSINESS] {user} uploaded {filename}");
    }

    public void ViewProfile(string user) // ← no audit
    {
        Console.WriteLine($"[BUSINESS] Viewing profile of {user}");
    }
}

public class OrderService
{
    [AuditTrail("Order was placed")]
    public void PlaceOrder(int orderId, string customer)
    {
        Console.WriteLine($"[BUSINESS] Order {orderId} placed by {customer}");
    }

    [AuditTrail("Order was cancelled by admin")]
    public void CancelOrder(int orderId)
    {
        Console.WriteLine($"[BUSINESS] Order {orderId} cancelled");
    }
}

//  Simple structure to hold audit information

public class AuditEvent
{
    public string Timestamp { get; set; }
    public string ClassName { get; set; }
    public string MethodName { get; set; }
    public string Description { get; set; }
    public string CalledBy { get; set; }     // simulated user

    public override string ToString()
    {
        return $"[{Timestamp}] {ClassName}.{MethodName} | {Description} | by {CalledBy}";
    }

    // very naive JSON-like string (no real JSON lib)
    public string ToJsonLike()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("{");
        sb.AppendLine($"  \"timestamp\": \"{Timestamp}\",");
        sb.AppendLine($"  \"class\": \"{ClassName}\",");
        sb.AppendLine($"  \"method\": \"{MethodName}\",");
        sb.AppendLine($"  \"description\": \"{Description.Replace("\"", "\\\"")}\",");
        sb.AppendLine($"  \"user\": \"{CalledBy}\"");
        sb.AppendLine("}");
        return sb.ToString();
    }
}

//  The actual EventTracker that scans and logs

public class EventTracker
{
    // we collect audit events here
    private List<AuditEvent> auditLog = new List<AuditEvent>();

    // main scanning method
    public void ScanAndGenerateAuditLog(string currentUser = "system")
    {
        Console.WriteLine("\nStarting audit scan...\n");

        Assembly currentAssembly = Assembly.GetExecutingAssembly();
        Type[] allTypes = currentAssembly.GetTypes();

        int methodsFound = 0;

        foreach(Type type in allTypes)
        {
            // skip non-class, interface, abstract, etc.
            if(!type.IsClass || type.IsAbstract || type.IsInterface)
                continue;

            Console.WriteLine($"Scanning class: {type.Name}");

            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach(MethodInfo method in methods)
            {
                // look for our AuditTrail attribute
                object[] attrs = method.GetCustomAttributes(typeof(AuditTrailAttribute), false);

                if(attrs.Length > 0)
                {
                    methodsFound++;

                    AuditTrailAttribute auditAttr = (AuditTrailAttribute)attrs[0];

                    // create audit record
                    AuditEvent ev = new AuditEvent
                    {
                        Timestamp   = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        ClassName   = type.Name,
                        MethodName  = method.Name,
                        Description = auditAttr.ActionDescription,
                        CalledBy    = currentUser
                    };

                    auditLog.Add(ev);

                    Console.WriteLine($"  -> Found audited method: {method.Name}");
                    Console.WriteLine($"      Description: {auditAttr.ActionDescription}");
                }
            }
        }

        Console.WriteLine($" Scan complete. Found {methodsFound} audited methods.");
    }

    // print all collected audit events
    public void PrintAuditLog()
    {
        if(auditLog.Count == 0)
        {
            Console.WriteLine("No audited methods found.");
            return;
        }

        Console.WriteLine(" Audit Trail Log ");

        foreach(AuditEvent ev in auditLog)
        {
            Console.WriteLine(ev.ToString());
        }
    }

    // generate simple JSON-like output
    public void ExportAsJsonLike()
    {
        Console.WriteLine(" Audit Trail JSON-like ");

        Console.WriteLine("[");
        for(int i = 0; i < auditLog.Count; i++)
        {
            Console.Write(auditLog[i].ToJsonLike());
            if(i < auditLog.Count - 1)
                Console.Write(",");
            Console.WriteLine();
        }
        Console.WriteLine("]");
    }
}


// usage

public class Program
{
    public static void Main(string[] args)
    {
        /*
        HealthCheckPro – API Metadata Validator (simplified version)
        Story: Apollo International Hospital launches a RESTful API system for lab tests. Developers
        tag each API method with custom annotations like @PublicAPI, @RequiresAuth, etc. A tool
        called HealthCheckPro is needed to scan all controller classes using Reflection, check for
        missing annotations, and auto-generate API documentation.
        ● Uses: Custom annotations, reflection for scanning methods, auto doc generation.
        */

        Console.WriteLine("EventTracker – Auto Audit System");


        Console.Write("Enter current user name (for audit log) : ");
        string currentUser = Console.ReadLine();
        if(string.IsNullOrWhiteSpace(currentUser))
            currentUser = "system";

        EventTracker tracker = new EventTracker();

        Console.WriteLine($"\nScanning assembly for methods marked with [AuditTrail] as user '{currentUser}'...\n");

        tracker.ScanAndGenerateAuditLog(currentUser);

        Console.WriteLine("\nAudit log:");
        tracker.PrintAuditLog();

        Console.WriteLine("\nJSON-like export:");
        tracker.ExportAsJsonLike();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
