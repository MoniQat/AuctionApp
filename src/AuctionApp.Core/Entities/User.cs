using Microsoft.AspNetCore.Identity;

namespace AuctionApp.Core.Entities
{
    public class User : IdentityUser<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string PasswordSalt { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }
    }
}