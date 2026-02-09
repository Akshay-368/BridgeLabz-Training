namespace Core
{
    public class UserSession
    {
        public int UserId { get; set; }
        public string Username { get; set; } = "";
        public string Role { get; set; } = "";
    }
}