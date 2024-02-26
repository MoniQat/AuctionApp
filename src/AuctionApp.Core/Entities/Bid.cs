namespace AuctionApp.Core.Entities
{
    public class Bid
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int LotId { get; set; }
        public decimal BidAmount { get; set; }
        public DateTime BidTime { get; set; }

        // public bool is_the_biggest_bid??

        public virtual User User { get; set; }
        public virtual Lot Lot { get; set; }
    }
}
