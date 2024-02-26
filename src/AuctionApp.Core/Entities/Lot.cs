namespace AuctionApp.Core.Entities
{
    public class Lot
    {
        public int Id { get; set; }
        public DateTime BidStart { get; set; }
        public DateTime BidEnd { get; set; }
        public decimal Price { get; set; }
        public decimal MinStep { get; set; }
        public decimal BuyNowPrice { get; set; }
        public virtual Item Item { get; set; }
    }
}
