using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListAPI.Core.Models
{
    public class UserO
    {
        [Key]
        public int Key { get; set; }
        public String Identity { get; set; }
        public String Name { get; set; }
        public String Phon { get; set; }
        public String Adress { get; set; }
        public String Email { get; set; }
        public List<ShopList> ShopLists { get; set; }
    }
}
