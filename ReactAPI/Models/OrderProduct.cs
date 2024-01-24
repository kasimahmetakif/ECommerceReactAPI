using System.ComponentModel.DataAnnotations.Schema;

namespace ReactAPI.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public bool IsStatus { get; set; }
    }

}
