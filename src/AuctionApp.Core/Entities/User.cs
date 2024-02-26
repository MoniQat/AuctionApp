namespace AuctionApp.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // do it as hash
        public string EmailAddress { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
