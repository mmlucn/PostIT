namespace MauiLib.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }

        public UserDTO(string firstName, string lastName, string email, string userName, string password)
        {
            Firstname = firstName;
            Lastname = lastName;
            Email = email;
            Username = userName;
            Password = password;
        }

    }
}
