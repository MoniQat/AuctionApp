using AuctionApp.Core.Entities;
using AuctionApp.Core.Resources;

namespace AuctionApp.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserInformationResource> GetInfo(User user);
    }
}
