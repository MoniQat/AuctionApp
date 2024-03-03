using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AuctionApp.Identity
{
    public class IdentityManagmentDbContext : IdentityDbContext
    {
        /*public const string Schema = "Identity";

        public IdentityManagmentDbContext(DbContextOptions<IdentityManagmentDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema(Schema);
        }*/
    }
}
