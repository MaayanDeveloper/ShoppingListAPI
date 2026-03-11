using ShoppingListAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListAPI.Core.Services
{
    public interface IShopListService
    {
        public Task<List<ShopList>> GetAllListsAsync();
        public Task<ShopList> GetShopListByIdAsync(int id);
        public Task<ShopList> GetListByTitleAsync(string title);
        public Task<ShopList> AddShopListAsync(ShopList shopList);
        public Task<ShopList> UpdateShopListAsync(int id, ShopList shopList);
        public Task DeleteShopListAsync(int id);
    }
}
