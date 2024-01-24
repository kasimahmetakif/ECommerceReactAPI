namespace ReactAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public List<OrderProduct> Products { get; set; }
        public bool IsStatus { get; set; }

    }

}
