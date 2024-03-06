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

            builder.Property(x => x.MinStep).IsRequired();
            builder.Property(x => x.Price).IsRequired();

            builder.Property(x => x.MinStep).HasColumnType("decimal(18,2)");
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
            builder.Property(x => x.BuyNowPrice).HasColumnType("decimal(18,2)");
        }
    }
}
