namespace MauiLib.DTOs
{
    public class UserDTO
    {
        private string firstNameEntry;
        private string lastNameEntry;
        private string emailEntry;
        private string userNameEntry;
        private string passwordEntry;

        public UserDTO(string firstNameEntry, string lastNameEntry, string emailEntry, string userNameEntry, string passwordEntry)
        {
            this.firstNameEntry = firstNameEntry;
            this.lastNameEntry = lastNameEntry;
            this.emailEntry = emailEntry;
            this.userNameEntry = userNameEntry;
            this.passwordEntry = passwordEntry;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }
}
