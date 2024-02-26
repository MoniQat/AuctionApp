using AuctionApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Infrastructure.Data
{
    public class AuctionDBContext : DbContext
    {
        public AuctionDBContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Bid> Bids { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AuctionAppDB;Trusted_Connection=True;");
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuctionDbContext).Assembly); // ??

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }*/
    }
}
