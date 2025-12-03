using ShoppingListAPI.Core.Models;
using ShoppingListAPI.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShoppingListAPI.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        public List<Product> GetProduct()
        {
            return _context.product;
        }

        public Product GetById(int id)
        {
            return _context.product.Find(p => p.Id == id);
        }
        public void Post(Product product)
        {
            _context.product.Add(product);
        }
        public void Put(int id, Product product)
        {
            var p = _context.product.FindIndex(x => x.Id == id);
            _context.product.Add(product);
        }
        public void  Delete(int id)
        {
            var p = _context.product.Find(y => y.Id == id);
            _context.product.Remove(p);
        }

    
    }
}
