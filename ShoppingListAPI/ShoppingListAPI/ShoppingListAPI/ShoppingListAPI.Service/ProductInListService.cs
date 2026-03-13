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
    public class ProductInListService : IProductInListService
    {
        private readonly IProductInListRepository _repository;
        public ProductInListService(IProductInListRepository repository)
        {
            _repository = repository;
        }
        public async Task<ProductInLIst> AddProductToListAsync(ProductInLIst item)
        {
            return await _repository.AddProductToListAsync(item);
        }
    }
}
