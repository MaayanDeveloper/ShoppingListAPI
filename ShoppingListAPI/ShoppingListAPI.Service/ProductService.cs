using ShoppingListAPI.Core.Services;
using ShoppingListAPI.Core.Models;
using ShoppingListAPI.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListAPI.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetProductAsync()
        {
            return await _productRepository.GetProductAsync();
        }


        public async Task< Product> GetByIdAsync(int id)
        {
            return await  _productRepository.GetByIdAsync(id);
        }

        public async Task<Product> GetByIdentityAsync(string id)
        {
            return await _productRepository.GetByIdentityAsync(id);
        }




        public async Task<Product> AddAsync(Product product)
        {
            var s = await _productRepository.AddAsync(product);
            return s;
        }


        public async Task<Product> UpdateAsync(int id, Product product)
        {
            var updated = await _productRepository.UpdateAsync(id, product);
            return updated;
        }


        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }


    }
}
