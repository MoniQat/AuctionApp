using AuctionApp.Application.Interfaces;
using AuctionApp.Core.Entities;
using AuctionApp.Core.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.WebUI.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemService _itemService;
        private readonly UserManager<User> _userManager;

        public ItemsController(IItemService itemService, UserManager<User> userManager)
        {
            _itemService = itemService;
            _userManager = userManager;
        }

        public IActionResult Items()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            var userItems = _itemService.GetUserItems(user).Result;
            ViewBag.Items = userItems;
            return View();
        }

        public async Task<IActionResult> AddItem(ItemResource item)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);

                await _itemService.AddUserItem(user, item);

                return RedirectToAction("Items");
            }

            ViewBag.Categories = await _itemService.GetCategories();
            return View();
        }
    }
}
