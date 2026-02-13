using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using Exceptions;
using Core;
using System.Data;
using Entities;

namespace Utilities;

    internal sealed class UserQueryUtility
    {
        private readonly DbConnection _db;

        public UserQueryUtility(DbConnection db)
        {
            _db = db;
        }

        // The method to call your new Stored Procedure
        internal async Task<int> RegisterPatientAsync(
            string username, byte[] hash, byte[] salt, 
            string fName, string lName, string gender, DateTime dob, 
            string contact, string email, string address , string? bloodGroup = null)
        {
            var conn = await _db.OpenAsync();
            
            using SqlCommand cmd = new SqlCommand("sp_RegisterFullPatient", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Input Parameters
            cmd.Parameters.AddWithValue("@UserName", username);
            // We convert bytes to Base64 string for storage in NVARCHAR columns
            cmd.Parameters.AddWithValue("@PasswordHash", Convert.ToBase64String(hash)); 
            cmd.Parameters.AddWithValue("@Salt", Convert.ToBase64String(salt));
            cmd.Parameters.AddWithValue("@FirstName", fName);
            cmd.Parameters.AddWithValue("@LastName", lName);
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.Parameters.AddWithValue("@DOB", dob);
            cmd.Parameters.AddWithValue("@Contact", contact);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Address", address);
            // Handle BloodGroup: if null, send DBNull.Value
            cmd.Parameters.AddWithValue("@BloodGroup", (object?)bloodGroup ?? DBNull.Value);

            // Output Parameter
            SqlParameter outputId = new SqlParameter("@NewPatientId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputId);

            await cmd.ExecuteNonQueryAsync();
            // Use 'as' or check for DBNull to prevent the "Unable to cast" crash
            if (outputId.Value == DBNull.Value)
            {
                throw new Exception("Database failed to return a New Patient ID.");
            }

            return (int)outputId.Value;
        }


        internal async Task<List<(int Id, string Name)>> GetSpecialtiesAsync()
        {
            var list = new List<(int Id, string Name)>();
            var conn = await _db.OpenAsync();
            using SqlCommand cmd = new SqlCommand("SELECT SpecialtyId, SpecialtyName FROM Specialties", conn);
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(((int)reader["SpecialtyId"], (string)reader["SpecialtyName"]));
            }
            return list;
        }

        internal async Task<int> RegisterDoctorAsync(
        string username, byte[] hash, byte[] salt,
        string fName, string lName, string gender, DateTime dob,
        string contact, string email, int specialtyId, decimal fee)
    {
        var conn = await _db.OpenAsync();
        using SqlCommand cmd = new SqlCommand("sp_RegisterFullDoctor", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        // Parameters
        cmd.Parameters.AddWithValue("@UserName", username);
        cmd.Parameters.AddWithValue("@PasswordHash", Convert.ToBase64String(hash));
        cmd.Parameters.AddWithValue("@Salt", Convert.ToBase64String(salt));
        cmd.Parameters.AddWithValue("@FirstName", fName);
        cmd.Parameters.AddWithValue("@LastName", lName);
        cmd.Parameters.AddWithValue("@Gender", gender);
        cmd.Parameters.AddWithValue("@DOB", dob);
        cmd.Parameters.AddWithValue("@Contact", contact);
        cmd.Parameters.AddWithValue("@Email", email);
        cmd.Parameters.AddWithValue("@SpecialtyId", specialtyId);
        cmd.Parameters.AddWithValue("@ConsultationFee", fee);

        SqlParameter outputId = new SqlParameter("@NewDoctorId", SqlDbType.Int) { Direction = ParameterDirection.Output };
        cmd.Parameters.Add(outputId);

        await cmd.ExecuteNonQueryAsync();
        return (int)outputId.Value;
    }



    internal async Task<int> RegisterStaffAsync(
        string username, byte[] hash, byte[] salt, string role,
        string fName, string lName, string gender, DateTime dob,
        string jobTitle, string contact, string email)
    {
        var conn = await _db.OpenAsync();
        using SqlCommand cmd = new SqlCommand("sp_RegisterStaff", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@UserName", username);
        cmd.Parameters.AddWithValue("@PasswordHash", Convert.ToBase64String(hash));
        cmd.Parameters.AddWithValue("@Salt", Convert.ToBase64String(salt));
        cmd.Parameters.AddWithValue("@UserRole", role);
        cmd.Parameters.AddWithValue("@FirstName", fName);
        cmd.Parameters.AddWithValue("@LastName", lName);
        cmd.Parameters.AddWithValue("@Gender", gender);
        cmd.Parameters.AddWithValue("@DOB", dob);
        cmd.Parameters.AddWithValue("@JobTitle", jobTitle);
        cmd.Parameters.AddWithValue("@Contact", contact);
        cmd.Parameters.AddWithValue("@Email", email);

        SqlParameter outputId = new SqlParameter("@NewStaffId", SqlDbType.Int) { Direction = ParameterDirection.Output };
        cmd.Parameters.Add(outputId);

        await cmd.ExecuteNonQueryAsync();
        return (int)outputId.Value;
    }


    internal async Task<int> RegisterAdminAsync(
        string username, byte[] hash, byte[] salt,
        string fName, string lName, string gender, DateTime dob,
        string contact, string email, string userEnteredSecret)
    {
        // 1. Fetch the ActualKey from your Configuration utility
        // Assuming you have a helper to read your Configuration.json
        string systemSecretKey = await ConfigurationUtility.GetAdminSecretKeyAsync();

        var conn = await _db.OpenAsync();
        using SqlCommand cmd = new SqlCommand("sp_RegisterRoleAdmin", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        // Parameters - Converting bytes to Base64 to match your SQL schema
        cmd.Parameters.AddWithValue("@UserName", username);
        cmd.Parameters.AddWithValue("@PasswordHash", Convert.ToBase64String(hash));
        cmd.Parameters.AddWithValue("@Salt", Convert.ToBase64String(salt));
        cmd.Parameters.AddWithValue("@FirstName", fName);
        cmd.Parameters.AddWithValue("@LastName", lName);
        cmd.Parameters.AddWithValue("@Gender", gender);
        cmd.Parameters.AddWithValue("@DOB", dob);
        cmd.Parameters.AddWithValue("@Contact", contact);
        cmd.Parameters.AddWithValue("@Email", email);
        
        // The "Gatekeeper" parameters
        cmd.Parameters.AddWithValue("@AdminSecretKey", userEnteredSecret);
        cmd.Parameters.AddWithValue("@SystemSecretKey", systemSecretKey);

        SqlParameter outputId = new SqlParameter("@NewAdminId", SqlDbType.Int) { Direction = ParameterDirection.Output };
        cmd.Parameters.Add(outputId);

        await cmd.ExecuteNonQueryAsync();
        return (int)outputId.Value;
    }



    internal async Task<UserSession?> LoginAsync(string username, string password)
    {
        var conn = await _db.OpenAsync();
        using SqlCommand cmd = new SqlCommand("sp_ValidateLogin", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UserName", username);

        using var reader = await cmd.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            var storedHash = Convert.FromBase64String(reader.GetString(1));
            var storedSalt = Convert.FromBase64String(reader.GetString(2));
            var role = reader.GetString(3);
            var userId = reader.GetInt32(0);

            if (PasswordHasher.VerifyPassword(password, storedHash, storedSalt))
            {
                return new UserSession { UserId = userId, Role = role, Username = username };
            }
        }
        return null; // Login failed
    }




    internal async Task<(int UserId, string Role, byte[] Hash, byte[] Salt)> GetLoginDataAsync(string username)
    {
        var conn = await _db.OpenAsync();
        using SqlCommand cmd = new SqlCommand("sp_ValidateLogin", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UserName", username);
        
        using SqlDataReader reader = await cmd.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            return (
                reader.GetInt32(0), // UserId
                reader.GetString(3), // UserRole
                Convert.FromBase64String(reader.GetString(1)), // PasswrdHash
                Convert.FromBase64String(reader.GetString(2)) // Salt
            );
        }
        throw new Exception("User not found.");
    }



    internal async Task<List<PatientSummary>> GetAllPatientsAsync()
    {
        var conn = await _db.OpenAsync();
        // Ensure this query is called AFTER SetSessionContextAsync in Program.cs
        using SqlCommand cmd = new SqlCommand("SELECT PatientId, FirstName, LastName, ContactNumber FROM Patients", conn);
        using var reader = await cmd.ExecuteReaderAsync();
        var list = new List<PatientSummary>();
        while (await reader.ReadAsync())
        {
            list.Add(new PatientSummary { 
                Id = reader.GetInt32(0), 
                FirstName = reader.GetString(1), 
                LastName = reader.GetString(2), 
                Contact = reader.GetString(3) 
            });
        }
        return list;
    }


    internal async Task<List<PatientSummary>> SearchPatientsByLastNameAsync(string lastName, string currentRole)
    {
        var list = new List<PatientSummary>();
        var conn = await _db.OpenAsync();

        // 1. Re-set context (Because of connection pooling)
        using (SqlCommand contextCmd = new SqlCommand("sp_set_session_context", conn))
        {
            contextCmd.CommandType = CommandType.StoredProcedure;
            contextCmd.Parameters.AddWithValue("@key", "UserRole");
            contextCmd.Parameters.AddWithValue("@value", currentRole);
            await contextCmd.ExecuteNonQueryAsync();
        }

        // 2. The Search Query - Using 'LIKE' for partial matches
        // This will use your IX_Patients_Name index for high performance
        string sql = "SELECT PatientId, FirstName, LastName, ContactNumber FROM Patients WHERE LastName LIKE @ln";
        
        using SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@ln", lastName + "%"); // Search for names starting with the input

        using var reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            list.Add(new PatientSummary { 
                Id = reader.GetInt32(0), 
                FirstName = reader.GetString(1), 
                LastName = reader.GetString(2), 
                Contact = reader.GetString(3) 
            });
        }
        return list;
    }


    // This method exists specifically to test the 'DENY' trigger
    internal async Task GetMedicalVisitsRawAsync()
    {

        var conn = await _db.OpenAsync();
        // We wrap the SELECT in an IMPERSONATION block.
        // This tells SQL: "Even though I am 'sa', execute this specific command 
        // with the limits of the 'Role_FrontDesk' database role."
        // We use 'reception_amy' because I created that user WITHOUT LOGIN in the SQL script.
        // This user is a member of 'Role_FrontDesk', which has the DENY permission.
                string query = @"
                    EXECUTE AS USER = 'reception_amy'; 
                    SELECT * FROM Visits; 
                    REVERT;";
        
        using SqlCommand cmd = new SqlCommand(query, conn);
        // MUST use ExecuteReader, otherwise 'Access Denied' errors might be suppressed and actually try to read a row to trigger the security exception
        using var reader = await cmd.ExecuteReaderAsync();
        while(await reader.ReadAsync()) { /* just reading to trigger the error */ }
    }




    internal async Task SetSessionContextAsync(int userId , string role)
    {
        var conn = await _db.OpenAsync();
        using (SqlCommand cmd = new SqlCommand("sp_set_session_context", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@key", "UserId");
                    cmd.Parameters.AddWithValue("@value", userId);
                    await cmd.ExecuteNonQueryAsync();
                }

        // Set UserRole (Reuse the command, clear parameters)
        using (SqlCommand cmd = new SqlCommand("sp_set_session_context", conn)){ 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@key", "UserRole");
                cmd.Parameters.AddWithValue("@value", role);
                await cmd.ExecuteNonQueryAsync();
        }
    }


    internal async Task<(byte[] Hash, byte[] Salt, int UserId)> 
            GetUserCredentialsAsync(string username, int roleId)
        {
            SqlCommand cmd = new SqlCommand(
                "sp_GetUserLoginCredentials",   // NAME OF EXISTING SP
                _db.GetConnection()
            );

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@RoleId", roleId);

            await _db.GetConnection().OpenAsync();

            using var reader = await cmd.ExecuteReaderAsync();
            if (!await reader.ReadAsync())
                throw new InvalidCredentialsException();

            return (
                (byte[])reader["UserPasswordHash"],
                (byte[])reader["Salt"],
                (int)reader["UserId"]
            );

        }
    

    //  STAFF SALARY/COST DIRECTORY (Manager View)
    // Since I want everything that touches money here, 
    // I include the staff directory for payroll/management oversight.
    internal async Task<List<StaffSummary>> GetAllStaffAsync()
    {
        var list = new List<StaffSummary>();
        var conn = await _db.OpenAsync();
        
        string sql = @"
            SELECT s.StaffId, s.FirstName, s.LastName, u.UserRole, s.ContactNumber 
            FROM Staff s
            JOIN Users u ON s.UserId = u.UserId
            WHERE u.UserRole != 'Patient'
            ORDER BY u.UserRole, s.LastName";

        using var cmd = new SqlCommand(sql, conn);
        using var reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            list.Add(new StaffSummary
            {
                Id = reader.GetInt32(0),
                FirstName = reader.GetString(1),
                LastName = reader.GetString(2),
                Role = reader.GetString(3),
                Contact = reader.GetString(4)
            });
        }
        return list;
    }
    
}
