using AuctionApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionApp.Infrastructure.Data.EntityTypeConfiguration
{
    internal class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName).IsRequired(false);
            builder.Property(x => x.LastName).IsRequired(false);
            builder.Property(x => x.PasswordSalt).IsRequired(false);

            builder.Property(x => x.FirstName).HasMaxLength(20);
            builder.Property(x => x.LastName).HasMaxLength(20);

            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.FirstName).HasColumnType("varchar(20)");
            builder.Property(x => x.LastName).HasColumnType("varchar(20)");
        }
    }
}
