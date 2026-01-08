namespace ShoppingListAPI.Models
{
    public class ProductPostModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public bool IsAvailable { get; set; }
    }
}
