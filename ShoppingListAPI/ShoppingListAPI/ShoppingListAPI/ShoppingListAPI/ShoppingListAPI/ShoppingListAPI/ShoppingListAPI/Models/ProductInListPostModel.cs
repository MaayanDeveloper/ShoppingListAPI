namespace ShoppingListAPI.Models
{
    public class ProductInListPostModel
    {
        public int ShopListId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
