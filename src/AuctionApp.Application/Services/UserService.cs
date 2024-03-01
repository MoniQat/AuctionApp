using AuctionApp.Core.Entities;
using AuctionApp.Core.Resources;
using AuctionApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Application.Services
{
    public sealed class UserService : IUserService
    {
        private readonly AuctionDBContext _context;
        //private readonly string _pepper;
        private readonly int _iteration = 3;

        public UserService(AuctionDBContext context)
        {
            _context = context;
            //_pepper = Environment.GetEnvironmentVariable("???");
        }

        public async Task<UserResource> Register(RegisterResource resource) // , CancellationToken cancellationToken)
        {
            var user = new User
            {
                UserName = resource.Username,
                Email = resource.EmailAddress,
                PasswordSalt = PasswordHasher.GenerateSalt()
            };
            user.PasswordHash = PasswordHasher.ComputeHash(resource.Password, user.PasswordSalt, _iteration); // _pepper,
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return new UserResource(user.Id, user.UserName);
        }

        public async Task<UserResource> Login(LoginResource resource) // , CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.UserName == resource.Username);

            if (user == null)
                throw new Exception("Username or password did not match.");

            var passwordHash = PasswordHasher.ComputeHash(resource.Password, user.PasswordSalt, _iteration);  // _pepper,

            if (user.PasswordHash != passwordHash)
                throw new Exception("Username or password did not match.");

            return new UserResource(user.Id, user.UserName);
        }
    }
}
