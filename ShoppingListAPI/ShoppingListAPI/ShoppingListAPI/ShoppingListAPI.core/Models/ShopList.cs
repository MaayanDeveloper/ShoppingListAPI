
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListAPI.Core.Models
{
    [Table("ShopLists")]
    public class ShopList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Key { get; set; }
        public string Title { get; set; }
        public List<ProductInLIst> ListProductsInLIst { get; set; }
        public int UserOKey { get; set; }
        [ForeignKey("UserOKey")]
        public UserO UserO { get; set; }
    }
}
