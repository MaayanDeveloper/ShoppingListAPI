using ShoppingListAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListAPI.Core.Repositories
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProductAsync();

        public Task< Product> GetByIdAsync(int id);

        public Task<Product> AddAsync(Product product);

        public Task<Product> UpdateAsync(int id, Product product);

        public Task DeleteAsync(int id);
        public Task SaveAsync();
        Task<Product> GetByIdentityAsync(string id);
    }

}
