namespace Utilities;

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Core;
using Microsoft.Data.SqlClient;

internal class ExportData
{
    public async Task ExportDataAsync()
    {


        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("         EXPORT CONTACTS           ");
        Console.WriteLine("-----------------------------------");
        Console.ResetColor();

        Console.WriteLine("Select Export Format:");
        Console.WriteLine("1. JSON");
        Console.WriteLine("2. CSV");
        Console.WriteLine("3. TXT");

        Console.Write("\nEnter choice: ");
        string input = Console.ReadLine();

        string format = input switch
        {
            "1" => "json",
            "2" => "csv",
            "3" => "txt",
            _ => null
        };

        if (format == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid choice.");
            Console.ResetColor();
            return;
        }

        try
        {
            List<ContactDto> contacts = await FetchContactsAsync();

            if (contacts.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No contacts available to export.");
                Console.ResetColor();
                return;
            }

            string fileName = $"Contacts_{DateTime.Now:yyyyMMdd_HHmmss}.{format}";

            switch (format)
            {
                case "json":
                    await ExportJsonAsync(contacts, fileName);
                    break;

                case "csv":
                    await ExportCsvAsync(contacts, fileName);
                    break;

                case "txt":
                    await ExportTxtAsync(contacts, fileName);
                    break;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nExport Successful!");
            Console.WriteLine($"Saved as: {fileName}");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Export Failed:");
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }
    }

    // FETCH DATA FROM DATABASE


    private async Task<List<ContactDto>> FetchContactsAsync()
    {
        List<ContactDto> list = new List<ContactDto>();

        using DbConnection db = new DbConnection();

        SqlConnection connection = await db.OpenAsync();

        string query = "SELECT * FROM Contacts";

        using SqlCommand cmd = new SqlCommand(query, connection);

        using SqlDataReader reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            ContactDto contact = new ContactDto
            {
                ContactId = Convert.ToInt32(reader["ContactId"]),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                PhoneNumber = reader["PhoneNumber"].ToString(),
                Email = reader["Email"]?.ToString(),
                Address = reader["Address"]?.ToString(),
                ContactType = reader["ContactType"].ToString(),
                RelationType = reader["RelationType"].ToString(),
                IsVip = Convert.ToBoolean(reader["IsVip"])
            };

            list.Add(contact);
        }

        return list;
    }

    // EXPORT JSON
 

    private async Task ExportJsonAsync(List<ContactDto> contacts, string fileName)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(contacts, options);

        await File.WriteAllTextAsync(fileName, json);
    }

 
    // EXPORT CSV


    private async Task ExportCsvAsync(List<ContactDto> contacts, string fileName)
    {
        StringBuilder sb = new StringBuilder();

        // Header
        sb.AppendLine("ContactId,FirstName,LastName,Phone,Email,Address,Type,Relation,IsVip");

        foreach (var c in contacts)
        {
            sb.AppendLine(
                $"{c.ContactId}," +
                $"{c.FirstName}," +
                $"{c.LastName}," +
                $"{c.PhoneNumber}," +
                $"{c.Email}," +
                $"{c.Address}," +
                $"{c.ContactType}," +
                $"{c.RelationType}," +
                $"{c.IsVip}"
            );
        }

        await File.WriteAllTextAsync(fileName, sb.ToString());
    }


    // EXPORT TXT


    private async Task ExportTxtAsync(List<ContactDto> contacts, string fileName)
    {
        StringBuilder sb = new StringBuilder();

        foreach (var c in contacts)
        {

            sb.AppendLine($"ID       : {c.ContactId}");
            sb.AppendLine($"Name     : {c.FirstName} {c.LastName}");
            sb.AppendLine($"Phone    : {c.PhoneNumber}");
            sb.AppendLine($"Email    : {c.Email ?? "N/A"}");
            sb.AppendLine($"Address  : {c.Address ?? "N/A"}");
            sb.AppendLine($"Type     : {c.ContactType}");
            sb.AppendLine($"Relation : {c.RelationType}");
            sb.AppendLine($"VIP      : {(c.IsVip ? "YES" : "NO")}");

        }

        await File.WriteAllTextAsync(fileName, sb.ToString());
    }

    // INTERNAL DTO CLASS


    private class ContactDto
    {
        public int ContactId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string ContactType { get; set; }

        public string RelationType { get; set; }

        public bool IsVip { get; set; }
    }
}
