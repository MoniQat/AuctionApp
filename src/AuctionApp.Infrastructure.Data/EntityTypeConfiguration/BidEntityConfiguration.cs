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

            builder.Property(x => x.BidAmount).IsRequired();
            builder.Property(x => x.BidTime).IsRequired();
            builder.Property(x => x.IsLastBid).IsRequired();

            builder.Property(x => x.BidAmount).HasColumnType("decimal(18, 2)");
            builder.Property(x => x.BidTime).HasColumnType("smalldatetime");
            builder.Property(x => x.IsLastBid).HasColumnType("bit");

            builder.HasOne(x => x.User)
                .WithMany(x => x.Bids)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Lot)
                .WithOne(x => x.Bid)
                .HasForeignKey<Lot>(x => x.BidId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
