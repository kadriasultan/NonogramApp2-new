namespace NonogramApp.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; } // Nog geen encryptie hier

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
