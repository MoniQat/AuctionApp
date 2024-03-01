using AuctionApp.Core.Resources;

namespace AuctionApp.Application.Services
{
    public interface IUserService
    {
        Task<UserResource> Register(RegisterResource resource); //CancellationToken cancellationToken
        Task<UserResource> Login(LoginResource resource); //CancellationToken cancellationToken
    }
}
