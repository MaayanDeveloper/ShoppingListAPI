using Microsoft.EntityFrameworkCore;
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
        public async Task<List<Product>> GetProductAsync()
        {
            return await _context.product.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.product.FirstOrDefaultAsync(p => p.Id == id);
        }

        //public void PostAsync(Product product)
        //{
        //    _context.product.Add(product);
        //}
        //public void Put(int id, Product product)
        //{
        //    var p = _context.product.FindIndex(x => x.Id == id);
        //    _context.product.Add(product);
        //}

        public async Task<Product> AddAsync(Product product)
        {
            _context.product.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }


        public async Task<Product> UpdateAsync(int id, Product product)
        {
            var s = await GetByIdAsync(id);
            s.Name = product.Name;
            s.Category = product.Category;
            s.IsAvailable = product.IsAvailable;
            await _context.SaveChangesAsync();
            return s;
        }

        public async Task DeleteAsync(int id)
        {
            var s = await GetByIdAsync(id);
            _context.product.Remove(s);
            await _context.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<Product> GetByIdentityAsync(string id)
        {
            int productId = int.Parse(id); // המרה ממחרוזת למספר
            return await _context.product.FirstOrDefaultAsync(p => p.Id == productId);
        }



    }
}
