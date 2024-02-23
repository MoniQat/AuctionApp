namespace AuctionApp.Core
{
    public class User
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string second_name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email_address { get; set; }
        public DateOnly date_of_birth { get; set; }
    }

    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public int category_id { get; set; }
        public string description { get; set; }

        public Category category { get; set; }

    }

    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Item> items { get; set; }
    }

    public class Lot
    {
        public int id { get; set; }
        public DateTime bid_start { get; set; }
        public DateTime bid_end { get; set; }
        public decimal price { get; set; }
        public decimal min_step { get; set; }
        public decimal buy_now_price { get; set; }
        public Item item { get; set; }
    }

    public class Bid
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int lot_id { get; set; }
        public DateTime bid_time { get; set; }

        // public bool is_winner??

        public User user { get; set; }
        public Lot lot { get; set; }
    }
}
