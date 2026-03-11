using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListAPI.Core.Models
{
    [Table("ProductIns")]
    public class ProductInLIst
    {
        [Key]
        public int Key { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public ShopList ShopList { get; set; }
    }
}