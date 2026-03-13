using ShoppingListAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListAPI.Core.Repositories
{
    public interface IProductInListRepository
    {
        Task<ProductInLIst> AddProductToListAsync(ProductInLIst item);
    }
}
