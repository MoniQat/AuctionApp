using AuctionApp.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Infrastructure.Data
{
    public class AuctionDBContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public const string Schema = "AuctionApplication";

        public AuctionDBContext()
        {

        }
        public AuctionDBContext(DbContextOptions<AuctionDBContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Bid> Bids { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(Schema);

            builder.ApplyConfigurationsFromAssembly(typeof(AuctionDBContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
