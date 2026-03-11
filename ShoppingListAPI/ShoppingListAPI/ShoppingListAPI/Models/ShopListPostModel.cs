namespace ShoppingListAPI.Models
{
    public class ShopListPostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<ProductPostModels> ListProductsInLIst { get; set; }
    }
}
