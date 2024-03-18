using AuctionApp.Application.Interfaces;
using AuctionApp.Core.Entities;
using AuctionApp.Core.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.WebUI.Controllers
{
    public class LotController : Controller
    {
        private readonly ILotService _lotService;
        private readonly UserManager<User> _userManager;

        public LotController(ILotService lotService, UserManager<User> userManager)
        {
            _lotService = lotService;
            _userManager = userManager;
        }

        public async Task<IActionResult> AddLot(LotResource lot)
        {
            if (ModelState.IsValid)
            {
                if (lot.auctionEnd <= DateTime.UtcNow)
                {
                    ModelState.AddModelError("auctionEnd", "Auction end date must be in the future.");
                    return View(lot);
                }

                var item = await _lotService.GetLotItem(lot.itemId);

                await _lotService.CreateLot(item, lot);

                return RedirectToAction("LotDetails", new { item });
            }

            return View();
        }

        public IActionResult LotDetails(Item item)
        {
            ViewBag.item = item;
            return View();
        }

    }
}
