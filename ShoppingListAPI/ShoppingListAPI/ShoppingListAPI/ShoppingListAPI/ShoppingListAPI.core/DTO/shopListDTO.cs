using ShoppingListAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListAPI.Core.DTO
{
    public class shopListDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<ProductInListDTO> ListProductsInLIst { get; set; }
    }
}
