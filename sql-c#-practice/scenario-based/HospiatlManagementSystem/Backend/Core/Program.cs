/* // See https://aka.ms/new-console-template for more information
// Built with :dotnet new console -n DatabaseConnection
// And then inside( as this has .csproj file which is needed for the package reference) this, I downloaded the package reference: dotnet add package Microsoft.Data.SqlClient 
// and then run dotnet build as a safe practice to make sure everything is in place before running the code.

using Microsoft.Data.SqlClient;

// 1. Define your credentials
string server = "localhost\\SQLEXPRESS"; // e.g., localhost or DESKTOP-XXXXX
string database = "HospitalDb";
string user = "sa"; // otherwise i would have to use Trusted_Connection ='True' and then it would use my windows credentials, but for simplicity, I'm using SQL Server Authentication with the 'sa' user.
string pass = "root";

// 2. Build the connection string
// Note: TrustServerCertificate is usually needed for local dev
string connectionString = $"Server={server};Database={database};User Id={user};Password={pass};TrustServerCertificate=True;";

Console.WriteLine("--- Clinic App Connection Test ---");

// 3. The "Using" block is your best friend - it auto-closes the connection
using (SqlConnection connection = new SqlConnection(connectionString))
// here we have sqlconnection class , with a connection named reference and new is the kyeword and sqlconnection() is the constructorand this [new sqlconnection() constructoor i called object]
{
    try 
    {
        connection.Open(); // open is a non-static method, so we need an instance of the connection to call it, which is why we created the 'connection' object above.
        Console.WriteLine("Successfully connected to the Hospital database!");
        
        // Let's run a quick query to see if our Specialties table is there
        string sql = "SELECT COUNT(*) FROM Specialties";
        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            int count = (int)command.ExecuteScalar();
            Console.WriteLine($"Confirmed: You have {count} specialties in the system.");
        }

        // Let's run a quick reading query to see some data from the Patients table
        string SqlPatients = "Select TOP 5 * FROM Patients";
        using (SqlCommand command1 = new SqlCommand(SqlPatients , connection))
        {
            using ( SqlDataReader reader = command1.ExecuteReader())
            {
                Console.WriteLine(" Sample Patients ");
                while (reader.Read())
                {
                    // Assuming Patients table has columns: Id, Name, Age
                    int id = reader.GetInt32(0); // 0-based index for columns
                    string name = reader.GetString(1);
                    int age = reader.GetInt32(2);
                    Console.WriteLine($"ID: {id}, Name: {name}, Age: {age}");
                }
                reader.Close(); // not strictly necessary due to the using block, but it's good practice to explicitly close when done.
            }
        }
        connection.Close(); // not strictly necessary due to the using block, but it's good practice to explicitly close when done.
    }
    catch (Exception ex)
    {
        Console.WriteLine("Connection Failed!");
        Console.WriteLine("Error: " + ex.Message);
    }
} 


// 3. Gather Patient Data (The Input "Form")
        Console.Write("First Name: ");
        string fName = Console.ReadLine()!;

        Console.Write("Last Name: ");
        string lName = Console.ReadLine()!;

        Console.Write("Gender (Male/Female/Other): ");
        string gender = Console.ReadLine()!;

        Console.Write("Date of Birth (YYYY-MM-DD): ");
        DateTime dob = DateTime.Parse(Console.ReadLine()!);

        Console.Write("Contact Number: ");
        string contact = Console.ReadLine()!;

        Console.Write("Email: ");
        string email = Console.ReadLine()!;

        Console.Write("Address: ");
        string address = Console.ReadLine()!;

        Console.Write("Blood Group (Leave blank if unknown): ");
        string bloodGroupInput = Console.ReadLine()!;
        string? bloodGroup = string.IsNullOrWhiteSpace(bloodGroupInput) ? null : bloodGroupInput;

        Console.WriteLine("\n--- Create Login Credentials ---");
        Console.Write("Desired Username: ");
        string username = Console.ReadLine()!;

        Console.Write("Password: ");
        string password = Console.ReadLine()!;

        try
        {
            Console.WriteLine("\nProcessing Registration...");

            // 4. Generate Security Keys
            var security = PasswordHasher.HashNewPassword(password);

            // 5. Send to Database (The Transaction)
            int newPatientId = await utility.RegisterPatientAsync(
                username, 
                security.Hash, 
                security.Salt,
                fName, lName, gender, dob, contact, email, address , bloodGroup
            );

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"SUCCESS! Patient registered. New Patient ID: {newPatientId}");
        }
        catch (SqlException ex) when (ex.Number == 2627) // Error 2627 is Unique Key Violation
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: That Username or Contact Number is already taken.");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Registration Failed: {ex.Message}");
        }
        finally
        {
            Console.ResetColor();
        }



