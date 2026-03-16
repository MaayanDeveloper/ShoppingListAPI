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
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int ShopListId { get; set; }
        [ForeignKey("ShopListId")]
        public ShopList ShopList { get; set; }
    }
}