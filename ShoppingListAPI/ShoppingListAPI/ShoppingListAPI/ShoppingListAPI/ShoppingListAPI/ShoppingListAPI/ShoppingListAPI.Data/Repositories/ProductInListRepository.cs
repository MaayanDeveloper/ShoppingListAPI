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
    public class ProductInListRepository : IProductInListRepository
    {
        private readonly DataContext _context;
        public ProductInListRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<ProductInLIst> AddProductToListAsync(ProductInLIst item)
        {
            _context.ProductIns.Add(item);
            await _context.SaveChangesAsync();

            return await _context.ProductIns
                .Include(p => p.Product)
                    .FirstOrDefaultAsync(p => p.Key == item.Key);
        }

        public async Task<bool> DeleteProductFromListAsync(int id)
        {
            var productInList = await _context.ProductIns.FindAsync(id);
            if (productInList == null)
            {
                return false; // לא נמצא, אז אי אפשר למחוק
            }

            _context.ProductIns.Remove(productInList);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
