namespace ReactAPI.Models
{
    public class CartItem
    {
        public int Id { get; set; } 
        public int ProductId { get; set; } 
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }

    }
}
