using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListAPI.Core.Models
{
    public class ShopList
    {
        [Key]
        public int Key { get; set; }
        public string Title { get; set; }// קניות לשבת וכד
        public List<ProductInLIst> ListProductsInLIst { get; set; }
        public UserO UserO { get; set; }
    }
}
