using ShoppingListAPI.Core.Models;

namespace ShoppingListAPI.Data
{
    public class DataContext
    {
        public List<Product> product { get; set; }
        public DataContext()
        {
            {
                product = new List<Product> {new Product {Id= 1, Name= "milk", Category="dairy", IsAvailable=true},
                          new Product {Id=2, Name="chips", Category="snacks", IsAvailable=true},
                          new Product {Id=3, Name="milki", Category="dairy", IsAvailable=true}};

            }
        }
    }
}
