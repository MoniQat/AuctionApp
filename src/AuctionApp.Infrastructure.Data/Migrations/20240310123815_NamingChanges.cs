using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class NamingChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BidStart",
                schema: "AuctionApplication",
                table: "Lots",
                newName: "AuctionStart");

            migrationBuilder.RenameColumn(
                name: "BidEnd",
                schema: "AuctionApplication",
                table: "Lots",
                newName: "AuctionEnd");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AuctionStart",
                schema: "AuctionApplication",
                table: "Lots",
                newName: "BidStart");

            migrationBuilder.RenameColumn(
                name: "AuctionEnd",
                schema: "AuctionApplication",
                table: "Lots",
                newName: "BidEnd");
        }
    }
}
