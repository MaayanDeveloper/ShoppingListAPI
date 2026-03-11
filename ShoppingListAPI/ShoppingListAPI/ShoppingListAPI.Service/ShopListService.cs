using ShoppingListAPI.Core.Models;
using ShoppingListAPI.Core.Repositories;
using ShoppingListAPI.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListAPI.Service
{
    public class ShopListService :IShopListService
    {
        private readonly IShopListRepository _shopListRepository;
        public ShopListService(IShopListRepository shopListRepository)
        {
            _shopListRepository = shopListRepository;
        }
        public async Task<List<ShopList>> GetAllListsAsync()
        {
           return await _shopListRepository.GetAllListsAsync();
        }
        public async Task<ShopList> GetShopListByIdAsync(int id)
        {
            return await _shopListRepository.GetShopListByIdAsync(id);
        }
        public async Task<ShopList> GetListByTitleAsync(string title)
        {
            return await _shopListRepository.GetListByTitleAsync(title);
        }
        public async Task<ShopList> AddShopListAsync(ShopList shopList)
        {
            return await _shopListRepository.AddShopListAsync(shopList);
        }
        public async Task<ShopList> UpdateShopListAsync(int id, ShopList shopList)
        {
            return await _shopListRepository.UpdateShopListAsync(id, shopList);
        }
        public async Task DeleteShopListAsync(int id)
        {
            await _shopListRepository.DeleteShopListAsync(id);
        }
    }
}
