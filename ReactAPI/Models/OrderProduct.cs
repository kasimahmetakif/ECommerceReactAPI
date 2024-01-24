namespace ReactAPI.Models
{
    public class OrderProduct
    {
        public int Id { get; set; } 
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public bool IsStatus { get; set; }
    }

}
