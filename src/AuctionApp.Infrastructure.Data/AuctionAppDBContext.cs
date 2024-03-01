using AuctionApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Infrastructure.Data
{
    public class AuctionDBContext : DbContext
    {
        public const string Schema = "AuctionApplication";

        public AuctionDBContext()
        {

        }
        public AuctionDBContext(DbContextOptions<AuctionDBContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Bid> Bids { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuctionDBContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
