using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListAPI.Core.Models
{
    [Table("UserOs")]
    public class UserO
    {
        [Key]
        public int Key { get; set; }
        public int Identity { get; set; }
        public String Name { get; set; }
        public String Phon { get; set; }
        public String Adress { get; set; }
        public String Email { get; set; }
        public String Role { get; set; }
        public List<ShopList> ShopLists { get; set; }
        public String Password { get; set; }
    }
}
