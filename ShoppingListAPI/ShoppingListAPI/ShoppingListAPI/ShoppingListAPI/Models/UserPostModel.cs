using ShoppingListAPI.Core.Models;

namespace ShoppingListAPI.Models
{
    public class UserPostModel
    {
        public int Key { get; set; }
        public String Identity { get; set; }
        public String Name { get; set; }
        public String Phon { get; set; }
        public String Adress { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
    }
}
