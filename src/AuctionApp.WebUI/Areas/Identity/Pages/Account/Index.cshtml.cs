using AuctionApp.Application.Interfaces;
using AuctionApp.Application.Services;
using AuctionApp.Core.Entities;
using AuctionApp.Core.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuctionApp.WebUI.Areas.Identity.Pages.Account
{
    public class ProfileModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<ProfileModel> _logger;

        public UserInformationResource userInfo;

        public ProfileModel(UserManager<User> userManager, ILogger<ProfileModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            else
            {
                IUserService userService = new UserService();
                userInfo = await userService.GetInfo(user);

                return Page();
            }
        }
    }
}
