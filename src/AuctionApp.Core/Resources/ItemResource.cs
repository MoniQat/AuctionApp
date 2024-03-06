namespace AuctionApp.Core.Resources
{
    public sealed record ItemResource(
        string name,
        string description,
        string categoryName
    );
}
