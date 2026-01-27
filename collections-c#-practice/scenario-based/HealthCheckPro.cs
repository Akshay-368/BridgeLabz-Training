using System;
using System.Reflection;
using System.Collections.Generic;

// Custom attribute for public APIs (no auth required)
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class PublicAPIAttribute : Attribute
{
    // simple marker - can add description if needed
    public string Description { get; set; }

    public PublicAPIAttribute(string desc = "Public endpoint")
    {
        Description = desc;
    }
}

// Custom attribute for APIs that require authentication
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class RequiresAuthAttribute : Attribute
{
    public string RoleRequired { get; set; } = "User";

    public RequiresAuthAttribute(string role = "User")
    {
        RoleRequired = role;
    }
}

// Example controller class with annotated methods
// Relationship: LabTestController is-a Controller (convention-based)
public class LabTestController
{
    [PublicAPI("Get all available lab tests - no auth needed")]
    public string GetAllTests()
    {
        return "List of all lab tests";
    }

    [RequiresAuth("Admin")]
    public string AddNewTest(string testName)
    {
        return "Added test: " + testName;
    }

    [PublicAPI]
    [RequiresAuth("User")] // multiple attributes allowed
    public string GetTestById(int id)
    {
        return "Test details for ID " + id;
    }
}

// Interface for API scanners
// Relationship: ApiScannerBase implements IApiScanner (implements-a)
// Why : defines contract for scanning, allows different scanners (e.g., full vs partial)
public interface IApiScanner
{
    void ScanControllersAndGenerateDocs();
}

// Abstract base for scanners
// Central storage: list of found controllers/methods
// Relationship: SimpleApiScanner is-a ApiScannerBase (inheritance)
// Why essential: DRY - common reflection logic in base
// Encapsulation: protected list for children
// SOLID: single responsibility (scanning + doc generation)
// KISS/YAGNI: simple array-based storage (no List)
public abstract class ApiScannerBase : IApiScanner
{
    protected Type[] foundControllers;
    protected int controllerCount;

    protected ApiScannerBase()
    {
        foundControllers = new Type[10]; // fixed size - simple
        controllerCount = 0;
    }

    // common scan logic - find types ending with "Controller"
    protected void scanAssembly()
    {
        Assembly asm = Assembly.GetExecutingAssembly();
        Type[] types = asm.GetTypes();

        for(int i=0; i<types.Length ; i++)
        {
            Type t = types[i];
            if(t.Name.EndsWith("Controller") && !t.IsAbstract && !t.IsInterface)
            {
                foundControllers[controllerCount] = t;
                controllerCount++;
            }
        }
    }

    // abstract method for generating docs - children customize
    public abstract void GenerateApiDocumentation();
}

// Concrete simple scanner
// Relationship: SimpleApiScanner is-a ApiScannerBase
public class SimpleApiScanner : ApiScannerBase
{
    public SimpleApiScanner() : base() { }

    public void ScanControllersAndGenerateDocs()
    {
        scanAssembly();

        if(controllerCount == 0)
        {
            Console.WriteLine("no controllers found");
            return;
        }

        Console.WriteLine("Found " + controllerCount + " controllers:");
        for(int i=0; i<controllerCount ; i++)
        {
            Type ctrl = foundControllers[i];
            Console.WriteLine("\nController: " + ctrl.Name);

            MethodInfo[] methods = ctrl.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            for(int j=0; j<methods.Length ; j++)
            {
                MethodInfo m = methods[j];

                Console.WriteLine("  Method: " + m.Name);

                // check annotations
                object[] attrs = m.GetCustomAttributes(true);

                for(int k=0; k<attrs.Length ; k++)
                {
                    if(attrs[k] is PublicAPIAttribute pub)
                    {
                        Console.WriteLine("    - PublicAPI: " + pub.Description);
                    }
                    else if(attrs[k] is RequiresAuthAttribute auth)
                    {
                        Console.WriteLine("    - RequiresAuth: Role = " + auth.RoleRequired);
                    }
                }
            }
        }
    }

    public override void GenerateApiDocumentation()
    {
        ScanControllersAndGenerateDocs();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        /*
        HealthCheckPro – API Metadata Validator
        Story: Apollo International Hospital launches a RESTful API system for lab tests. Developers
        tag each API method with custom annotations like @PublicAPI, @RequiresAuth, etc. A tool
        called HealthCheckPro is needed to scan all controller classes using Reflection, check for
        missing annotations, and auto-generate API documentation.
        ● Uses: Custom annotations, reflection for scanning methods, auto doc generation.
        */

        Console.WriteLine("HealthCheckPro - API Metadata Validator ");

        IApiScanner scanner = new SimpleApiScanner();

        Console.WriteLine("Scanning current assembly for controllers...\n");

        scanner.GenerateApiDocumentation();

        Console.WriteLine(" Scan complete. Press any key to exit...");
        Console.ReadKey();
    }
}
