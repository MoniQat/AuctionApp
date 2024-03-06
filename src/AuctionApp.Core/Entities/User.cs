using Microsoft.AspNetCore.Identity;

namespace AuctionApp.Core.Entities
{
    public class User : IdentityUser<int>
    {
        public override int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly DateOfBirth { get; set; } = default(DateOnly);
        public string? PasswordSalt { get; set; }
        public byte[]? ProfileImage { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }
    }
}