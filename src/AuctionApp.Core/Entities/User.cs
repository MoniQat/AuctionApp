using Microsoft.AspNetCore.Identity;

namespace AuctionApp.Core.Entities
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateOnly DateOfBirth { get; set; }

        public string IdentityUserId { get; set; }
        public string PasswordSalt { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }
    }
}