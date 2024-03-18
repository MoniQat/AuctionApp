using AuctionApp.Application.Interfaces;
using AuctionApp.Core.Entities;
using AuctionApp.Core.Resources;
using AuctionApp.Infrastructure.Data;

namespace AuctionApp.Application.Services
{
    public sealed class LotService(AuctionDBContext context) : ILotService
    {
        private AuctionDBContext _dbContext = context;

        public async Task<bool> CreateLot(Item item, LotResource resource)
        {
            if (resource.auctionEnd <= DateTime.UtcNow)
            {
                throw new ArgumentException("Auction end date must be in the future.");
            }

            Lot lot = new Lot
            {
                AuctionStart = DateTime.UtcNow,
                AuctionEnd = resource.auctionEnd,
                Price = 0,
                MinStep = resource.minStep,
                BuyNowPrice = resource.buyNowPrice,
                Item = item
            };

            Bid bid = new Bid
            {
                UserId = item.OwnerId,
                Lot = lot,
                BidAmount = 0,
                BidTime = DateTime.UtcNow,
                IsLastBid = true
            };

            _dbContext.Lots.Add(lot);
            _dbContext.Bids.Add(bid);
            int result = await _dbContext.SaveChangesAsync();
            Console.WriteLine(result);
            Console.WriteLine(lot.AuctionEnd);

            return result > 0;
        }

        public async Task<Item> GetLotItem(int id)
        {
            return await _dbContext.Items.FindAsync(id);
        }
    }
}
