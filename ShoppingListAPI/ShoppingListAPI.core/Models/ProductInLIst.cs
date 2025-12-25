using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListAPI.Core.Models
{
    public class ProductInLIst
    {
        [Key]
        public int Key { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public ShopList ShopList { get; set; } //כי כל מוצר נמכר לפי קטגוריה, אז לא יכול להיות שיש אותו בשתי רשימות


    }
}
