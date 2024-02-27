using AuctionApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionApp.Infrastructure.Data.EntityTypeConfiguration
{
    internal class LotEntityConfiguration : IEntityTypeConfiguration<Lot>
    {
        public void Configure(EntityTypeBuilder<Lot> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MinStep)
                .IsRequired()
                .HasColumnType("decimal(18,2)");  // should I define columnType for every property ?

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.BuyNowPrice)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Bid)
                .WithOne(x => x.Lot)
                .HasForeignKey<Lot>(x => x.BidId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
