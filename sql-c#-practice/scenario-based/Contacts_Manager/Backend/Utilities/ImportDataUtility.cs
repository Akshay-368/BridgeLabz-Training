namespace Utilities;

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Core;
using Microsoft.Data.SqlClient;

internal class ImportData
{
    internal async Task ImportDataAsync()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine("-----------------------------------");
        Console.WriteLine("         IMPORT CONTACTS           ");
        Console.WriteLine("-----------------------------------");

        Console.ResetColor();

        Console.WriteLine("Select Import Format:");
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

        Console.Write("\nEnter file path: ");
        string path = Console.ReadLine();

        if (!File.Exists(path))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("File not found.");
            Console.ResetColor();
            return;
        }

        try
        {
            List<ContactDto> contacts = format switch
            {
                "json" => await ImportJsonAsync(path),
                "csv"  => await ImportCsvAsync(path),
                "txt"  => await ImportTxtAsync(path),
                _ => new List<ContactDto>()
            };

            if (contacts.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No valid contacts found.");
                Console.ResetColor();
                return;
            }

            int inserted = await InsertContactsAsync(contacts);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("\nImport Completed!");
            Console.WriteLine($"Inserted: {inserted} contacts");

            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Import Failed:");
            Console.WriteLine(ex.Message);

            Console.ResetColor();
        }
    }

    // ================= IMPORT JSON =================


    private async Task<List<ContactDto>> ImportJsonAsync(string path)
    {
        string json = await File.ReadAllTextAsync(path);

        List<ContactDto> list =
            JsonSerializer.Deserialize<List<ContactDto>>(json);

        return list ?? new List<ContactDto>();
    }


    // ================= IMPORT CSV =================


    private async Task<List<ContactDto>> ImportCsvAsync(string path)
    {
        List<ContactDto> list = new List<ContactDto>();

        string[] lines = await File.ReadAllLinesAsync(path);

        for (int i = 1; i < lines.Length; i++) // Skip header
        {
            string[] parts = lines[i].Split(',');

            if (parts.Length < 9)
                continue;

            ContactDto contact = new ContactDto
            {
                FirstName = parts[1],
                LastName = parts[2],
                PhoneNumber = parts[3],
                Email = parts[4],
                Address = parts[5],
                ContactType = parts[6],
                RelationType = parts[7],
                IsVip = bool.Parse(parts[8])
            };

            list.Add(contact);
        }

        return list;
    }


    // ================= IMPORT TXT =================


    private async Task<List<ContactDto>> ImportTxtAsync(string path)
    {
        List<ContactDto> list = new List<ContactDto>();

        string[] lines = await File.ReadAllLinesAsync(path);

        ContactDto contact = null;

        foreach (string line in lines)
        {
            if (line.StartsWith("ID"))
            {
                contact = new ContactDto();
            }
            else if (line.StartsWith("Name"))
            {
                string[] parts = line.Split(':')[1].Trim().Split(' ');

                contact.FirstName = parts[0];
                contact.LastName = parts.Length > 1 ? parts[1] : "";
            }
            else if (line.StartsWith("Phone"))
            {
                contact.PhoneNumber = line.Split(':')[1].Trim();
            }
            else if (line.StartsWith("Email"))
            {
                contact.Email = line.Split(':')[1].Trim();
            }
            else if (line.StartsWith("Address"))
            {
                contact.Address = line.Split(':')[1].Trim();
            }
            else if (line.StartsWith("Type"))
            {
                contact.ContactType = line.Split(':')[1].Trim();
            }
            else if (line.StartsWith("Relation"))
            {
                contact.RelationType = line.Split(':')[1].Trim();
            }
            else if (line.StartsWith("VIP"))
            {
                contact.IsVip =
                    line.Contains("YES");

                list.Add(contact);
            }
        }

        return list;
    }


    // ================= INSERT INTO DB =================


    private async Task<int> InsertContactsAsync(List<ContactDto> contacts)
    {
        int count = 0;

        using DbConnection db = new DbConnection();

        SqlConnection connection = await db.OpenAsync();

        using SqlTransaction transaction =
            connection.BeginTransaction();

        try
        {
            foreach (var c in contacts)
            {
                if (await PhoneExistsAsync(c.PhoneNumber, connection, transaction))
                    continue;

                using SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO Contacts
                    (
                        FirstName,
                        LastName,
                        PhoneNumber,
                        Email,
                        Address,
                        ContactType,
                        RelationType,
                        IsVip
                    )
                    VALUES
                    (
                        @First,
                        @Last,
                        @Phone,
                        @Email,
                        @Address,
                        @Type,
                        @Relation,
                        @Vip
                    )",
                    connection,
                    transaction);

                cmd.Parameters.AddWithValue("@First", c.FirstName);
                cmd.Parameters.AddWithValue("@Last", c.LastName);
                cmd.Parameters.AddWithValue("@Phone", c.PhoneNumber);

                cmd.Parameters.AddWithValue("@Email",
                    string.IsNullOrWhiteSpace(c.Email)
                        ? DBNull.Value
                        : c.Email);

                cmd.Parameters.AddWithValue("@Address",
                    string.IsNullOrWhiteSpace(c.Address)
                        ? DBNull.Value
                        : c.Address);

                cmd.Parameters.AddWithValue("@Type",
                    string.IsNullOrWhiteSpace(c.ContactType)
                        ? "Personal"
                        : c.ContactType);

                cmd.Parameters.AddWithValue("@Relation",
                    string.IsNullOrWhiteSpace(c.RelationType)
                        ? "Other"
                        : c.RelationType);

                cmd.Parameters.AddWithValue("@Vip", c.IsVip);

                int rows = await cmd.ExecuteNonQueryAsync();

                if (rows > 0)
                    count++;
            }

            transaction.Commit();

            return count;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }


    // ================= DUPLICATE CHECK =================


    private async Task<bool> PhoneExistsAsync(
        string phone,
        SqlConnection conn,
        SqlTransaction tx)
    {
        using SqlCommand cmd = new SqlCommand(@"
            SELECT COUNT(*)
            FROM Contacts
            WHERE PhoneNumber = @Phone",
            conn,
            tx);

        cmd.Parameters.AddWithValue("@Phone", phone);

        int count = Convert.ToInt32(
            await cmd.ExecuteScalarAsync());

        return count > 0;
    }


    // ================= DTO =================


    private class ContactDto
    {
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
