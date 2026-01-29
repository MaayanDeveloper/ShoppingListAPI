using ShoppingListAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListAPI.Core.Services
{
    public interface IProductService
    {

        public Task< List<Product>> GetProductAsync();
        public Task<Product> GetByIdentityAsync(string id);


        public Task<Product> GetByIdAsync(int id);

        public Task<Product> AddAsync(Product product);

        public Task<Product> UpdateAsync(int id, Product product);

        public Task DeleteAsync(int id);
    }
}
