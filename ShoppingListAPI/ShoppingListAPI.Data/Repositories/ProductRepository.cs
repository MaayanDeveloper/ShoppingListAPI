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
            return _context.product.ToList();
        }

        public Product GetById(int id)
        {
            return _context.product.ToList().Find(p => p.Id == id);
        }
        public void Post(Product product)
        {
            _context.product.Add(product);
        }
        //public void Put(int id, Product product)
        //{
        //    var p = _context.product.FindIndex(x => x.Id == id);
        //    _context.product.Add(product);
        //}

        public Product Add(Product product)
        {
            _context.product.Add(product);
            return product;
            
        }

        public Product Update(int id, Product product)
        {
            var s=GetById(product.Id);
            s.Name = product.Name;
            s.Category = product.Category;
            s.IsAvailable = product.IsAvailable;
            return s;

        }
        public void Delete(int id)
        {
            var s=GetById(id);
            _context.product.Remove(s);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
