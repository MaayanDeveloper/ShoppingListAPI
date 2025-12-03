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
        public List<Product> GetProduct();

        public Product GetById(int id);

        public void Post(Product product);

        public void Put(Product product);

        public void Delete(int id);
    }
}
