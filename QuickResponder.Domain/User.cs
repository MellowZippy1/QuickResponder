namespace QuickResponder.Domain
{
    public class User
    {
        public Guid ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Genders Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