*/


using System;
using Core;
using Utilities;
using Entities;
using Services;
using Microsoft.Data.SqlClient;

class Program
{
    static async Task Main()
    {
        // 1. Setup Infrastructure
        using var db = new DbConnection(); // Keep connection alive for the session
        var utility = new UserQueryUtility(db);
        
        // 2. Simulate Receptionist Login (Optional for now, but good practice)
        // In a real app, you'd log in as Receptionist first to set 'UserId' context.
        // For now, we are running as 'sa' via DbConnection, so we have permission.

        Console.WriteLine("=== HOSPITAL RECEPTION: NEW User REGISTRATION ===");
        Console.WriteLine("1. Register New Patient");
        Console.WriteLine("2. Register New Doctor");
        Console.WriteLine("3. Register New Staff");
        Console.WriteLine("4. Register New Role_Admin (Manager)");
        Console.WriteLine("5. Login to System");
        Console.WriteLine("0. Exit");
        Console.Write("\nSelect Option: ");
        
        string choice = Console.ReadLine()!;

        do {
            switch (choice)
            {
                case "1":
                    await RegisterPatientFlow(utility);
                    break;
                case "2":
                    await RegisterDoctorFlow(utility);
                    break;
                case "3":
                    await RegisterStaffFlow(utility);
                    break;
                case "4":
                    await RegisterAdminFlow(utility); 
                    break;
                case "5":
                    // --- THE LOGIN PORTAL ---
                    Console.WriteLine("\n--- SYSTEM LOGIN ---");
                    Console.Write("Username: "); string uname = Console.ReadLine()!;
                    Console.Write("Password: "); string pwd = Console.ReadLine()!; // In real app, hide input
                    
                    try {
                        var session = await utility.LoginAsync(uname, pwd);
                        
                        if (session != null)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"\nLOGIN SUCCESSFUL! Welcome, {session.Username} ({session.Role})");
                            Console.ResetColor();
                            
                            // Route to the correct dashboard based on role
                            if (session.Role == "Receptionist") 
                            {
                                await RunReceptionistMenu(utility, session);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine(">>> Dashboard for this role is under construction.");
                                Console.ResetColor();
                            }
                        }
                        else 
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Login Failed: Invalid Username or Password.");
                            Console.ResetColor();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"System Error during login: {ex.Message}");
                    }
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid selection.");
                    break;
            }

            Console.WriteLine("\n1. Register New Patient");
            Console.WriteLine("2. Register New Doctor");
            Console.WriteLine("3. Register New Staff");
            Console.WriteLine("4. Register New Role_Admin (Manager)");
            Console.WriteLine("5. Login to System");
            Console.WriteLine("0. Exit");
            Console.Write("\nSelect Option: ");
            choice = Console.ReadLine()!;
        } while (choice != "0");
        
    }

    // --- PATIENT REGISTRATION FLOW ---
    static async Task RegisterPatientFlow(UserQueryUtility utility)
    {
        Console.WriteLine("\n=== NEW PATIENT REGISTRATION ===");

        Console.Write("First Name: "); string fName = Console.ReadLine()!;
        Console.Write("Last Name: "); string lName = Console.ReadLine()!;
        Console.Write("Gender (Male/Female/Other): "); string gender = Console.ReadLine()!;
        Console.Write("Date of Birth (YYYY-MM-DD): "); DateTime dob = DateTime.Parse(Console.ReadLine()!);
        Console.Write("Contact Number: "); string contact = Console.ReadLine()!;
        Console.Write("Email: "); string email = Console.ReadLine()!;
        Console.Write("Address: "); string address = Console.ReadLine()!;

        Console.Write("Blood Group (Leave blank if unknown): ");
        string bloodGroupInput = Console.ReadLine()!;
        string? bloodGroup = string.IsNullOrWhiteSpace(bloodGroupInput) ? null : bloodGroupInput;

        Console.WriteLine("\n--- Create Login Credentials ---");
        Console.Write("Desired Username: "); string username = Console.ReadLine()!;
        Console.Write("Password: "); string password = Console.ReadLine()!;

        try
        {
            Console.WriteLine("\nProcessing Patient Registration...");
            var security = PasswordHasher.HashNewPassword(password);

            int newPatientId = await utility.RegisterPatientAsync(
                username, security.Hash, security.Salt,
                fName, lName, gender, dob, contact, email, address, bloodGroup
            );

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"SUCCESS! Patient registered. New Patient ID: {newPatientId}");
        }
        catch (SqlException ex) when (ex.Number == 2627)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: That Username or Contact Number is already taken.");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Registration Failed: {ex.Message}");
        }
        finally { Console.ResetColor(); }
    }

    static async Task RegisterDoctorFlow(UserQueryUtility utility)
    {
        Console.WriteLine("\n=== NEW DOCTOR REGISTRATION ===");
        
        // Basic Info
        Console.Write("First Name: "); string fName = Console.ReadLine()!;
        Console.Write("Last Name: "); string lName = Console.ReadLine()!;
        Console.Write("Gender (Male/Female/Other): "); string gender = Console.ReadLine()!;
        Console.Write("DOB (YYYY-MM-DD): "); DateTime dob = DateTime.Parse(Console.ReadLine()!);
        Console.Write("Contact: "); string contact = Console.ReadLine()!;
        Console.Write("Email: "); string email = Console.ReadLine()!;
        Console.Write("Consultation Fee: "); decimal fee = decimal.Parse(Console.ReadLine()!);

        // Specialty Selection
        var specialties = await utility.GetSpecialtiesAsync();
        Console.WriteLine("\nAvailable Specialties:");
        foreach (var spec in specialties)
            Console.WriteLine($"{spec.Id}. {spec.Name}");
        
        Console.Write("Select Specialty ID: ");
        int specId = int.Parse(Console.ReadLine()!);

        // Login Info
        Console.WriteLine("\n--- Create Login Credentials ---");
        Console.Write("Username: "); string username = Console.ReadLine()!;
        Console.Write("Password: "); string password = Console.ReadLine()!;

        try
        {
            Console.WriteLine("Processing...");
            var security = PasswordHasher.HashNewPassword(password);
            
            int docId = await utility.RegisterDoctorAsync(
                username, security.Hash, security.Salt,
                fName, lName, gender, dob, contact, email, specId, fee);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"SUCCESS! Doctor ID {docId} registered and Monday schedule created.");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally { Console.ResetColor(); }
    }


    static async Task RegisterStaffFlow(UserQueryUtility utility)
    {
        Console.WriteLine("\n=== NEW STAFF REGISTRATION ===");
        Console.WriteLine("Select Role: 1. Receptionist, 2. Nurse, 3. Pharmacist, 4. IT_Staff");
        string roleChoice = Console.ReadLine()!;
        
        string jobTitle = roleChoice switch {
            "1" => "Receptionist",
            "2" => "Nurse",
            "3" => "Pharmacist",
            "4" => "IT_Staff",
            _ => "Other"
        };

        // Standard Info
        Console.Write("First Name: "); string fName = Console.ReadLine()!;
        Console.Write("Last Name: "); string lName = Console.ReadLine()!;
        Console.Write("Gender (Male/Female/Other): "); string gender = Console.ReadLine()!;
        Console.Write("DOB (YYYY-MM-DD): "); DateTime dob = DateTime.Parse(Console.ReadLine()!);
        Console.Write("Contact: "); string contact = Console.ReadLine()!;
        Console.Write("Email: "); string email = Console.ReadLine()!;

        Console.WriteLine($"\n--- Create Login for {jobTitle} ---");
        Console.Write("Username: "); string username = Console.ReadLine()!;
        Console.Write("Password: "); string password = Console.ReadLine()!;

        try
        {
            var security = PasswordHasher.HashNewPassword(password);
            int staffId = await utility.RegisterStaffAsync(
                username, security.Hash, security.Salt, jobTitle, // UserRole
                fName, lName, gender, dob, jobTitle, contact, email // Staff table
            );

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"SUCCESS! {jobTitle} registered. Staff ID: {staffId}");
        }
        catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally { Console.ResetColor(); }
    }



    static async Task RegisterAdminFlow(UserQueryUtility utility)
{
    Console.WriteLine("\n=== NEW ADMINISTRATIVE REGISTRATION ===");
    
    // 1. Gatekeeper Check
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("Enter Management Authorization Key: ");
    string userEnteredKey = Console.ReadLine()!;
    Console.ResetColor();

    if (string.IsNullOrWhiteSpace(userEnteredKey))
    {
        Console.WriteLine("Authorization required to proceed.");
        return;
    }

    // 2. Collect Admin Details
    Console.Write("First Name: "); string fName = Console.ReadLine()!;
    Console.Write("Last Name: "); string lName = Console.ReadLine()!;
    Console.Write("Gender (Male/Female/Other): "); string gender = Console.ReadLine()!;
    Console.Write("DOB (YYYY-MM-DD): "); DateTime dob = DateTime.Parse(Console.ReadLine()!);
    Console.Write("Contact: "); string contact = Console.ReadLine()!;
    Console.Write("Email: "); string email = Console.ReadLine()!;

    Console.WriteLine("\n--- Create Administrative Credentials ---");
    Console.Write("Username: "); string username = Console.ReadLine()!;
    Console.Write("Password: "); string password = Console.ReadLine()!;

    try
    {
        Console.WriteLine("Verifying Authorization and Registering...");
        var security = PasswordHasher.HashNewPassword(password);

        // This calls the utility method we created earlier
        int adminId = await utility.RegisterAdminAsync(
            username, security.Hash, security.Salt,
            fName, lName, gender, dob, contact, email, userEnteredKey
        );

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nSUCCESS! Administrator Profile created.");
        Console.WriteLine($"Staff ID: {adminId} | Role: Hospital_Admin");
    }
    catch (SqlException ex) when (ex.Message.Contains("Invalid Admin Secret Key"))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nSECURITY ERROR: The Management Key provided is incorrect.");
        // Optional: Log this attempt to a file or database
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\nRegistration Failed: {ex.Message}");
    }
    finally { Console.ResetColor(); }
}






