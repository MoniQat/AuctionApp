using AuctionApp.Core.Entities;
using AuctionApp.Core.Resources;

namespace AuctionApp.Application.Interfaces
{
    public interface IItemService
    {
        Task<List<ItemResource>> GetUserItems(User user);
        Task<List<CategoryResource>> GetCategories();
        Task<bool> AddUserItem(User user, ItemResource itemResource);

    }
}
