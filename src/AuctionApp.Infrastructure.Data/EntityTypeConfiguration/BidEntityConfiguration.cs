using AuctionApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionApp.Infrastructure.Data.EntityTypeConfiguration
{
    internal class BidEntityConfiguration : IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Bids)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Lot)
                .WithOne(x => x.Bid)
                .HasForeignKey<Lot>(x => x.BidId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.BidAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
        }
    }
}
