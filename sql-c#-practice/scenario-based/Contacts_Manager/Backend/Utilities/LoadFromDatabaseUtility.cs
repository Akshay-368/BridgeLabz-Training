namespace Utilities;

using System;
using System.Threading.Tasks;
using Core;
using Microsoft.Data.SqlClient;

internal class LoadFromDatabase
{
    // =============================================
    // MAIN METHOD
    // =============================================

    internal async Task LoadAsync()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("===========================================");
        Console.WriteLine("     CONTACT BROWSER (PAGINATION MODE)   ");
        Console.WriteLine("===========================================");
        Console.ResetColor();

        Console.WriteLine();
        Console.WriteLine("Controls:");
        Console.WriteLine(" n → Next Contact");
        Console.WriteLine(" u → Previous Contact");
        Console.WriteLine(" q → Quit");
        Console.WriteLine();

        int currentIndex = 0;
        bool exit = false;

        while (!exit)
        {
            try
            {
                ContactCache contact =
                    await LoadSingleContactAsync(currentIndex);

                if (contact == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n⚠ No record found!");
                    Console.ResetColor();

                    if (currentIndex > 0)
                    {
                        currentIndex--;
                    }
                }
                else
                {
                    DisplayContact(contact);
                }

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\nCommand (n/u/q): ");
                Console.ResetColor();

                string input = Console.ReadLine()?.ToLower();

                switch (input)
                {
                    case "n":
                        currentIndex++;
                        break;

                    case "u":

                        if (currentIndex > 0)
                        {
                            currentIndex--;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n Already at first record.");
                            Console.ResetColor();
                        }

                        break;

                    case "q":
                        exit = true;
                        break;

                    default:

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n Invalid Command.");
                        Console.ResetColor();

                        break;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nSystem Error ");
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nExited Contact Browser ");
        Console.ResetColor();
    }


    // =============================================
    // LOAD SINGLE CONTACT
    // =============================================

    private async Task<ContactCache> LoadSingleContactAsync(int index)
    {
        using DbConnection db = new DbConnection();

        SqlConnection connection = await db.OpenAsync();

        string query =
        @"
        SELECT *
        FROM Contacts
        ORDER BY ContactId
        OFFSET @Offset ROWS
        FETCH NEXT 1 ROWS ONLY
        ";

        using SqlCommand cmd = new SqlCommand(query, connection);

        cmd.Parameters.AddWithValue("@Offset", index);

        using SqlDataReader reader =
            await cmd.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            ContactCache contact = new ContactCache();

            contact.ContactId =
                Convert.ToInt32(reader["ContactId"]);

            contact.FirstName =
                reader["FirstName"].ToString();

            contact.LastName =
                reader["LastName"].ToString();

            contact.PhoneNumber =
                reader["PhoneNumber"].ToString();

            contact.Email =
                reader["Email"]?.ToString();

            contact.Address =
                reader["Address"]?.ToString();

            contact.ContactType =
                reader["ContactType"].ToString();

            contact.RelationType =
                reader["RelationType"].ToString();

            contact.CustomRelation =
                reader["CustomRelation"]?.ToString();

            contact.IsVip =
                Convert.ToBoolean(reader["IsVip"]);

            contact.CreatedDate =
                Convert.ToDateTime(reader["CreatedDate"]);

            contact.UpdatedDate =
                Convert.ToDateTime(reader["UpdatedDate"]);

            return contact;
        }

        return null;
    }


    // =============================================
    // DISPLAY CONTACT
    // =============================================

    private void DisplayContact(ContactCache c)
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("=====================================");
        Console.WriteLine($" Contact ID : {c.ContactId}");
        Console.WriteLine("=====================================");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine($" Name        : {c.FirstName} {c.LastName}");
        Console.WriteLine($" Phone       : {c.PhoneNumber}");
        Console.WriteLine($" Email       : {c.Email}");
        Console.WriteLine($" Address     : {c.Address}");
        Console.WriteLine($" Type        : {c.ContactType}");
        Console.WriteLine($" Relation    : {c.RelationType}");
        Console.WriteLine($" Custom Rel. : {c.CustomRelation}");
        Console.WriteLine($" VIP         : {c.IsVip}");
        Console.WriteLine($" Created     : {c.CreatedDate}");
        Console.WriteLine($" Updated     : {c.UpdatedDate}");

        Console.ResetColor();
    }


    // =============================================
    // INTERNAL CACHE DTO
    // =============================================

    private class ContactCache
    {
        public int ContactId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string ContactType { get; set; }

        public string RelationType { get; set; }

        public string CustomRelation { get; set; }

        public bool IsVip { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
