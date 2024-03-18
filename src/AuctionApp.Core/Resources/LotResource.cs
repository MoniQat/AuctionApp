namespace AuctionApp.Core.Resources
{
    public sealed record LotResource(
        int id,
        DateTime auctionStart,
        DateTime auctionEnd,
        decimal minStep,
        decimal? buyNowPrice,
        int itemId
    );
}