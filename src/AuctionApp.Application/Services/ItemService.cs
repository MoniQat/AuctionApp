using AuctionApp.Application.Interfaces;
using AuctionApp.Core.Entities;
using AuctionApp.Core.Resources;
using AuctionApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Application.Services
{
    public sealed class ItemService(AuctionDBContext context) : IItemService
    {

        private AuctionDBContext _dbContext = context;
        public async Task<List<ItemResource>> GetUserItems(User user)
        {

            IQueryable<Item> query = _dbContext.Items.Where(x => x.OwnerId == user.Id).AsQueryable();
            List<ItemResource> items = query.Select(x => new ItemResource(
                x.Name,
                x.Description,
                x.Category.Name
                )).ToList();

            return items;
        }
        public async Task<List<CategoryResource>> GetCategories()
        {
            IQueryable<Category> query = _dbContext.Categories.AsQueryable();
            List<CategoryResource> categories = await query.Select(x => new CategoryResource(
                x.Id,
                x.Name
                )).ToListAsync();

            return categories;
        }

        public async Task<bool> AddUserItem(User user, ItemResource itemResource)
        {
            Item item = new Item()
            {
                Name = itemResource.name,
                Description = itemResource.description,
                Category = _dbContext.Categories
                                .Where(x => x.Name == itemResource.categoryName)
                                .FirstOrDefault(),

                CategoryId = _dbContext.Categories
                                .Where(x => x.Name == itemResource.categoryName)
                                .FirstOrDefault().Id,
                Owner = user,
                OwnerId = user.Id,
            };

            _dbContext.Items.Add(item);
            int result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }



    }
}
