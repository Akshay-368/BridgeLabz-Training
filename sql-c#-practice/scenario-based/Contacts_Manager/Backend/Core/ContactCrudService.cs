using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Core;

public class ContactCrudService
{
    // ================= GET ALL =================

    public async Task<List<object>> GetAllAsync()
    {
        List<object> contacts = new List<object>();

        using DbConnection db = new DbConnection();
        SqlConnection connection = await db.OpenAsync();

        string query = @"SELECT 
                            ContactId,
                            FirstName,
                            LastName,
                            PhoneNumber,
                            Email,
                            Address,
                            ContactType,
                            DateOfBirth,
                            RelationType,
                            IsVip
                         FROM Contacts
                         ORDER BY FirstName, LastName";

        using SqlCommand command = new SqlCommand(query, connection);
        using SqlDataReader reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            contacts.Add(new
            {
                ContactId = reader["ContactId"],
                FirstName = reader["FirstName"],
                LastName = reader["LastName"],
                PhoneNumber = reader["PhoneNumber"],
                Email = reader["Email"],
                Address = reader["Address"],
                ContactType = reader["ContactType"],
                DateOfBirth = reader["DateOfBirth"],
                RelationType = reader["RelationType"],
                IsVip = reader["IsVip"]
            });
        }

        return contacts;
    }

    // ================= ADD =================

    public async Task<bool> AddAsync(
        string firstName,
        string lastName,
        string phone,
        string email,
        string address,
        string contactType,
        DateTime? dob,
        string relationType,
        string customRelation,
        bool isVip)
    {
        using DbConnection db = new DbConnection();
        SqlConnection conn = await db.OpenAsync();

        using SqlCommand cmd = new SqlCommand(@"
            INSERT INTO Contacts
            (
                FirstName,
                LastName,
                PhoneNumber,
                Email,
                Address,
                ContactType,
                DateOfBirth,
                RelationType,
                CustomRelation,
                IsVip
            )
            VALUES
            (
                @FirstName,
                @LastName,
                @Phone,
                @Email,
                @Address,
                @Type,
                @DOB,
                @Relation,
                @Custom,
                @Vip
            )", conn);

        cmd.Parameters.AddWithValue("@FirstName", firstName);
        cmd.Parameters.AddWithValue("@LastName", lastName);
        cmd.Parameters.AddWithValue("@Phone", phone);
        cmd.Parameters.AddWithValue("@Email", (object?)email ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Address", (object?)address ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Type", contactType);
        cmd.Parameters.AddWithValue("@DOB", dob ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@Relation", relationType);
        cmd.Parameters.AddWithValue("@Custom", (object?)customRelation ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Vip", isVip);

        int rows = await cmd.ExecuteNonQueryAsync();
        return rows > 0;
    }

    // ================= DELETE =================

    public async Task<bool> DeleteAsync(string phone)
    {
        using DbConnection db = new DbConnection();
        SqlConnection conn = await db.OpenAsync();

        using SqlCommand cmd = new SqlCommand(@"
            DELETE FROM Contacts
            WHERE PhoneNumber = @Phone
        ", conn);

        cmd.Parameters.AddWithValue("@Phone", phone);

        int rows = await cmd.ExecuteNonQueryAsync();
        return rows > 0;
    }

    // ================= UPDATE =================

    public async Task<bool> UpdateAsync(
        int contactId,
        string? firstName,
        string? lastName,
        string? phone,
        string? email,
        string? address)
    {
        using DbConnection db = new DbConnection();
        SqlConnection connection = await db.OpenAsync();

        string updateQuery = "UPDATE Contacts SET ";
        bool first = true;

        if (!string.IsNullOrWhiteSpace(firstName))
        {
            updateQuery += "FirstName = @FirstName";
            first = false;
        }

        if (!string.IsNullOrWhiteSpace(lastName))
        {
            if (!first) updateQuery += ", ";
            updateQuery += "LastName = @LastName";
            first = false;
        }

        if (!string.IsNullOrWhiteSpace(phone))
        {
            if (!first) updateQuery += ", ";
            updateQuery += "PhoneNumber = @Phone";
            first = false;
        }

        if (!string.IsNullOrWhiteSpace(email))
        {
            if (!first) updateQuery += ", ";
            updateQuery += "Email = @Email";
            first = false;
        }

        if (!string.IsNullOrWhiteSpace(address))
        {
            if (!first) updateQuery += ", ";
            updateQuery += "Address = @Address";
            first = false;
        }

        if (first)
            return false;

        updateQuery += ", UpdatedDate = SYSDATETIME()";
        updateQuery += " WHERE ContactId = @Id";

        using SqlCommand cmd = new SqlCommand(updateQuery, connection);

        cmd.Parameters.AddWithValue("@Id", contactId);

        if (!string.IsNullOrWhiteSpace(firstName))
            cmd.Parameters.AddWithValue("@FirstName", firstName);

        if (!string.IsNullOrWhiteSpace(lastName))
            cmd.Parameters.AddWithValue("@LastName", lastName);

        if (!string.IsNullOrWhiteSpace(phone))
            cmd.Parameters.AddWithValue("@Phone", phone);

        if (!string.IsNullOrWhiteSpace(email))
            cmd.Parameters.AddWithValue("@Email", email);

        if (!string.IsNullOrWhiteSpace(address))
            cmd.Parameters.AddWithValue("@Address", address);

        int rows = await cmd.ExecuteNonQueryAsync();
        return rows > 0;
    }
}
