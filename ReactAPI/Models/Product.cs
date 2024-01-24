using System.ComponentModel.DataAnnotations.Schema;

namespace ReactAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public bool IsStatus { get; set; }
        public DateTime Date { get; set; }
        

    }

}
