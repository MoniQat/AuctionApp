namespace AuctionApp.Core.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public int OwnerId { get; set; }
        public string Description { get; set; }

        public virtual Category? Category { get; set; }
        public virtual User Owner { get; set; }

    }
}
