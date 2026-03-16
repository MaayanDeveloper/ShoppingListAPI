using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListAPI.Core.DTO
{
    public class ProductInListDTO
    {
        public int key { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } // אפשר להוסיף את שם המוצר מה-Entity
        public int Quantity { get; set; }
    }
}
