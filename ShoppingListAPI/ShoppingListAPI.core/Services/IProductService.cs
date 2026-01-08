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

        public List<Product> GetProduct();
        public Product GetByIdentity(String id);

        public Product GetById(int id);

        public Product Add(Product product);

        public Product Update(int id, Product product);

        public void Delete(int id);
    }
}
