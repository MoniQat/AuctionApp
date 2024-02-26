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


        }
    }
}
