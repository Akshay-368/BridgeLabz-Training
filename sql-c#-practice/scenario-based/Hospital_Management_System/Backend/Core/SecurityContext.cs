using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace Core
{
    internal static class SecurityContext
    {
        internal static async Task SetUserContextAsync(int userId)
        {
            using SqlCommand cmd = new SqlCommand(
                "EXEC sys.sp_set_session_context @key=N'UserId', @value=@uid"
            );

            cmd.Parameters.AddWithValue("@uid", userId);
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
