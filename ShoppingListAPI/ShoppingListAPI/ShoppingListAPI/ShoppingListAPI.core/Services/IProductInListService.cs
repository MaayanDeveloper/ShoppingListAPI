using ShoppingListAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListAPI.Core.Services
{
    public interface IProductInListService
    {
        Task<ProductInLIst> AddProductToListAsync(ProductInLIst item);
    }
}
