using System;

public class dbConn 
{
    public static bool isConnected = false;

    // setup - called before test
    public static void setup()
    {
        isConnected = true;
        Console.WriteLine("database connected (setup)");
    }

    // teardown - called after test
    public static void teardown()
    {
        isConnected = false;
        Console.WriteLine("database disconnected (teardown)");
    }

    public static void testConnection()
    {
        if(isConnected)
        {
            Console.WriteLine("test passed : connected");
        }
        else
        {
            Console.WriteLine("test failed : not connected");
        }
    }

    public static void Main(string[] args) 
    {
        /*
        5. Testing Setup and Teardown (NUnit: [SetUp] & [TearDown])
        Problem:
        Create a class DatabaseConnection with methods:
        * Connect()
        * Disconnect()
        Use [SetUp] (NUnit) or [TestInitialize] (MSTest) to initialize a database connection before each test.
        Use [TearDown] (NUnit) or [TestCleanup] (MSTest) to close the connection after each test.
        Write test cases to verify that the connection is established and closed correctly.
        */

        Console.WriteLine("Setup & Teardown Demo ");

        setup();
        testConnection();
        teardown();
        testConnection(); // should be false now

        Console.WriteLine(" Press any key...");
        Console.ReadKey();
    }
}
