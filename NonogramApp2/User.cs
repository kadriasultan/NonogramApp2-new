namespace NonogramApp.Models
{
    public class User
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        // Constructor
        public User(string username, string passwordHash)
        {
            Username = username;
            PasswordHash = passwordHash;
        }
    }
}
