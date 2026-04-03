// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


/*
Program Name: Email Validator
use the concepts of multithreading, IO file handling and Annotation with Regex.

Email Validator – College Admission Portal

C# Concepts:
● Pattern, Matcher
● Regex for email validation
● Exception Handling
● Modular method design

Scenario:
You're building the backend for EduConnect, an online admission portal used by universities
across India. During the student registration process, email verification is crucial to prevent
typos, spam, and duplicate entries.

Problem Statement:
Create a c# module to:
● Accept user emails at registration
● Validate the email address using regex:
○ Must follow the format: username@domain.extension
○ Allow alphanumeric usernames, dots (.), underscores (_)
○ Domain should be alphabetic (gmail, yahoo, blitz.ac.in etc.)
○ Extension should be .com, .in, .org, .edu, etc.

Sample Valid Emails:
● john.doe@gmail.com
Scenario-based Problems
● megha_r92@outlook.in
● admin@blitz.edu

Sample Invalid Emails:
● john.doe@gmail (missing .com)
● @gmail.com (missing username)
● raju#123@inbox.com (invalid character)

Sample Regex:
String regex = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,6}$";
*/

using System;
using System.Collections.Generic;
using System.Collections.Concurrent; // Required for ConcurrentBag
using System.Dynamic;
using System.IO ;
using System.Linq ;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EduConnectPortal ;

// Annotations ( Attributes )

public class ValidatorAttribute : Attribute
{
    public string Version  { get; }
    public string Description { get; } 
    public ValidatorAttribute ( string version , string description)
    {
        Version = version ;
        Description = description ;
    }
}

// Interface

internal interface IEmailVerifier
{
    bool Verify( string email ) ;
}

// Abstract Base Class which will keep the common implementation ,variables and logic

internal abstract class BaseEmailVerifier : IEmailVerifier
{
    protected readonly Regex _regex ;
    protected BaseEmailVerifier (string pattern)
    {
        // Constructor
        _regex = new Regex ( pattern , RegexOptions.Compiled | RegexOptions.IgnoreCase ) ;
    }
    public abstract bool Verify ( string email ); // Must be public to fulfill the IEmailVerifier contract as any method of the interface must be public implicitly
}

// Child class of BaseEmailVerifier with concrete implementation
internal class UniversityEmailVerifier : BaseEmailVerifier
{
    private const string Pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$";
    
    // Adding  the constructor to pass 'Pattern' to the base class
    public UniversityEmailVerifier() : base(Pattern) 
    { 
    }
    public override bool Verify ( string email )
    {
        if ( string.IsNullOrWhiteSpace(email)) return false ;
        return _regex.IsMatch ( email ) ;
    }
}

// Data Model for Json File
public class EmailData
{
    public string Email { get; set; }
    public bool IsValid { get; set; }
    public string ProcessedAt { get; set; }
}

// I/O and Multithreading Processor
internal class RegistrationProcessor
{
    private readonly IEmailVerifier _emailVerifier;
    public RegistrationProcessor ( IEmailVerifier emailVerifier )
    {
        _emailVerifier = emailVerifier ;
    }
    public async Task ProcessRegistrationsAsync ( string inputPath , string outputPath )
    {
        try
        {
            // IO: Read all emails
            var rawData = await File.ReadAllLinesAsync(inputPath);
            
            // Multithreading safe collection
            var processedResults = new ConcurrentBag<EmailData>();

            // Multithreading: Parallel processing of the list
            Parallel.ForEach(rawData, (email) =>
            {
                processedResults.Add(new EmailData
                {
                    Email = email,
                    IsValid = _emailVerifier.Verify(email.Trim()),
                    ProcessedAt = DateTime.Now.ToString("F")
                });
            });

            // JSON Serialization
            var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(processedResults, jsonOptions);

            // IO: Save as JSON
            await File.WriteAllTextAsync(outputPath, jsonString);
            Console.WriteLine($"Successfully saved {processedResults.Count} records to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        // Setup input file for testing
        string input = "emails.txt";
        string output = "EduConnect_Results.json";

        if (!File.Exists(input))
        {
            await File.WriteAllLinesAsync(input, new[] { 
                "john.doe@gmail.com", 
                "megha_r92@outlook.in", 
                "admin@blitz.edu", 
                "raju#123@inbox.com" ,
                "admin@blitz.com",
                "dave#123@inbox.com"
            });
        }

        // Execution
        var verifier = new UniversityEmailVerifier();
        var processor = new RegistrationProcessor(verifier);
        
        await processor.ProcessRegistrationsAsync(input, output);
    }
}
