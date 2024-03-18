namespace AuctionApp.Core.Resources
{
    public sealed record ItemResource(
        int id,
        string name,
        string description,
        string categoryName,
        LotStatus lotStatus
    );

    public enum LotStatus
    {
        OnAuction,
        Sold,
        Unauctioned
    }
}
