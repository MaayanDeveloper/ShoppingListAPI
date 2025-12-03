using ShoppingListAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace productTest
{
    public class FakeContext: IDataContext
    {
        public List<Product> product { get; set; }
        public FakeContext()
        {
            product = new List<Product> {new Product {Id= 80, Name= "apple", Category="fruits", IsAvailable=true},
                          new Product {Id=81, Name="bamba", Category="snacks", IsAvailable=true},
                          new Product {Id=82, Name="bisli", Category="snacks", IsAvailable=true}};
        }
    }
}
