using AuctionApp.Core.Entities;
using AuctionApp.Core.Resources;

namespace AuctionApp.Application.Interfaces
{
    public interface ILotService
    {
        Task<bool> CreateLot(Item item, LotResource resource);
        Task<Item> GetLotItem(int id);
    }
}
