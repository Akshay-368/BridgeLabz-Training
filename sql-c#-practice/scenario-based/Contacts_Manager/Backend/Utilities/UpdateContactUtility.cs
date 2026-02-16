using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Core;

namespace Utilities
{
    internal class UpdateContact
    {
        public async Task UpdateContactAsync()
        {
            // ================= TITLE =================
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n===== UPDATE CONTACT =====");
            Console.ResetColor();


            // ================= ASK ID =================
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter Contact ID to Update: ");
            Console.ResetColor();

            string idInput = Console.ReadLine();


            // ================= VALIDATE ID =================
            if (!int.TryParse(idInput, out int contactId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid ID! Must be a number.");
                Console.ResetColor();
                Pause();
                return;
            }


            // ================= ASK NEW VALUES =================
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nLeave blank to keep old value.");
            Console.ResetColor();

            Console.Write("New First Name: ");
            string newFirstName = Console.ReadLine();

            Console.Write("New Last Name: ");
            string newLastName = Console.ReadLine();

            Console.Write("New Phone Number: ");
            string newPhone = Console.ReadLine();

            Console.Write("New Email: ");
            string newEmail = Console.ReadLine();

            Console.Write("New Address: ");
            string newAddress = Console.ReadLine();


            // ================= OPEN DB =================
            using DbConnection db = new DbConnection();
            SqlConnection connection = await db.OpenAsync();

            try
            {
                // ================= CHECK EXISTS =================
                string checkQuery =
                    "SELECT COUNT(*) FROM Contacts WHERE ContactId = @Id";

                using SqlCommand checkCmd =
                    new SqlCommand(checkQuery, connection);

                checkCmd.Parameters.AddWithValue("@Id", contactId);

                int count =
                    Convert.ToInt32(await checkCmd.ExecuteScalarAsync());

                if (count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nContact not found!");
                    Console.ResetColor();
                    Pause();
                    return;
                }


                // ================= BUILD UPDATE QUERY =================
                string updateQuery = "UPDATE Contacts SET ";

                bool first = true;


                if (!string.IsNullOrWhiteSpace(newFirstName))
                {
                    updateQuery += "FirstName = @FirstName";
                    first = false;
                }

                if (!string.IsNullOrWhiteSpace(newLastName))
                {
                    if (!first) updateQuery += ", ";
                    updateQuery += "LastName = @LastName";
                    first = false;
                }

                if (!string.IsNullOrWhiteSpace(newPhone))
                {
                    if (!first) updateQuery += ", ";
                    updateQuery += "PhoneNumber = @Phone";
                    first = false;
                }

                if (!string.IsNullOrWhiteSpace(newEmail))
                {
                    if (!first) updateQuery += ", ";
                    updateQuery += "Email = @Email";
                    first = false;
                }

                if (!string.IsNullOrWhiteSpace(newAddress))
                {
                    if (!first) updateQuery += ", ";
                    updateQuery += "Address = @Address";
                    first = false;
                }


                // Always update timestamp
                if (!first) updateQuery += ", ";
                updateQuery += "UpdatedDate = SYSDATETIME()";


                updateQuery += " WHERE ContactId = @Id";


                // ================= NOTHING TO UPDATE =================
                if (first)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nNo fields entered. Nothing updated.");
                    Console.ResetColor();
                    Pause();
                    return;
                }


                // ================= CREATE COMMAND =================
                using SqlCommand updateCmd =
                    new SqlCommand(updateQuery, connection);

                updateCmd.Parameters.AddWithValue("@Id", contactId);

                if (!string.IsNullOrWhiteSpace(newFirstName))
                    updateCmd.Parameters.AddWithValue("@FirstName", newFirstName);

                if (!string.IsNullOrWhiteSpace(newLastName))
                    updateCmd.Parameters.AddWithValue("@LastName", newLastName);

                if (!string.IsNullOrWhiteSpace(newPhone))
                    updateCmd.Parameters.AddWithValue("@Phone", newPhone);

                if (!string.IsNullOrWhiteSpace(newEmail))
                    updateCmd.Parameters.AddWithValue("@Email", newEmail);

                if (!string.IsNullOrWhiteSpace(newAddress))
                    updateCmd.Parameters.AddWithValue("@Address", newAddress);


                // ================= EXECUTE =================
                int rows =
                    await updateCmd.ExecuteNonQueryAsync();


                // ================= RESULT =================
                if (rows > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nContact Updated Successfully!");
                    Console.WriteLine("Rows Affected: " + rows);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nUpdate Failed!");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                // ================= ERROR =================
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nERROR:");
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            finally
            {
                // ================= CLOSE =================
                if (connection.State == ConnectionState.Open)
                {
                    await connection.CloseAsync();
                }

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\nDatabase Connection Closed.");
                Console.ResetColor();
            }

            // ================= PAUSE =================
            Pause();
        }


        // ================= HELPER =================
        private void Pause()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Press any key to return to menu...");
            Console.ResetColor();
            Console.ReadKey(true);
        }
    }
}
