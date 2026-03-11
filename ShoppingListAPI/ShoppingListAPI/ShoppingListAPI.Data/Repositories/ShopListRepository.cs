using Microsoft.EntityFrameworkCore;
using ShoppingListAPI.Core.Models;
using ShoppingListAPI.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListAPI.Data.Repositories
{
    public class ShopListRepository : IShopListRepository
    {
        private readonly DataContext _context;
        public ShopListRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ShopList>> GetAllListsAsync()
        {
            return await _context.ShopList.ToListAsync();
        }

        public async  Task<ShopList> GetShopListByIdAsync(int id)
        {
            return await _context.ShopList
            .Include(p => p.ListProductsInLIst)
            .FirstOrDefaultAsync(p => p.Key == id);
        }

        public async Task<ShopList> GetListByTitleAsync(string title)
        {
            return await _context.ShopList.FirstOrDefaultAsync(p => p.Title == title);
        }

        public async Task<ShopList> AddShopListAsync(ShopList shopList)
        {
            _context.ShopList.Add(shopList);
            await SaveAsync();
            return shopList;
        }

        public async Task<ShopList> UpdateShopListAsync(int id, ShopList shopList)
        {
            var s= await GetShopListByIdAsync(id);
            if (s == null)
            {
                return null;
            }
            s.Title = shopList.Title;
            if (shopList.ListProductsInLIst != null)
            {
                _context.ProductIns.RemoveRange(s.ListProductsInLIst);
                s.ListProductsInLIst = shopList.ListProductsInLIst;
            }
            await SaveAsync();
            return s;
        }

        public async Task DeleteShopListAsync(int id)
        {
            var s = await GetShopListByIdAsync(id);
            _context.ShopList.Remove(s);
            await SaveAsync();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