static async Task RunReceptionistMenu(UserQueryUtility utility, UserSession session)
    {
        // 1. CRITICAL: Set SQL Session Context so database triggers know who is acting
        await utility.SetSessionContextAsync(session.UserId , session.Role);

        bool logout = false;
        while (!logout)
        {
            Console.WriteLine($"\n=== RECEPTIONIST DASHBOARD ({session.Username}) ===");
            Console.WriteLine("1. Register New Patient");
            Console.WriteLine("2. View All Patients");
            Console.WriteLine("3. Search Patient by Name");
            Console.WriteLine("4. [Security Test] Try Accessing Medical Records");
            Console.WriteLine("0. Logout");
            Console.Write("Action: ");
            
            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1": 
                    // Receptionists use the same flow, but now the DB knows IT'S THEM doing it
                    await RegisterPatientFlow(utility); 
                    break;
                case "2":
                    await ShowAllPatients(utility);
                    break;
                case "3":
                    Console.Write("\nEnter Last Name to Search: ");
                    string searchName = Console.ReadLine()!;
                    if (string.IsNullOrWhiteSpace(searchName))
                    {
                        Console.WriteLine("Search term cannot be empty.");
                        break;
                    }
                    Console.WriteLine("\nSearching Patient Directory...");
                    
                    // Call the search method
                    var results = await utility.SearchPatientsByLastNameAsync(searchName, session.Role);
                    
                    // Display results (Reuse your directory printing logic)
                    PrintPatientTable(results); 
                    break;
                case "4":
                    await TestRestrictedAccess(utility);
                    break;
                case "0":
                    logout = true;
                    Console.WriteLine("Logging out...");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    // --- HELPER FUNCTIONS FOR RECEPTIONIST ---

    static async Task ShowAllPatients(UserQueryUtility utility)
    {
        Console.WriteLine("\nLoading Patient Directory...");
        try 
        {
            var patients = await utility.GetAllPatientsAsync();
            
            Console.WriteLine("\n--- PATIENT DIRECTORY ---");
            Console.WriteLine("{0,-5} | {1,-20} | {2,-15}", "ID", "Name", "Contact");
            Console.WriteLine(new string('-', 45));
            
            foreach(var p in patients)
            {
                Console.WriteLine($"{p.Id,-5} | {p.LastName}, {p.FirstName,-10} | {p.Contact,-15}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching data: {ex.Message}");
        }
    }


    static void PrintPatientTable(List<PatientSummary> patients)
    {
        if (patients == null || patients.Count == 0)
        {
            Console.WriteLine("\nNo patients found matching those criteria.");
            return;
        }

        Console.WriteLine("\n--- PATIENT DIRECTORY ---");
        Console.WriteLine("{0,-5} | {1,-20} | {2,-15}", "ID", "Name", "Contact");
        Console.WriteLine(new string('-', 45));

        foreach (var p in patients)
        {
            // Formatting: Lastname, Firstname
            string fullName = $"{p.LastName}, {p.FirstName}";
            // Ensure name isn't too long for the column
            if (fullName.Length > 20) fullName = fullName.Substring(0, 17) + "...";

            Console.WriteLine($"{p.Id,-5} | {fullName,-20} | {p.Contact,-15}");
        }
    }

    

    static async Task TestRestrictedAccess(UserQueryUtility utility)
    {
        Console.WriteLine("\n--- SECURITY AUDIT: ATTEMPTING UNAUTHORIZED ACCESS ---");
        Console.WriteLine("Trying to read table 'Visits' (Clinical Data)...");
        try
        {
            // This calls "SELECT * FROM Visits"
            await utility.GetMedicalVisitsRawAsync(); 
            
            // If we get here, security FAILED
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("CRITICAL WARNING: Access was GRANTED. Security roles are not configured correctly.");
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("SECURITY VIOLATION") || ex.Message.Contains("permission was denied"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("SUCCESS: Access Denied. The database correctly blocked this user.");
            }
            else
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }
        }
        Console.ResetColor();
    }



}

