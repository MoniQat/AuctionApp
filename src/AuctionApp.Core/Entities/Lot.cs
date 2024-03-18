namespace AuctionApp.Core.Entities
{
    public class Lot
    {
        public int Id { get; set; }
        public DateTime AuctionStart { get; set; }
        public DateTime AuctionEnd { get; set; }
        public decimal Price { get; set; }
        public decimal MinStep { get; set; }
        public decimal? BuyNowPrice { get; set; }
        public int BidId { get; set; }
        public virtual Item Item { get; set; }
        public virtual Bid Bid { get; set; }
    }
}
